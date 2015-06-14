namespace Anteater
{
    partial class SettingsForm
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
            this.displaySettingsBox = new System.Windows.Forms.GroupBox();
            this.msgTypesGroupBox = new System.Windows.Forms.GroupBox();
            this.logMsgTypesBox = new System.Windows.Forms.RichTextBox();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.interestingMsgsGroupBox = new System.Windows.Forms.GroupBox();
            this.interestingLogMsgsTextBox = new System.Windows.Forms.RichTextBox();
            this.msgTypesGroupBox.SuspendLayout();
            this.interestingMsgsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // displaySettingsBox
            // 
            this.displaySettingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.displaySettingsBox.Location = new System.Drawing.Point(13, 12);
            this.displaySettingsBox.Name = "displaySettingsBox";
            this.displaySettingsBox.Size = new System.Drawing.Size(466, 61);
            this.displaySettingsBox.TabIndex = 0;
            this.displaySettingsBox.TabStop = false;
            this.displaySettingsBox.Text = "Display Settings";
            // 
            // msgTypesGroupBox
            // 
            this.msgTypesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.msgTypesGroupBox.Controls.Add(this.logMsgTypesBox);
            this.msgTypesGroupBox.Location = new System.Drawing.Point(13, 79);
            this.msgTypesGroupBox.Name = "msgTypesGroupBox";
            this.msgTypesGroupBox.Size = new System.Drawing.Size(466, 150);
            this.msgTypesGroupBox.TabIndex = 1;
            this.msgTypesGroupBox.TabStop = false;
            this.msgTypesGroupBox.Text = "Log Message Types";
            // 
            // logMsgTypesBox
            // 
            this.logMsgTypesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logMsgTypesBox.Location = new System.Drawing.Point(6, 19);
            this.logMsgTypesBox.Name = "logMsgTypesBox";
            this.logMsgTypesBox.Size = new System.Drawing.Size(454, 125);
            this.logMsgTypesBox.TabIndex = 0;
            this.logMsgTypesBox.Text = "";
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelSettingsButton.AutoSize = true;
            this.cancelSettingsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelSettingsButton.Location = new System.Drawing.Point(399, 391);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(80, 25);
            this.cancelSettingsButton.TabIndex = 2;
            this.cancelSettingsButton.Text = "Cancel";
            this.cancelSettingsButton.UseVisualStyleBackColor = true;
            this.cancelSettingsButton.Click += new System.EventHandler(this.cancelSettingsButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingsButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveSettingsButton.Location = new System.Drawing.Point(313, 391);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(80, 25);
            this.saveSettingsButton.TabIndex = 2;
            this.saveSettingsButton.Text = "Save";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // interestingMsgsGroupBox
            // 
            this.interestingMsgsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.interestingMsgsGroupBox.Controls.Add(this.interestingLogMsgsTextBox);
            this.interestingMsgsGroupBox.Location = new System.Drawing.Point(13, 235);
            this.interestingMsgsGroupBox.Name = "interestingMsgsGroupBox";
            this.interestingMsgsGroupBox.Size = new System.Drawing.Size(466, 150);
            this.interestingMsgsGroupBox.TabIndex = 3;
            this.interestingMsgsGroupBox.TabStop = false;
            this.interestingMsgsGroupBox.Text = "Interesting Log Messages";
            // 
            // interestingLogMsgsTextBox
            // 
            this.interestingLogMsgsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interestingLogMsgsTextBox.Location = new System.Drawing.Point(6, 19);
            this.interestingLogMsgsTextBox.Name = "interestingLogMsgsTextBox";
            this.interestingLogMsgsTextBox.Size = new System.Drawing.Size(454, 125);
            this.interestingLogMsgsTextBox.TabIndex = 0;
            this.interestingLogMsgsTextBox.Text = "";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 425);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.interestingMsgsGroupBox);
            this.Controls.Add(this.cancelSettingsButton);
            this.Controls.Add(this.msgTypesGroupBox);
            this.Controls.Add(this.displaySettingsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.msgTypesGroupBox.ResumeLayout(false);
            this.interestingMsgsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox displaySettingsBox;
        private System.Windows.Forms.GroupBox msgTypesGroupBox;
        private System.Windows.Forms.RichTextBox logMsgTypesBox;
        private System.Windows.Forms.Button cancelSettingsButton;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.GroupBox interestingMsgsGroupBox;
        private System.Windows.Forms.RichTextBox interestingLogMsgsTextBox;

    }
}