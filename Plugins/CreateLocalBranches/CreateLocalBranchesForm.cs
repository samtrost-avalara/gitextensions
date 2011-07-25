﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GitUIPluginInterfaces;

namespace CreateLocalBranches
{
    public partial class CreateLocalBranchesForm : Form
    {
        private GitUIBaseEventArgs m_gitUiCommands;

        public CreateLocalBranchesForm(GitUIBaseEventArgs gitUiCommands)
        {
            InitializeComponent();

            m_gitUiCommands = gitUiCommands;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var references = m_gitUiCommands.GitCommands.RunGit("branch -a").Split('\n')
                .Where(r => !string.IsNullOrEmpty(r));

            if (!references.Any())
            {
                MessageBox.Show("No remote branches found.");
                DialogResult = DialogResult.Cancel;
                return;
            }

            foreach (string reference in references)
            {
                try
                {
                    string branchName = reference.Trim('*', ' ', '\n', '\r');

                    if (branchName.StartsWith("remotes/" + Remote.Text + "/"))
                        m_gitUiCommands.GitCommands.RunGit(string.Concat("branch --track ", branchName.Replace("remotes/" + Remote.Text + "/", ""), " ", branchName));
                }
                catch
                {
                }
            }

            MessageBox.Show(string.Format("{0} local tracking branches have been created/updated.",
                                          references.Count()));
            Close();
        }
    }
}
