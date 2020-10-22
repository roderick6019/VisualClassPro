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
        
        public Main() {
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

        public void label1_Click(object sender, EventArgs e)
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
            if (Application.OpenForms.Count == 1) {
                new ListFrame().Show(); //Create a new instance every time form is opened    
            }            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        public void SetPathLabelValue(string value) {
            
        }
    }
}
