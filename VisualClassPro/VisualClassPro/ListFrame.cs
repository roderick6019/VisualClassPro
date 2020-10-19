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

namespace VisualClassPro
{
    public partial class ListFrame : Form
    {

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

        private void ListFrame_Load(object sender, EventArgs e)
        {
            fileListBox.Items.Clear(); //Always clear items in box

            string path = "C:/Users/Roderick Ramirez/Documents/Github/VisualClassPro/VisualClassPro/VisualClassPro/Resources/SamplePath"; //samplePath
            DirectoryInfo dInfo = new DirectoryInfo(path);

            FileInfo[] files = dInfo.GetFiles("*.txt"); //Getting all files with txt extension

            fileListBox.Items.AddRange(files);
            
        }
    }
}
