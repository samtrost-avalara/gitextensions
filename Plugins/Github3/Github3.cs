﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GitUIPluginInterfaces.RepositoryHosts;
using GitUIPluginInterfaces;
using Git.hub;
using System.Windows.Forms;

namespace Github3
{
    class GithubAPIInfo
    {
        internal static string client_id = "ebc0e8947c206610d737";
        internal static string client_secret = "c993907df3f45145bf638842692b69c56d1ace4d";
    }

    class GithubLoginInfo
    {
        private static string _username;
        public static string username
        {
            get
            {
                if (_username == "")
                    return null;
                if (_username != null)
                    return _username;

                try
                {
                    var user = Github3.github.getCurrentUser();
                    if (user != null)
                    {
                        _username = user.Login;
                        MessageBox.Show("Github username: " + _username);
                        return _username;
                    }
                    else
                        _username = "";

                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static string OAuthToken
        {
            get
            {
                return Github3.instance.Settings.GetSetting("OAuth Token");
            }
            set
            {
                _username = null;
                Github3.instance.Settings.SetSetting("OAuth Token", value);
                Github3.github.setOAuth2Token(value);
            }
        }
    }

    public class Github3 : IRepositoryHostPlugin
    {
        internal static Github3 instance;
        internal static Client github;
        public Github3()
        {
            if (instance != null)
                throw new InvalidOperationException("tried to create second instance");

            instance = this;

            github = new Client();
        }

        public string Description
        {
            get { return "Github"; }
        }

        public IGitPluginSettingsContainer Settings { get; set; }

        public void Register(IGitUICommands gitUiCommands)
        {
            Settings.AddSetting("OAuth Token", "");

            if (GithubLoginInfo.OAuthToken.Length > 0)
            {
                github.setOAuth2Token(GithubLoginInfo.OAuthToken);
            }
        }

        public bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            if (GithubLoginInfo.OAuthToken.Length == 0)
            {
                new OAuth().ShowDialog(gitUiCommands.OwnerForm as IWin32Window);
            }
            else
            {
                MessageBox.Show(gitUiCommands.OwnerForm as IWin32Window, "You already have an OAuth token. To get a new one, delete your old one in Plugins > Settings first.");
            }
            return false;
        }

        // --

        public IList<IHostedRepository> SearchForRepository(string search)
        {
            throw new NotImplementedException();
        }

        public IList<IHostedRepository> GetRepositoriesOfUser(string user)
        {
            return github.getRepositories(user).Select(repo => (IHostedRepository) new GithubRepo(repo)).ToList();
        }

        public IHostedRepository GetRepository(string user, string repositoryName)
        {
            return new GithubRepo(github.getRepository(user, repositoryName));
        }

        public IList<IHostedRepository> GetMyRepos()
        {
            return github.getRepositories().Select(repo => (IHostedRepository)new GithubRepo(repo)).ToList();
        }

        public bool ConfigurationOk
        {
            get { return true; }
        }

        public bool CurrentWorkingDirRepoIsRelevantToMe
        {
            get { return false; }
        }

        public List<IHostedRemote> GetHostedRemotesForCurrentWorkingDirRepo()
        {
            return new List<IHostedRemote>();
        }
    }
}
