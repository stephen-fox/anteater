using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace Anteater
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            string[] messageTypes = MessageInfo.getMsgTypes();
            string[] interestingMsgs = MessageInfo.getInterestingMsgs();
            msgTypesTextBox.Lines = messageTypes;
            interestingMsgsTextBox.Lines = interestingMsgs;
        }

        // Save the settings.
        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            var mtSettings = settings.messageTypes;
            string[] updatedMsgTypes = msgTypesTextBox.Lines;
            mtSettings.Clear();
            foreach (string mt in updatedMsgTypes)
            {
                if (!String.IsNullOrEmpty(mt))
                {
                    mtSettings.Add(mt);
                }
            }
            var imSettings = settings.interestingStrings;
            string[] updatedInterestingMsgs = interestingMsgsTextBox.Lines;
            imSettings.Clear();
            foreach (string im in updatedInterestingMsgs)
            {
                if (!String.IsNullOrEmpty(im))
                {
                    imSettings.Add(im);
                }
            }
            settings.Save();
            this.Close();
        }

        // Do not save settings. Just close the form.
        private void cancelSettingsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
