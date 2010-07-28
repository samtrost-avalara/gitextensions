﻿using GitStatistics.PieChart;

namespace GitStatistics
{
    partial class FormGitStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGitStatistics));
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TotalLinesOfCode = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LinesOfCodePerLanguageText = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.TotalLinesOfCode2 = new System.Windows.Forms.Label();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.LinesOfCodePerTypeText = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.TotalLinesOfTestCode = new System.Windows.Forms.Label();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.TestCodeText = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.TotalCommits = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.CommitStatistics = new System.Windows.Forms.Label();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.LinesOfCodeExtensionPie = new PieChartControl();
            this.LinesOfCodePie = new PieChartControl();
            this.TestCodePie = new PieChartControl();
            this.CommitCountPie = new PieChartControl();
            this.Tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabPage3);
            this.Tabs.Controls.Add(this.tabPage4);
            this.Tabs.Controls.Add(this.tabPage2);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(751, 465);
            this.Tabs.TabIndex = 0;
            this.Tabs.Visible = false;
            this.Tabs.SelectedIndexChanged += new System.EventHandler(this.TabsSelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(743, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lines of code per language";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TotalLinesOfCode);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(737, 433);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 2;
            // 
            // TotalLinesOfCode
            // 
            this.TotalLinesOfCode.AutoSize = true;
            this.TotalLinesOfCode.Location = new System.Drawing.Point(5, 2);
            this.TotalLinesOfCode.Name = "TotalLinesOfCode";
            this.TotalLinesOfCode.Size = new System.Drawing.Size(137, 16);
            this.TotalLinesOfCode.TabIndex = 0;
            this.TotalLinesOfCode.Text = "Total lines of code";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LinesOfCodePerLanguageText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LinesOfCodeExtensionPie);
            this.splitContainer1.Size = new System.Drawing.Size(737, 404);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 1;
            // 
            // LinesOfCodePerLanguageText
            // 
            this.LinesOfCodePerLanguageText.AutoSize = true;
            this.LinesOfCodePerLanguageText.Location = new System.Drawing.Point(6, 3);
            this.LinesOfCodePerLanguageText.Name = "LinesOfCodePerLanguageText";
            this.LinesOfCodePerLanguageText.Size = new System.Drawing.Size(35, 13);
            this.LinesOfCodePerLanguageText.TabIndex = 1;
            this.LinesOfCodePerLanguageText.Text = "label1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(743, 439);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Lines of code per type";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.TotalLinesOfCode2);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(743, 439);
            this.splitContainer5.SplitterDistance = 32;
            this.splitContainer5.TabIndex = 0;
            // 
            // TotalLinesOfCode2
            // 
            this.TotalLinesOfCode2.AutoSize = true;
            this.TotalLinesOfCode2.Location = new System.Drawing.Point(8, 5);
            this.TotalLinesOfCode2.Name = "TotalLinesOfCode2";
            this.TotalLinesOfCode2.Size = new System.Drawing.Size(137, 16);
            this.TotalLinesOfCode2.TabIndex = 1;
            this.TotalLinesOfCode2.Text = "Total lines of code";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.LinesOfCodePerTypeText);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.LinesOfCodePie);
            this.splitContainer6.Size = new System.Drawing.Size(743, 403);
            this.splitContainer6.SplitterDistance = 269;
            this.splitContainer6.TabIndex = 0;
            // 
            // LinesOfCodePerTypeText
            // 
            this.LinesOfCodePerTypeText.AutoSize = true;
            this.LinesOfCodePerTypeText.Location = new System.Drawing.Point(9, 4);
            this.LinesOfCodePerTypeText.Name = "LinesOfCodePerTypeText";
            this.LinesOfCodePerTypeText.Size = new System.Drawing.Size(129, 13);
            this.LinesOfCodePerTypeText.TabIndex = 0;
            this.LinesOfCodePerTypeText.Text = "LinesOfCodePerTypeText";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(743, 439);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Lines of testcode";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.TotalLinesOfTestCode);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer8);
            this.splitContainer7.Size = new System.Drawing.Size(743, 439);
            this.splitContainer7.SplitterDistance = 28;
            this.splitContainer7.TabIndex = 0;
            // 
            // TotalLinesOfTestCode
            // 
            this.TotalLinesOfTestCode.AutoSize = true;
            this.TotalLinesOfTestCode.Location = new System.Drawing.Point(8, 5);
            this.TotalLinesOfTestCode.Name = "TotalLinesOfTestCode";
            this.TotalLinesOfTestCode.Size = new System.Drawing.Size(137, 16);
            this.TotalLinesOfTestCode.TabIndex = 2;
            this.TotalLinesOfTestCode.Text = "Total lines of code";
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.TestCodeText);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.TestCodePie);
            this.splitContainer8.Size = new System.Drawing.Size(743, 407);
            this.splitContainer8.SplitterDistance = 260;
            this.splitContainer8.TabIndex = 0;
            // 
            // TestCodeText
            // 
            this.TestCodeText.AutoSize = true;
            this.TestCodeText.Location = new System.Drawing.Point(8, 4);
            this.TestCodeText.Name = "TestCodeText";
            this.TestCodeText.Size = new System.Drawing.Size(35, 13);
            this.TestCodeText.TabIndex = 0;
            this.TestCodeText.Text = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(743, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Commits per contributor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.TotalCommits);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(737, 433);
            this.splitContainer3.SplitterDistance = 29;
            this.splitContainer3.TabIndex = 0;
            // 
            // TotalCommits
            // 
            this.TotalCommits.AutoSize = true;
            this.TotalCommits.Location = new System.Drawing.Point(5, 2);
            this.TotalCommits.Name = "TotalCommits";
            this.TotalCommits.Size = new System.Drawing.Size(105, 16);
            this.TotalCommits.TabIndex = 1;
            this.TotalCommits.Text = "Total commits";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.CommitStatistics);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.CommitCountPie);
            this.splitContainer4.Size = new System.Drawing.Size(737, 400);
            this.splitContainer4.SplitterDistance = 286;
            this.splitContainer4.TabIndex = 1;
            // 
            // CommitStatistics
            // 
            this.CommitStatistics.AutoSize = true;
            this.CommitStatistics.Location = new System.Drawing.Point(5, 0);
            this.CommitStatistics.Name = "CommitStatistics";
            this.CommitStatistics.Size = new System.Drawing.Size(35, 13);
            this.CommitStatistics.TabIndex = 0;
            this.CommitStatistics.Text = "label1";
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.Location = new System.Drawing.Point(315, 26);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(103, 24);
            this.LoadingLabel.TabIndex = 1;
            this.LoadingLabel.Text = "Loading...";
            // 
            // LinesOfCodeExtensionPie
            // 
            this.LinesOfCodeExtensionPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LinesOfCodeExtensionPie.InitialAngle = 0F;
            this.LinesOfCodeExtensionPie.Location = new System.Drawing.Point(0, 0);
            this.LinesOfCodeExtensionPie.Name = "LinesOfCodeExtensionPie";
            this.LinesOfCodeExtensionPie.Size = new System.Drawing.Size(480, 404);
            this.LinesOfCodeExtensionPie.TabIndex = 0;
            this.LinesOfCodeExtensionPie.ToolTips = null;
            // 
            // LinesOfCodePie
            // 
            this.LinesOfCodePie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LinesOfCodePie.InitialAngle = 0F;
            this.LinesOfCodePie.Location = new System.Drawing.Point(0, 0);
            this.LinesOfCodePie.Name = "LinesOfCodePie";
            this.LinesOfCodePie.Size = new System.Drawing.Size(470, 403);
            this.LinesOfCodePie.TabIndex = 0;
            this.LinesOfCodePie.ToolTips = null;
            // 
            // TestCodePie
            // 
            this.TestCodePie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestCodePie.InitialAngle = 0F;
            this.TestCodePie.Location = new System.Drawing.Point(0, 0);
            this.TestCodePie.Name = "TestCodePie";
            this.TestCodePie.Size = new System.Drawing.Size(479, 407);
            this.TestCodePie.TabIndex = 0;
            this.TestCodePie.ToolTips = null;
            // 
            // CommitCountPie
            // 
            this.CommitCountPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommitCountPie.InitialAngle = 0F;
            this.CommitCountPie.Location = new System.Drawing.Point(0, 0);
            this.CommitCountPie.Name = "CommitCountPie";
            this.CommitCountPie.Size = new System.Drawing.Size(447, 400);
            this.CommitCountPie.TabIndex = 0;
            this.CommitCountPie.ToolTips = null;
            // 
            // FormGitStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 465);
            this.Controls.Add(this.LoadingLabel);
            this.Controls.Add(this.Tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGitStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Statistics";
            this.Shown += new System.EventHandler(this.FormGitStatisticsShown);
            this.Tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel1.PerformLayout();
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel1.PerformLayout();
            this.splitContainer8.Panel2.ResumeLayout(false);
            this.splitContainer8.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private PieChartControl LinesOfCodePie;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PieChartControl LinesOfCodeExtensionPie;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label TotalLinesOfCode;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label TotalCommits;
        private PieChartControl CommitCountPie;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label CommitStatistics;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label TotalLinesOfCode2;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Label LinesOfCodePerTypeText;
        private System.Windows.Forms.Label LinesOfCodePerLanguageText;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Label TotalLinesOfTestCode;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private PieChartControl TestCodePie;
        private System.Windows.Forms.Label TestCodeText;
        private System.Windows.Forms.Label LoadingLabel;
    }
}