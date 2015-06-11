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

        // Open file dialog creation.
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

        private void ParseFile(string inputfile)
        {
            FileStream logFileStream = new FileStream(inputfile, FileMode.Open, 
                FileAccess.Read, FileShare.ReadWrite);
            StreamReader LogsFile = new StreamReader(logFileStream);
            
            var lineCount = File.ReadLines(inputfile).Count();
            int lineNumber = 0;
            string[] msgTypes = MessageTypes.availableMsgTypes();
            while (!LogsFile.EndOfStream)
            {
                lineNumber = lineNumber + 1;
                string msgText = LogsFile.ReadLine();
                //TODO: Actually write this class.
                //Message msg = new Message(Msgtxt.Substring(26)); 
                    //Reads the text into a class with appropriate members
                AddTreeViewNode(lineCount, lineNumber, msgText);
            }
        }

        // Create a list and use it as a buffer for nodes.
        List<TreeNode> nodeQueue = new List<TreeNode>(1000);
        private void AddTreeViewNode(int lineCount, int lineNumber, string msgText)
        {
            TreeNode newNode = new TreeNode(msgText);
            
            nodeQueue.Add(newNode);
            if (nodeQueue.Count == 1000)
            {
                // Dump the buffer if it hits its limit.
                DumpNodeBuffer();
            }
            else if (lineNumber == lineCount)
            {
                // Dump the buffer if it we hit the end of the file.
                DumpNodeBuffer();
            }
        }

        // Dump the buffer onto the treeView.
        private void DumpNodeBuffer()
        {
            var buffer = nodeQueue.ToArray();
            nodeQueue.Clear();
            Invoke(new Action(() =>
            {
                treeView1.BeginUpdate();
                treeView1.Nodes.AddRange(buffer);
                treeView1.EndUpdate();
            }));
            System.Threading.Thread.Sleep(500);
        }
    }
}
