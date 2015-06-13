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
using System.Windows;

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
                clearTreeView();
                string filePath = openLogFileDialog.FileName;
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += (ob, evArgs) => ParseFile(filePath);
                bgw.RunWorkerAsync();
            }
        }

        // Remove all nodes from the treeView becuase the user asked nicely.
        private void closeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearTreeView();
        }

        // Clears the treeView control of all nodes.
        private void clearTreeView()
        {
            Invoke(new Action(() =>
            {
                treeView.BeginUpdate();
                treeView.Nodes.Clear();
                treeView.EndUpdate();
            }));
        }

        // Read through the log file and create nodes.
        private void ParseFile(string inputfile)
        {
            FileStream logFileStream = new FileStream(inputfile, FileMode.Open, 
                FileAccess.Read, FileShare.ReadWrite);
            StreamReader LogsFile = new StreamReader(logFileStream);
            
            int lineCount = File.ReadLines(inputfile).Count();
            int lineNumber = 0;
            string[] msgTypes = MessageTypes.availableMsgTypes();
            CreatePrimaryNodes(msgTypes);
            while (!LogsFile.EndOfStream)
            {
                lineNumber = lineNumber + 1;
                string msgText = LogsFile.ReadLine();
                string msgType = MessageTypes.msgType(msgText, msgTypes);
                CreateMsgNode(lineCount, lineNumber, msgText, msgType);
            }
        }

        // Create a list for primary nodes.
        List<TreeNode> primaryMsgsQueue = new List<TreeNode>();

        // Create primary nodes so that we can categorize log messages.
        private void CreatePrimaryNodes(string[] msgTypes)
        {
            foreach (string type in msgTypes)
            {
                TreeNode typeNode = new TreeNode(type);
                typeNode.Name = type;
                primaryMsgsQueue.Add(typeNode);
            }
            TreeNode fullLog = new TreeNode("All Log Messages");
            // If this breaks, then it used to be "All Log Messages"
            fullLog.Name = fullLog.Text;
            primaryMsgsQueue.Add(fullLog);
            UpdateTreeView(primaryMsgsQueue.ToArray(), null, null);
            primaryMsgsQueue.Clear();
        }

        // Create a list for new nodes and use it as a buffer.
        List<TreeNode> allMsgsQueue = new List<TreeNode>(1000);

        // Add nodes to the treeView.
        private void CreateMsgNode(int lineCount, int lineNumber, 
            string msgText, string msgType)
        {
            TreeNode messageNode = new TreeNode(msgText);
            if (!String.IsNullOrEmpty(msgType))
            {
                UpdateTreeView(null, msgType, msgText);
            }

            allMsgsQueue.Add(messageNode);
            if (allMsgsQueue.Count == 1000 || lineNumber == lineCount)
            {
                // Dump the buffer for all messages.
                string parentNode = "All Log Messages";
                TreeNode[] nodeBuffer = allMsgsQueue.ToArray();
                UpdateTreeView(nodeBuffer, parentNode, null);
                allMsgsQueue.Clear();
            }
        }

        // Add the requested nodes to the tree.
        private void UpdateTreeView(TreeNode[] multipleNodes, string parentNode, 
            string singleNode)
        {
            Invoke(new Action(() =>
            {
                treeView.BeginUpdate();
                if (multipleNodes != null && parentNode == null)
                {
                    // For situations where we need to add nodes directly
                    // to the treeView.
                    treeView.Nodes.AddRange(multipleNodes);
                }
                else if (multipleNodes != null && parentNode != null)
                {
                    // For situtations where we need to add multiple
                    // nodes to a parent node.
                    treeView.Nodes[parentNode].Nodes.AddRange(multipleNodes);
                }
                else if (singleNode != null && parentNode != null)
                {
                    // For sitatuions where we need to add a single
                    // node to a parent node.
                    treeView.Nodes[parentNode].Nodes.Add(singleNode);
                }
                treeView.EndUpdate();
            }));
            System.Threading.Thread.Sleep(100);
        }
    }
}
