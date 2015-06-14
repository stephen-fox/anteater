namespace Anteater
{
    partial class EventViewerForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msgContentTextBox = new System.Windows.Forms.RichTextBox();
            this.msgContentsLabel = new System.Windows.Forms.Label();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(12, 34);
            this.treeView.Name = "treeView";
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(878, 443);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(902, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogToolStripMenuItem,
            this.closeLogToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.openLogToolStripMenuItem.Text = "Open Log";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // closeLogToolStripMenuItem
            // 
            this.closeLogToolStripMenuItem.Name = "closeLogToolStripMenuItem";
            this.closeLogToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.closeLogToolStripMenuItem.Text = "Close Log";
            this.closeLogToolStripMenuItem.Click += new System.EventHandler(this.closeLogToolStripMenuItem_Click);
            // 
            // msgContentTextBox
            // 
            this.msgContentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgContentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgContentTextBox.Location = new System.Drawing.Point(12, 498);
            this.msgContentTextBox.Name = "msgContentTextBox";
            this.msgContentTextBox.ReadOnly = true;
            this.msgContentTextBox.Size = new System.Drawing.Size(878, 70);
            this.msgContentTextBox.TabIndex = 2;
            this.msgContentTextBox.Text = "";
            // 
            // msgContentsLabel
            // 
            this.msgContentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.msgContentsLabel.AutoSize = true;
            this.msgContentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgContentsLabel.Location = new System.Drawing.Point(12, 480);
            this.msgContentsLabel.Name = "msgContentsLabel";
            this.msgContentsLabel.Size = new System.Drawing.Size(106, 15);
            this.msgContentsLabel.TabIndex = 3;
            this.msgContentsLabel.Text = "Message Content:";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // EventViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 580);
            this.Controls.Add(this.msgContentsLabel);
            this.Controls.Add(this.msgContentTextBox);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "EventViewerForm";
            this.Text = "Anteater";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeLogToolStripMenuItem;
        private System.Windows.Forms.RichTextBox msgContentTextBox;
        private System.Windows.Forms.Label msgContentsLabel;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}