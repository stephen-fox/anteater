using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Messaging;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anteater
{
    public partial class EventViewerForm : Form
    {
        public EventViewerForm()
        {
            InitializeComponent();
        }

        public static string gstrCurrentFilepath;
        public static bool gboolFileIsOpen;
        // Create an Open file dialog so the user can select a log file to view.
        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //http://www.c-sharpcorner.com/uploadfile/mahesh/openfiledialog-in-C-Sharp/
            string userPath = Environment.GetFolderPath
                (Environment.SpecialFolder.UserProfile);
            string userPathFinal;
            if (String.IsNullOrEmpty(userPath))
            {
                userPathFinal = @"C:\";
            }
            else
            {
                userPathFinal = userPath + @"\Desktop";
            }
            OpenFileDialog openLogFileDialog = new OpenFileDialog();
            openLogFileDialog.InitialDirectory = userPathFinal;
            openLogFileDialog.Title = "Browse Log Files";
            openLogFileDialog.DefaultExt = "log";
            openLogFileDialog.Filter = "Log Files (.log|*.log|All Files (*.*)|*.*";
            openLogFileDialog.FilterIndex = 1;
            openLogFileDialog.RestoreDirectory = true;
            openLogFileDialog.CheckFileExists = true;
            openLogFileDialog.CheckPathExists = true;
            openLogFileDialog.Multiselect = false;

            if (openLogFileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearFormView();
                OpenFile(openLogFileDialog.FileName);
            }
        }

        // Make sure the file exists. If it does, then call ParseFile.
        private void OpenFile(string filePath)
        {
            if (!String.IsNullOrEmpty(filePath)
                && File.Exists(filePath))
            {
                gstrCurrentFilepath = filePath;
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += (ob, evArgs) => ParseFile(gstrCurrentFilepath);
                bgw.RunWorkerAsync();
                this.Text = "Anteater - " + Path.GetFileName(gstrCurrentFilepath);
            }
            else
            {
                MessageBox.Show("Unable to open the selected file. Please try again.");
            }
        }

        // Do things when a node in the treeView is selected by the user.
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (!String.IsNullOrEmpty(selectedNode.Text) 
                && treeView.SelectedNode.Tag != null)
            {
                msgContentTextBox.Text = selectedNode.Text;
                msgContentTextBox.BackColor = selectedNode.BackColor;
                msgContentGroupBox.Text = "Content of " +  "\""
                                        + selectedNode.Tag.ToString()
                                        + "\"" + "-type Message:";
            }
            else
            {
                msgContentTextBox.Clear();
                msgContentTextBox.BackColor = Color.Empty;
                msgContentGroupBox.Text = "Message Content:";
            }
        }

        // Open the Settings form when the Options button is clicked.
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            // Open the form. If the form's result is OK, then try to
            // refresh the form view.
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                RefreshFormView();
            }
        }

        // Remove all nodes from the treeView and reset flags becuase 
        // the user asked nicely.
        private void closeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearFormView();
            this.Text = "Anteater";
            gstrCurrentFilepath = null;
            gboolFileIsOpen = false;
        }

        // Refreshes the main view in certain situations.
        private void RefreshFormView()
        {
            if (!String.IsNullOrEmpty(gstrCurrentFilepath)
                && File.Exists(gstrCurrentFilepath)
                && gboolFileIsOpen == true)
            {
                ClearFormView();
                OpenFile(gstrCurrentFilepath);
            }
        }

        // Clears common controls in the form.
        private void ClearFormView()
        {
            msgContentGroupBox.Text = "Message Content:";
            msgContentTextBox.Clear();
            msgContentTextBox.BackColor = Color.Empty;
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            treeView.EndUpdate();
        }

        // Read through the log file and create nodes.
        private void ParseFile(string filePath)
        {
            FileStream logFileStream = new FileStream(filePath, FileMode.Open, 
                                           FileAccess.Read, FileShare.ReadWrite);
            StreamReader LogFile = new StreamReader(logFileStream);
            
            int lineCount = File.ReadLines(filePath).Count();
            int lineNumber = 0;
            string[] messageTypes = MessageInfo.getMsgTypes();
            string[] importantMsgs = MessageInfo.getInterestingMsgs();
            CreateCategoryNodes(messageTypes);
            while (!LogFile.EndOfStream)
            {
                lineNumber = lineNumber + 1;
                string msgText = LogFile.ReadLine();
                string msgType = Message.setMsgType(msgText, messageTypes);
                bool msgIsInteresting = Message.isInteresting(msgText, importantMsgs);
                CreateMsgNode(lineCount, lineNumber, msgText, 
                                msgType, msgIsInteresting);
            }
            LogFile.Close();
            gboolFileIsOpen = true;
        }

        // Create category nodes so that we can categorize log messages.
        private void CreateCategoryNodes(string[] msgTypes)
        {
            foreach (string typeText in msgTypes)
            {
                TreeNode typeNode = new TreeNode(typeText);
                typeNode.Name = typeNode.Text;
                typeNode.Tag = null;
                AuditNodeBuffer(typeNode, 1, 2);
            }
            TreeNode fullLogNode = new TreeNode("All Log Messages");
            fullLogNode.Name = fullLogNode.Text;
            fullLogNode.Tag = null;
            // Give junk lineNumber and lineCount. We only want to add
            // to the buffer, not add to and dump the buffer!
            AuditNodeBuffer(fullLogNode, 1, 2);
        }
        
        // Create nodes for individual log messages.
        private void CreateMsgNode(int lineCount, int lineNumber, string msgText,
                                     string msgType, bool msgIsInteresting)
        {
            string msgNodeText = "Line " + lineNumber + ": " + msgText;
            TreeNode messageNode = new TreeNode(msgNodeText);
            messageNode.Name = messageNode.Text;
            if (msgIsInteresting == true)
            {
                // Color the node if it is important.
                messageNode.BackColor = Color.Yellow;
            }
            string allLogMsgs = "All Log Messages";
            if (!String.IsNullOrEmpty(msgType))
            {
                // If the message has a msgType, tag the node with the msgType
                // node name.
                messageNode.Tag = msgType;
            }
            else
            {
                // If the message does not have a msgType, then tag it with
                // the node name for all log messages.
                messageNode.Tag = allLogMsgs;
            }
            // Add the message to the buffer.
            AuditNodeBuffer(messageNode, lineNumber, lineCount);
        }

        // Create a TreeNode List and use it as a buffer for nodes.
        List<TreeNode> nodeBuffer = new List<TreeNode>(1000);
        // Add the requested node to the buffer. Dump the buffer onto the UI
        // in certain situations.
        private void AuditNodeBuffer(TreeNode node, int lineNumber, int lineCount)
        {
            nodeBuffer.Add(node);
            if (nodeBuffer.Count == nodeBuffer.Capacity || lineNumber == lineCount)
            {
                TreeNode[] nodeDump = nodeBuffer.ToArray();
                nodeBuffer.Clear();
                UpdateTreeView(nodeDump);
            }
        }

        // Add the requested nodes to the tree.
        private void UpdateTreeView(TreeNode[] nodeBuffer)
        {
            string allMsgsNode = "All Log Messages";
            Invoke(new Action(() =>
            {
                treeView.BeginUpdate();
                foreach (TreeNode node in nodeBuffer)
                {
                    if (node.Tag == null)
                    {
                        // If the tag is null, then just slap it into the
                        // treeView as a root node.
                        treeView.Nodes.Add(node);
                    }
                    else
                    {
                        string parentNode = node.Tag.ToString();
                        if (parentNode.Equals(allMsgsNode))
                        {
                            // If the node's tag is the all messages category,
                            // then add it to that node.
                            treeView.Nodes[parentNode].Nodes.Add(node);
                        }
                        else
                        {
                            // If the node's tag is not the all messages
                            // category, then add a clone of the node to the
                            // specified node in the tag. Add the original node
                            // to the all messages node.
                            TreeNode clonedNode = (TreeNode) node.Clone();
                            treeView.Nodes[parentNode].Nodes.Add(clonedNode);
                            treeView.Nodes[allMsgsNode].Nodes.Add(node);
                        }

                    }
                }
                treeView.ShowNodeToolTips = false;
                treeView.EndUpdate();
            }));
            System.Threading.Thread.Sleep(100);
        }
    }
}
