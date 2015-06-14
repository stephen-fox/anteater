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
            this.displaySettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.msgTypesGroupBox = new System.Windows.Forms.GroupBox();
            this.msgTypesTextBox = new System.Windows.Forms.TextBox();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.interestingMsgsGroupBox = new System.Windows.Forms.GroupBox();
            this.interestingMsgsTextBox = new System.Windows.Forms.TextBox();
            this.msgTypesGroupBox.SuspendLayout();
            this.interestingMsgsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // displaySettingsGroupBox
            // 
            this.displaySettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.displaySettingsGroupBox.Location = new System.Drawing.Point(13, 12);
            this.displaySettingsGroupBox.Name = "displaySettingsGroupBox";
            this.displaySettingsGroupBox.Size = new System.Drawing.Size(466, 61);
            this.displaySettingsGroupBox.TabIndex = 0;
            this.displaySettingsGroupBox.TabStop = false;
            this.displaySettingsGroupBox.Text = "Display Settings";
            // 
            // msgTypesGroupBox
            // 
            this.msgTypesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.msgTypesGroupBox.Controls.Add(this.msgTypesTextBox);
            this.msgTypesGroupBox.Location = new System.Drawing.Point(13, 79);
            this.msgTypesGroupBox.Name = "msgTypesGroupBox";
            this.msgTypesGroupBox.Size = new System.Drawing.Size(466, 150);
            this.msgTypesGroupBox.TabIndex = 1;
            this.msgTypesGroupBox.TabStop = false;
            this.msgTypesGroupBox.Text = "Log Message Categories";
            // 
            // msgTypesTextBox
            // 
            this.msgTypesTextBox.AcceptsReturn = true;
            this.msgTypesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgTypesTextBox.Location = new System.Drawing.Point(7, 20);
            this.msgTypesTextBox.Multiline = true;
            this.msgTypesTextBox.Name = "msgTypesTextBox";
            this.msgTypesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.msgTypesTextBox.Size = new System.Drawing.Size(453, 124);
            this.msgTypesTextBox.TabIndex = 1;
            this.msgTypesTextBox.TabStop = false;
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelSettingsButton.AutoSize = true;
            this.cancelSettingsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelSettingsButton.Location = new System.Drawing.Point(399, 391);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(80, 25);
            this.cancelSettingsButton.TabIndex = 4;
            this.cancelSettingsButton.TabStop = false;
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
            this.saveSettingsButton.TabIndex = 0;
            this.saveSettingsButton.Text = "Save";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // interestingMsgsGroupBox
            // 
            this.interestingMsgsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.interestingMsgsGroupBox.Controls.Add(this.interestingMsgsTextBox);
            this.interestingMsgsGroupBox.Location = new System.Drawing.Point(13, 235);
            this.interestingMsgsGroupBox.Name = "interestingMsgsGroupBox";
            this.interestingMsgsGroupBox.Size = new System.Drawing.Size(466, 150);
            this.interestingMsgsGroupBox.TabIndex = 3;
            this.interestingMsgsGroupBox.TabStop = false;
            this.interestingMsgsGroupBox.Text = "Terms to Highlight";
            // 
            // interestingMsgsTextBox
            // 
            this.interestingMsgsTextBox.AcceptsReturn = true;
            this.interestingMsgsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interestingMsgsTextBox.Location = new System.Drawing.Point(7, 20);
            this.interestingMsgsTextBox.Multiline = true;
            this.interestingMsgsTextBox.Name = "interestingMsgsTextBox";
            this.interestingMsgsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.interestingMsgsTextBox.Size = new System.Drawing.Size(453, 124);
            this.interestingMsgsTextBox.TabIndex = 2;
            this.interestingMsgsTextBox.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.saveSettingsButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelSettingsButton;
            this.ClientSize = new System.Drawing.Size(491, 425);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.interestingMsgsGroupBox);
            this.Controls.Add(this.cancelSettingsButton);
            this.Controls.Add(this.msgTypesGroupBox);
            this.Controls.Add(this.displaySettingsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.msgTypesGroupBox.ResumeLayout(false);
            this.msgTypesGroupBox.PerformLayout();
            this.interestingMsgsGroupBox.ResumeLayout(false);
            this.interestingMsgsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox displaySettingsGroupBox;
        private System.Windows.Forms.GroupBox msgTypesGroupBox;
        private System.Windows.Forms.Button cancelSettingsButton;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.GroupBox interestingMsgsGroupBox;
        private System.Windows.Forms.TextBox msgTypesTextBox;
        private System.Windows.Forms.TextBox interestingMsgsTextBox;

    }
}