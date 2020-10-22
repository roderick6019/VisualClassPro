using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace VisualClassPro
{
    public partial class ListFrame : Form
    {
        string[] files;
        Manager manager;

        public ListFrame() {
            InitializeComponent();
            manager = new Manager();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e) 
        {

            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Work Directory" }) {

                if (fbd.ShowDialog() == DialogResult.OK) {

                    files = Directory.GetFiles(fbd.SelectedPath);
                    fileBrowser.Url = new Uri(fbd.SelectedPath);
                    txtfilePath.Text = fbd.SelectedPath;
                }
            }


        }

        private void fileBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void ListFrame_Load(object sender, EventArgs e)
        {


        }
        
        private void frontBtn_Click(object sender, EventArgs e)
        {
            if (fileBrowser.CanGoForward) {
                fileBrowser.GoForward();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (fileBrowser.CanGoBack) {
                fileBrowser.GoBack();
            }
        }

        private void selectFilebtn_Click(object sender, EventArgs e)
        {
            //try catch in case user selects file without browsing first
            try
            {
                manager.SetFilePath(files[0]);
            }
            catch (Exception f) {
                MessageBox.Show("Please select a file");
            }
               
        }   
    }
}
