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

        public string selectedFilePath;
        private static ListFrame _instance;

        //Singleton ensuring only a single instance of a frame can be opened at a time
        public static ListFrame GetInstance() {

            if (_instance == null) _instance = new ListFrame();
            return _instance;
        }

        public ListFrame()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Work Directory" }) {

                if (fbd.ShowDialog() == DialogResult.OK) {
                    fileBrowser.Url = new Uri(fbd.SelectedPath);
                    txtfilePath.Text = fbd.SelectedPath;
                    selectedFilePath = fbd.SelectedPath;
                }
            }
        }

        private void fileBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void ListFrame_Load(object sender, EventArgs e)
        {


        }

        public string GetSelectedFilePath() {
            return selectedFilePath;
        }
    }
}
