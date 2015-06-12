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
                string filePath = openLogFileDialog.FileName;
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += (ob, evArgs) => ParseFile(filePath);
                bgw.RunWorkerAsync();
            }
        }

        // Read through the log file and add nodes.
        private void ParseFile(string inputfile)
        {
            FileStream logFileStream = new FileStream(inputfile, FileMode.Open, 
                FileAccess.Read, FileShare.ReadWrite);
            StreamReader LogsFile = new StreamReader(logFileStream);
            
            int lineCount = File.ReadLines(inputfile).Count();
            int lineNumber = 0;
            string[] msgTypes = MessageTypes.availableMsgTypes();
            AddPrimaryNodes(msgTypes);
            while (!LogsFile.EndOfStream)
            {
                lineNumber = lineNumber + 1;
                string msgText = LogsFile.ReadLine();
                string msgType = MessageTypes.msgType(msgText, msgTypes);
                AddMsgNode(lineCount, lineNumber, msgText, msgType);
            }
        }

        // Create a list for primary nodes.
        List<TreeNode> primaryMsgsQueue = new List<TreeNode>();

        // Create primary nodes so that we can categorize log messages.
        private void AddPrimaryNodes(string[] msgTypes)
        {
            foreach (string type in msgTypes)
            {
                TreeNode typeNode = new TreeNode(type);
                primaryMsgsQueue.Add(typeNode);
            }
            TreeNode fullLog = new TreeNode("All Log Messages");
            primaryMsgsQueue.Add(fullLog);
            var primaryNodes = primaryMsgsQueue.ToArray();
            UpdateTreeView(primaryNodes, null, null);
        }

        // Create a list for new nodes and use it as a buffer.
        List<TreeNode> allMsgsQueue = new List<TreeNode>(1000);

        // Add nodes to the treeView.
        private void AddMsgNode(int lineCount, int lineNumber, 
            string msgText, string msgType)
        {
            TreeNode messageNode = new TreeNode(msgText);
            if (!String.IsNullOrEmpty(msgType))
            {
                TreeNode[] parentNode = treeView1.Nodes.Find(msgType, false);
                UpdateTreeView(null, parentNode, messageNode);
            }

            allMsgsQueue.Add(messageNode);
            if (allMsgsQueue.Count == 1000 || lineNumber == lineCount)
            {
                // Dump the buffer.
                DumpAllMsgsBuffer();
            }
        }

        // Dump the buffer for all log messages onto the treeView.
        private void DumpAllMsgsBuffer()
        {
            string target = "All Log Messages";
            TreeNode[] parentNode = treeView1.Nodes.Find(target, false);
            var nodeBuffer = allMsgsQueue.ToArray();
            allMsgsQueue.Clear();
            UpdateTreeView(nodeBuffer, parentNode, null);
        }

        // Add the requested nodes to the tree.
        private void UpdateTreeView(TreeNode[] multipleNodes, TreeNode[] parentNode, 
            TreeNode singleNode)
        {
            Invoke(new Action(() =>
            {
                treeView1.BeginUpdate();
                if (multipleNodes != null && parentNode == null)
                {
                    // For situations where we need to add nodes directly
                    // to the treeView.
                    treeView1.Nodes.AddRange(multipleNodes);
                }
                else if (multipleNodes != null && parentNode != null)
                {
                    // For situtations where we need to add multiple
                    // nodes to a parent node.
                    //parentNode.Nodes.AddRange(multipleNodes);
                    foreach (var i in parentNode)
                    {
                        i.Nodes.AddRange(multipleNodes);
                    }
                }
                else if (singleNode != null && parentNode != null)
                {
                    // For sitatuions where we need to add a single
                    // node to a parent node.
                    //parentNode.Nodes.Add(singleNode);
                    foreach (var i in parentNode)
                    {
                        i.Nodes.Add(singleNode);
                    }
                }
                treeView1.EndUpdate();
            }));
            System.Threading.Thread.Sleep(500);
            //if (parentNode == null)
            //{
                // For situations where we need to add a lot of nodes to 
                // the treeView.
                //Invoke(new Action(() =>
                //{
                //    treeView1.BeginUpdate();
                //    if (parentNode != null)
                //    {
                //        // When we need to add multiple nodes to a target.
                //        parentNode.Nodes.AddRange(multipleNodes);
                //    }
                //    else if (multipleNodes != null)
                //    {
                //        // Or when we need to add multiple nodes to the 
                //        // general treeView.
                //        treeView1.Nodes.AddRange(multipleNodes);
                //    }
                //    treeView1.EndUpdate();
                //}));
                //System.Threading.Thread.Sleep(500);
            //}
            //else if (singleNode != null)
            //{
            //    Invoke(new Action(() =>
            //    {
            //        treeView1.BeginUpdate();
            //        parentNode.Nodes.Add(singleNode);
            //        treeView1.EndUpdate();
            //    }));
            //    System.Threading.Thread.Sleep(500);
            //}
        }
    }
}
