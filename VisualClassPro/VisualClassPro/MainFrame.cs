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
        public Main()
        {
            InitializeComponent();
        }

        //Summary Frame button
        private void button1_Click(object sender, EventArgs e)
        {
            SummaryFrame summaryFrame = SummaryFrame.GetInstance();

            if (!summaryFrame.Visible && Application.OpenForms.Count == 1)
            {
                summaryFrame.Show();
            }
            else {
                summaryFrame.BringToFront();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //once analysis button is clicked, analysis form will open 
        private void AnalysisButton_Click(object sender, EventArgs e)
        {
            AnalysisFrame analysisFrame = AnalysisFrame.GetInstance();

            if (!analysisFrame.Visible && Application.OpenForms.Count == 1) //checking count will allow for just one additional form to be opened. This help preven cluttering of forms
            {
                analysisFrame.Show();
            }
            else {
                analysisFrame.BringToFront();
            }
        }

        //Once button is clicked, list form will be called. 
        private void ListButton_Click(object sender, EventArgs e) 
        {
            ListFrame listFrame = ListFrame.GetInstance();

            if (!listFrame.Visible && Application.OpenForms.Count == 1) //checking if form is already open. If other instance is opened, form will just be called to front instead.
            {
                listFrame.Show();
            }
            else {
                listFrame.BringToFront();
            }
        }
    }
}
