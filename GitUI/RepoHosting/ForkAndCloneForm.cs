﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GitUIPluginInterfaces.RepositoryHosts;
using GitCommands;
using System.IO;
using GitCommands.Repository;
using System.Threading;
using System.Diagnostics;

namespace GitUI.RepoHosting
{
    public partial class ForkAndCloneForm : GitExtensionsForm
    {
        IRepositoryHostPlugin _gitHoster;

        public ForkAndCloneForm(IRepositoryHostPlugin gitHoster)
        {
            _gitHoster = gitHoster;
            InitializeComponent();
            Translate();
        }

        private void ForkAndCloneForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            var hist = Repositories.RepositoryHistory;
            var lastRepo = hist.Repositories.FirstOrDefault();
            if (lastRepo != null && !string.IsNullOrEmpty(lastRepo.Path))
            {
                string p = lastRepo.Path.Trim('/', '\\');

                _destinationTB.Text = Path.GetDirectoryName(p);
            }

            this.Text = _gitHoster.Description + ": " + this.Text;

            UpdateCloneInfo();
            UpdateMyRepos();
        }

        private void UpdateMyRepos()
        {
            _myReposLV.Items.Clear();
            _myReposLV.Items.Add(new ListViewItem() { Text = " : LOADING : " });

            AsyncHelpers.DoAsync(
                ()=>_gitHoster.GetMyRepos(),

                (repos) => 
                {
                    _myReposLV.Items.Clear();
                    foreach (var repo in repos)
                    {
                        var lvi = new ListViewItem();
                        lvi.Tag = repo;
                        lvi.Text = repo.Name;
                        lvi.SubItems.Add(repo.IsAFork ? "Yes" : "No");
                        lvi.SubItems.Add(repo.Forks.ToString());
                        lvi.SubItems.Add(repo.IsPrivate ? "Yes" : "No");
                        _myReposLV.Items.Add(lvi);
                    }
                },

                (ex) =>
                {
                    MessageBox.Show(this, "Failed to get repos. Username/ApiToken incorrect?", "Error");
                    Close();
                });
        }

        #region GUI Handlers
        private void _searchBtn_Click(object sender, EventArgs e)
        {
            var search = _searchTB.Text;
            if (search == null || search.Trim().Length == 0)
                return;

            PrepareSearch(sender, e);

            AsyncHelpers.DoAsync(
                () => _gitHoster.SearchForRepository(search),
                (repos) => HandleSearchResult(repos),
                (ex) => { MessageBox.Show(this, "Search failed!\r\n" + ex.Message, "Error"); _searchBtn.Enabled = true; });
        }

        private void _getFromUserBtn_Click(object sender, EventArgs e)
        {
            var search = _searchTB.Text;
            if (search == null || search.Trim().Length == 0)
                return;
            PrepareSearch(sender, e);

            AsyncHelpers.DoAsync(
                () => _gitHoster.GetRepositoriesOfUser(search.Trim()),
                (repos) => HandleSearchResult(repos),
                (ex) => {
                    if (ex.Message.Contains("404"))
                        MessageBox.Show(this, "User not found!", "Oops");
                    else
                        MessageBox.Show(this, "Could not fetch repositories of user!\r\n" + ex.Message, "Error"); 
                    _searchBtn.Enabled = true; 
                });
        }


        private void PrepareSearch(object sender, EventArgs e)
        {
            _searchResultsLV.Items.Clear();
            _searchResultsLV_SelectedIndexChanged(sender, e);
            _searchBtn.Enabled = false;
            _searchResultsLV.Items.Add(new ListViewItem() { Text = " : SEARCHING : " });
        }

        private void HandleSearchResult(IList<IHostedRepository> repos)
        {
            _searchResultsLV.Items.Clear();
            foreach (var repo in repos)
            {
                var lvi = new ListViewItem();
                lvi.Tag = repo;
                lvi.Text = repo.Name;
                lvi.SubItems.Add(repo.Owner);
                lvi.SubItems.Add(repo.Forks.ToString());
                lvi.SubItems.Add(repo.IsAFork ? "Yes" : "No");
                _searchResultsLV.Items.Add(lvi);
            }
            _searchBtn.Enabled = true;
        }


        private void _forkBtn_Click(object sender, EventArgs e)
        {
            if (_searchResultsLV.SelectedItems.Count != 1)
            {
                MessageBox.Show(this, "You must select exactly one item", "Error");
                return;
            }

            var hostedRepo = _searchResultsLV.SelectedItems[0].Tag as IHostedRepository;
            try
            {
                hostedRepo.Fork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception: " + ex.Message, "Fork failed.");
            }

            _tabControl.SelectedTab = _myReposPage;
            UpdateMyRepos();
        }

