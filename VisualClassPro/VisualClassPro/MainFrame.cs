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
    public partial class Main : Form
    {

        string fileName;
        bool showMessage;

        public Main() {
            fileName = "";
            showMessage = true;
            InitializeComponent();
        }

        //Summary Frame button
        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                new SummaryFrame().Show();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //once analysis button is clicked, analysis form will open 
        private void AnalysisButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1) //checking count will allow for just one additional form to be opened. This help preven cluttering of forms
            {
                new AnalysisFrame().Show();
            }
        }

        //Once button is clicked, list form will be called. 
        private void ListButton_Click(object sender, EventArgs e) 
        {
            if (showMessage == true) {
                MessageBox.Show("It is required that all files for sections are stored in the same directory");
                showMessage = false;
            }
            
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                fileName = ofd.FileName; MessageBox.Show(fileName);
                txtPathLabel.Text = fileName;
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        public void SetPathLabelValue(string value) {
            
        }

        private void txtPathLabel_Click(object sender, EventArgs e) {

        }
    }
}
