﻿namespace GitUI.Tag
{
    partial class FormDeleteTag
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
            this.Ok = new System.Windows.Forms.Button();
            this.Tags = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteTag = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.ForeColor = System.Drawing.Color.Black;
            this.Ok.Location = new System.Drawing.Point(369, 10);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 8;
            this.Ok.Text = "Delete";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.OkClick);
            // 
            // Tags
            // 
            this.Tags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tags.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Tags.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Tags.FormattingEnabled = true;
            this.Tags.Location = new System.Drawing.Point(126, 12);
            this.Tags.Name = "Tags";
            this.Tags.Size = new System.Drawing.Size(237, 23);
            this.Tags.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select tag";
            // 
            // deleteTag
            // 
            this.deleteTag.AutoSize = true;
            this.deleteTag.Location = new System.Drawing.Point(126, 41);
            this.deleteTag.Name = "deleteTag";
            this.deleteTag.Size = new System.Drawing.Size(131, 19);
            this.deleteTag.TabIndex = 11;
            this.deleteTag.Text = "Delete tag from \'{0}\'";
            this.deleteTag.UseVisualStyleBackColor = true;
            // 
            // FormDeleteTag
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(454, 72);
            this.Controls.Add(this.deleteTag);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Tags);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 110);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 110);
            this.Name = "FormDeleteTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delete tag";
            this.Load += new System.EventHandler(this.FormDeleteTagLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.ComboBox Tags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox deleteTag;
    }
}