        private void _searchTB_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = _searchBtn;
        }

        private void _searchTB_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void _searchResultsLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCloneInfo();
            if (_searchResultsLV.SelectedItems.Count != 1)
            {
                _forkBtn.Enabled = false;
                return;
            }

            _forkBtn.Enabled = true;
            var hostedRepo = (IHostedRepository)_searchResultsLV.SelectedItems[0].Tag;
            _searchResultItemDescription.Text = hostedRepo.Description;
        }

        private void _browseForCloneToDirbtn_Click(object sender, EventArgs e)
        {
            var initialDir = _destinationTB.Text.Length > 0 ? _destinationTB.Text : "C:\\";

            var browseDialog = new FolderBrowserDialog { SelectedPath = initialDir };

            if (browseDialog.ShowDialog(this) == DialogResult.OK)
            {
                _destinationTB.Text = browseDialog.SelectedPath;
                _destinationTB_TextChanged(sender, e);
            }
        }

        private void _cloneBtn_Click(object sender, EventArgs e)
        {
            Clone(CurrentySelectedGitRepo);
        }

        private void _openGitupPageBtn_Click(object sender, EventArgs e)
        {
            if (CurrentySelectedGitRepo == null)
                return;
            string hp = CurrentySelectedGitRepo.Homepage;
            if (string.IsNullOrEmpty(hp) || (!hp.StartsWith("http://") && !hp.StartsWith("https://")))
                MessageBox.Show(this, "No homepage defined", "");
            else
                Process.Start(CurrentySelectedGitRepo.Homepage);
        }

        private void _closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void _tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCloneInfo();
            if (_tabControl.SelectedTab == _searchReposPage)
                _searchTB.Focus();
        }

        private void _myReposLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCloneInfo();
        }

        private void _createDirTB_TextChanged(object sender, EventArgs e)
        {
            UpdateCloneInfo(false);
        }

        private void _destinationTB_TextChanged(object sender, EventArgs e)
        {
            UpdateCloneInfo(false);
        }

        private void _addRemoteAsTB_TextChanged(object sender, EventArgs e)
        {
            UpdateCloneInfo(false);
        }
        #endregion

        private void Clone(IHostedRepository repo)
        {
            string targetDir = GetTargetDir(repo);
            if (targetDir == null)
                return;

            string repoSrc = repo.CloneReadWriteUrl;

            string cmd = GitCommandHelpers.CloneCmd(repoSrc, targetDir, false, null);
            var formProcess = new FormProcess(Settings.GitCommand, cmd);
            formProcess.ShowDialog();

            if (formProcess.ErrorOccurred())
                return;

            Repositories.RepositoryHistory.AddMostRecentRepository(targetDir);
            Settings.WorkingDir = targetDir;

            if (_addRemoteAsTB.Text.Trim().Length > 0)
            {
                var error = GitCommandHelpers.AddRemote(_addRemoteAsTB.Text.Trim(), repo.ParentReadOnlyUrl);
                if (!string.IsNullOrEmpty(error))
                    MessageBox.Show(this, error, "Could not add remote");
            }

            Close();
        }

        private IHostedRepository CurrentySelectedGitRepo
        {
            get
            {
                if (_tabControl.SelectedTab == _searchReposPage)
                {
                    if (_searchResultsLV.SelectedItems.Count != 1)
                        return null;

                    return (IHostedRepository)_searchResultsLV.SelectedItems[0].Tag;
                }
                else
                {
                    if (_myReposLV.SelectedItems.Count != 1)
                        return null;

                    return (IHostedRepository)_myReposLV.SelectedItems[0].Tag;
                }
            }
        }

        private void UpdateCloneInfo()
        {
            UpdateCloneInfo(true);
        }

        private void UpdateCloneInfo(bool updateCreateDirTB)
        {
            var repo = CurrentySelectedGitRepo;

            if (repo != null)
            {
                if (updateCreateDirTB)
                {
                    _createDirTB.Text = repo.Name;
                    _addRemoteAsTB.Text = repo.ParentOwner != null ? repo.ParentOwner : "";
                }

                _cloneBtn.Enabled = true;
                var moreInfo = !string.IsNullOrEmpty(_addRemoteAsTB.Text) ? string.Format("\"{0}\" will be added as a remote.", _addRemoteAsTB.Text.Trim()) : "";

                if (_tabControl.SelectedTab == _searchReposPage)
                    _cloneInfoText.Text = string.Format("Will clone {0} into {1}.\r\nYou can not push unless you are a collaborator. {2}", repo.CloneReadWriteUrl, GetTargetDir(repo), moreInfo);
                else if (_tabControl.SelectedTab == _myReposPage)
                    _cloneInfoText.Text = string.Format("Will clone {0} into {1}.\r\nYou will have push access. {2}", repo.CloneReadWriteUrl, GetTargetDir(repo), moreInfo);
            }
            else
            {
                _cloneBtn.Enabled = false;
                _cloneInfoText.Text = "";
                _createDirTB.Text = "";
            }
        }

        private string GetTargetDir(IHostedRepository repo)
        {
            string targetDir = _destinationTB.Text.Trim();
            if (targetDir.Length == 0)
            {
                MessageBox.Show(this, "Clone folder can not be empty", "Error");
                return null;
            }

            targetDir = Path.Combine(targetDir, _createDirTB.Text);
            return targetDir;
        }
    }
}
