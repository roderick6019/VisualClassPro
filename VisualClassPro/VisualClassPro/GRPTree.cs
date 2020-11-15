using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualClassPro
{
    public partial class GRPTree : Form
    {
        public GRPTree()
        {
            InitializeComponent();
        }

        private void GRPTree_Load(object sender, EventArgs e)
        {
            Main mainFrame = new Main();
            List<string> fileNames = mainFrame.ReadGRPFile();

            foreach (string s in fileNames) {
                treeGRP.Nodes.Add(s);
            }
        }
    }
}
