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
    public partial class eventViewerForm : Form
    {
        public eventViewerForm()
        {
            InitializeComponent();
        }

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
                clearFormView();
                string filePath = openLogFileDialog.FileName;
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += (ob, evArgs) => ParseFile(filePath);
                bgw.RunWorkerAsync();
            }
        }

        // Remove all nodes from the treeView becuase the user asked nicely.
        private void closeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearFormView();
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
                msgContentsLabel.Text = "Content of " +  "\""
                                        + selectedNode.Tag.ToString()
                                        + "\"" + "-type Message:";
            }
            else
            {
                msgContentTextBox.Clear();
                msgContentTextBox.BackColor = Color.Empty;
                msgContentsLabel.Text = "Message Content:";
            }
        }

        // Read through the log file and create nodes.
        private void ParseFile(string inputfile)
        {
            FileStream logFileStream = new FileStream(inputfile, FileMode.Open, 
                                           FileAccess.Read, FileShare.ReadWrite);
            StreamReader LogsFile = new StreamReader(logFileStream);
            
            int lineCount = File.ReadLines(inputfile).Count();
            int lineNumber = 0;
            string[] messageTypes = MessageInfo.getMsgTypes();
            string[] importantMsgs = MessageInfo.getImportantMsgs();
            CreateCategoryNodes(messageTypes);
            while (!LogsFile.EndOfStream)
            {
                lineNumber = lineNumber + 1;
                string msgText = LogsFile.ReadLine();
                string msgType = MessageInfo.setMsgType(msgText, messageTypes);
                bool msgImportance = MessageInfo.isImportant(msgText, importantMsgs);
                CreateMsgNode(lineCount, lineNumber, msgText, 
                                msgType, msgImportance);
            }
            LogsFile.Close();
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
                                     string msgType, bool msgImportance)
        {
            string msgNodeText = "Line " + lineNumber + ": " + msgText;
            TreeNode messageNode = new TreeNode(msgNodeText);
            messageNode.Name = messageNode.Text;
            if (msgImportance == true)
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

        // Clears common controls in the form.
        private void clearFormView()
        {
            msgContentsLabel.Text = "Message Content:";
            msgContentTextBox.Clear();
            msgContentTextBox.BackColor = Color.Empty;
            Invoke(new Action(() =>
            {
                treeView.BeginUpdate();
                treeView.Nodes.Clear();
                treeView.EndUpdate();
            }));
        }
    }
}
