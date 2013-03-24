﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace GitCommands
{
    public abstract class RevisionGraphInMemFilter
    {
        public abstract bool PassThru(GitRevision rev);
    }

    public sealed class RevisionGraph : IDisposable
    {
        public event EventHandler Exited;
        public event EventHandler<AsyncErrorEventArgs> Error 
        {
            add 
            {
                _backgroundLoader.LoadingError += value;
            }
            
            remove 
            {
                _backgroundLoader.LoadingError -= value;
            }
        }
        public event EventHandler Updated;
        public event EventHandler BeginUpdate;
        public int RevisionCount { get; set; }

        public class RevisionGraphUpdatedEventArgs : EventArgs
        {
            public RevisionGraphUpdatedEventArgs(GitRevision revision)
            {
                Revision = revision;
            }

            public readonly GitRevision Revision;
        }

        public bool BackgroundThread { get; set; }
        public bool ShaOnly { get; set; }

        private readonly char[] _splitChars = " \t\n".ToCharArray();

        private readonly char[] _hexChars = "0123456789ABCDEFabcdef".ToCharArray();

        private const string CommitBegin = "<(__BEGIN_COMMIT__)>"; // Something unlikely to show up in a comment

        private Dictionary<string, List<GitHead>> _heads;

        private enum ReadStep
        {
            Commit,
            Hash,
            Parents,
            Tree,
            AuthorName,
            AuthorEmail,
            AuthorDate,
            CommitterName,
            CommitterEmail,
            CommitterDate,
            CommitMessageEncoding,
            CommitMessage,
            FileName,
            Done,
        }

        private ReadStep _nextStep = ReadStep.Commit;

        private GitRevision _revision;

        private readonly AsyncLoader _backgroundLoader = new AsyncLoader();

        private readonly GitModule _module;

        public RevisionGraph(GitModule module)
        {
            BackgroundThread = true;
            _module = module;
        }

        ~RevisionGraph()
        {
            Dispose();
        }

        public void Dispose()
        {
            _backgroundLoader.Cancel();
        }

        public string LogParam = "HEAD --all";//--branches --remotes --tags";
        public string BranchFilter = String.Empty;
        public RevisionGraphInMemFilter InMemFilter;
        private string _selectedBranchName;

        public void Execute()
        {
            if (BackgroundThread)
            {
                _backgroundLoader.Load(ProccessGitLog, ProccessGitLogExecuted);
            }
            else
            {
                ProccessGitLog(new CancellationToken(false));
                ProccessGitLogExecuted();
            }
        }

        private void ProccessGitLog(CancellationToken taskState)
        {
            RevisionCount = 0;
            _heads = GetHeads().ToDictionaryOfList(head => head.Guid);

            string formatString =
                /* <COMMIT>       */ CommitBegin + "%n" +
                /* Hash           */ "%H%n" +
                /* Parents        */ "%P%n";
            if (!ShaOnly)
            {
                formatString +=
                    /* Tree                    */ "%T%n" +
                    /* Author Name             */ "%aN%n" +
                    /* Author Email            */ "%aE%n" +
                    /* Author Date             */ "%at%n" +
                    /* Committer Name          */ "%cN%n" +
                    /* Committer Email         */ "%cE%n" +
                    /* Committer Date          */ "%ct%n" +
                    /* Commit message encoding */ "%e%n" + //there is a bug: git does not recode commit message when format is given
                    /* Commit Message          */ "%s";
            }

            // NOTE:
            // when called from FileHistory and FollowRenamesInFileHistory is enabled the "--name-only" argument is set.
            // the filename is the next line after the commit-format defined above.

            if (Settings.OrderRevisionByDate)
            {
                LogParam = " --date-order " + LogParam;
            }
            else
            {
                LogParam = " --topo-order " + LogParam;
            }

            string arguments = String.Format(CultureInfo.InvariantCulture,
                "log -z {2} --pretty=format:\"{1}\" {0}",
                LogParam,
                formatString,
                BranchFilter);

            using (GitCommandsInstance gitGetGraphCommand = new GitCommandsInstance(_module))
            {
                gitGetGraphCommand.StreamOutput = true;
                gitGetGraphCommand.CollectOutput = false;
                Encoding LogOutputEncoding = _module.LogOutputEncoding;
                gitGetGraphCommand.SetupStartInfoCallback = startInfo =>
                {
                    startInfo.StandardOutputEncoding = GitModule.LosslessEncoding;
                    startInfo.StandardErrorEncoding = GitModule.LosslessEncoding;
                };

                Process p = gitGetGraphCommand.CmdStartProcess(Settings.GitCommand, arguments);
                
                if (taskState.IsCancellationRequested)
                    return;

                _previousFileName = null;
                if (BeginUpdate != null)
                    BeginUpdate(this, EventArgs.Empty);

                string line;
                do
                {
                    line = p.StandardOutput.ReadLine();
                    //commit message is not encoded by git
                    if (_nextStep != ReadStep.CommitMessage)
                        line = GitModule.ReEncodeString(line, GitModule.LosslessEncoding, LogOutputEncoding);

                    if (line != null)
                    {
                        foreach (string entry in line.Split('\0'))
                        {
                            DataReceived(entry);
                        }
                    }
                } while (line != null && !taskState.IsCancellationRequested);
            }
        }

        private void ProccessGitLogExecuted()
        {
            FinishRevision();
            _previousFileName = null;

            if (Exited != null)
                Exited(this, EventArgs.Empty);            
        }

        private IList<GitHead> GetHeads()
        {
            var result = _module.GetHeads(true);
            bool validWorkingDir = _module.IsValidGitWorkingDir();
            _selectedBranchName = validWorkingDir ? _module.GetSelectedBranch() : string.Empty;
            GitHead selectedHead = result.FirstOrDefault(head => head.Name == _selectedBranchName);

            if (selectedHead != null)
            {
                selectedHead.Selected = true;

                var localConfigFile = _module.GetLocalConfig();

                var selectedHeadMergeSource =
                    result.FirstOrDefault(head => head.IsRemote
                                        && selectedHead.GetTrackingRemote(localConfigFile) == head.Remote
                                        && selectedHead.GetMergeWith(localConfigFile) == head.LocalName);

                if (selectedHeadMergeSource != null)
                    selectedHeadMergeSource.SelectedHeadMergeSource = true;
            }

            return result;
        }

        private string _previousFileName;

        void FinishRevision()
        {
            if (_revision != null)
            {
                if (_revision.Name == null)                
                    _revision.Name = _previousFileName;
                else
                    _previousFileName = _revision.Name;
            }
            if (_revision == null || _revision.Guid.Trim(_hexChars).Length == 0)
            {
                if ((_revision == null) || (InMemFilter == null) || InMemFilter.PassThru(_revision))
                {
                    if (_revision != null)
                        RevisionCount++;
                    if (Updated != null)
                        Updated(this, new RevisionGraphUpdatedEventArgs(_revision));
                }
            }
            _nextStep = ReadStep.Commit;
        }

        void DataReceived(string line)
        {
            if (line == null)
                return;

            if (line == CommitBegin)
            {
                // a new commit finalizes the last revision
                FinishRevision();

                _nextStep = ReadStep.Commit;
            }

            switch (_nextStep)
            {
                case ReadStep.Commit:
                    // Sanity check
                    if (line == CommitBegin)
                    {
                        _revision = new GitRevision(_module, null);
                    }
                    else
                    {
                        // Bail out until we see what we expect
                        return;
                    }
                    break;

                case ReadStep.Hash:
                    _revision.Guid = line;

                    List<GitHead> headList;
                    if (_heads.TryGetValue(_revision.Guid, out headList))
                        _revision.Heads.AddRange(headList);
                    
                    break;

                case ReadStep.Parents:
                    _revision.ParentGuids = line.Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);
                    break;

                case ReadStep.Tree:
                    _revision.TreeGuid = line;
                    break;

                case ReadStep.AuthorName:
                    _revision.Author = line;
                    break;

                case ReadStep.AuthorEmail:
                    _revision.AuthorEmail = line;
                    break;

                case ReadStep.AuthorDate:
                    {
                        DateTime dateTime;
                        if (DateTimeUtils.TryParseUnixTime(line, out dateTime))
                            _revision.AuthorDate = dateTime;
                    }
                    break;

                case ReadStep.CommitterName:
                    _revision.Committer = line;
                    break;

                case ReadStep.CommitterEmail:
                    _revision.CommitterEmail = line;
                    break;

                case ReadStep.CommitterDate:
                    {
                        DateTime dateTime;
                        if (DateTimeUtils.TryParseUnixTime(line, out dateTime))
                            _revision.CommitDate = dateTime;
                    }
                    break;

                case ReadStep.CommitMessageEncoding:
                    _revision.MessageEncoding = line;
                    break;
                
                case ReadStep.CommitMessage:
                    _revision.Message = _module.ReEncodeCommitMessage(line, _revision.MessageEncoding);

                    break;

                case ReadStep.FileName:
                    _revision.Name = line;
                    break;
            }

            _nextStep++;
        }
    }
}
