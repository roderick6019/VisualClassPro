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

        private void button1_Click(object sender, EventArgs e)
        {
            SummaryFrame summaryFrameCaller = new SummaryFrame();
            summaryFrameCaller.Show(this);
        }

        private void panel2_Paint(object sender, PaintEventArgs e) //I don't know what the fuck is supposed to happen here
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //once analysis button is clicked, analysis form will open 
        private void AnalysisButton_Click(object sender, EventArgs e)
        {
            AnalysisFrame analysisFrameCaller = new AnalysisFrame();
            analysisFrameCaller.Show(this);
        }

        //Once button is clicked, list form will be called
        private void ListButton_Click(object sender, EventArgs e) 
        {
            ListFrame listFrameCaller = new ListFrame();
            listFrameCaller.Show(this);
        }
    }
}
