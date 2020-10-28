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
        public string filePath;
        bool showMessage;

        public Main() {
            filePath = string.Empty; //initialize fileName as empty string
            showMessage = true; //used to show reminder that all course csv files must be in the same directory
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
                MessageBox.Show("It is required that all files for sections are stored in the same directory in order for the program to function correctly.", "Warning" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                showMessage = false;
            }
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV|*.csv"; //filtering out all files except csv file
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = ofd.FileName;
                //Console.WriteLine(fileName);
                txtPathLabel.Text = GetFileName();//fileName;
                MessageBox.Show(filePath);
                GetSectionGrades().ForEach(Console.WriteLine);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void txtPathLabel_Click(object sender, EventArgs e) {

        }

        //Function returning array of string with rows of input CSV files
        public string[] ReadCSVFile() {

            string[] lines = { };

            try { 
                lines = System.IO.File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] columns = line.Split(','); //separate by commas
                    foreach (string column in columns)
                    {
                        string[] items = column.Split(','); //TESTING: Just to see what function picks up
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show("Error encountered: " + e.ToString());
            }

            return lines;
        }

        //since path is returned and are too long for txtPathLabel, file name will be returned 
        public string GetFileName()
        {
            string[] directories = filePath.Split('\\');
            return directories[directories.Length - 1];
        }

        //returns list of grades specificed by chosen file from open file dialog
        public List<string> GetSectionGrades() {
            string[] students = ReadCSVFile();
            List<string> grades = new List<string>();

            int rowCounter = 0; //used to ignore first row which consists of the name of the section
            
            foreach (string item in students) {
                if (rowCounter > 0) {
                    string[] studentItems = item.Split(',');
                    grades.Add(studentItems[3]); //index in studentItems array which consists of grade 
                }
                rowCounter++;
            }
            return grades;
        }
    }
}
