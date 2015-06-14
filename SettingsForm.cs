using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anteater
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            string[] messageTypes = MessageInfo.getMsgTypes();

        }

        //
        private void saveSettingsButton_Click(object sender, EventArgs e)
        {

        }

        //
        private void cancelSettingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
