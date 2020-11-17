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
    public partial class Main : Form
    {
        private string filePath;
        private string grpFilePath;
        private double cumulativeGPA;
        private double overallStdev;
        private double z;
        //static List<string> fileGroup;

        public Main() {
            filePath = string.Empty; //initialize fileName as empty string
            grpFilePath = string.Empty;
            cumulativeGPA = 0;
            overallStdev = 0;
            z = 0; 
            InitializeComponent();
        }

        //Summary Frame button
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(filePath == string.Empty))
            {
                MessageBox.Show("Average GPA for " + GetFileName(filePath) + ": " + CalculateGPA(GetSectionGrades(filePath)).ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a section CSV.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //once analysis button is clicked, analysis form will open 
        private void AnalysisButton_Click(object sender, EventArgs e)
        {
            if (!(cumulativeGPA == 0) && filePath != string.Empty && grpFilePath != string.Empty)
            {
                MessageBox.Show(GetFileName(filePath) + " GPA: " + CalculateGPA(GetSectionGrades(filePath)) + "\n" + "Cumulative GPA: " + Math.Round(cumulativeGPA,2) + "\nStandard Deviation: " + overallStdev + "\n" + ComputeZTest());
            }
            else {
                MessageBox.Show("Please select a CSV file and GRP file to analyze", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Once button is clicked, list form will be called. 
        private void ListButton_Click(object sender, EventArgs e) 
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV|*.csv"; //filtering out all files except csv file
            ofd.RestoreDirectory = true;
            ofd.Title = "Select Section";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = ofd.FileName;
                if (grpFilePath == string.Empty) {
                    txtPathLabel.Text = GetFileName(filePath);
                }
                else{
                    txtPathLabel.Text = GetFileName(filePath) + " " + "|" + " " + GetFileName(grpFilePath); //checking if get grpfilepath is empty in order to format path label accordingly
                }
                ComputeGroupAverage();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void txtPathLabel_Click(object sender, EventArgs e) {

        }

        //Function returning array of string with rows of input CSV files
        public string[] ReadCSVFile(string path) {

            string[] lines = { };

            try { 
                lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] columns = line.Split(','); //separate by commas
                    foreach (string column in columns)
                    {
                        string[] items = column.Split(',');
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show("Error encountered: " + e.ToString());
            }

            return lines;
        }

        //since path is returned and are too long for txtPathLabel, file name will be returned 
        public string GetFileName(string path)
        {
            string[] directories = path.Split('\\');
            return directories[directories.Length - 1];
        }

        //returns list of grades specificed by chosen file from open file dialog
        public string[] GetSectionGrades(string path) {
            string[] students = ReadCSVFile(path);
            string[] gradesTest = new string[students.Length];

            int rowCounter = 0; //used to ignore first row which consists of the name of the section
            
            foreach (string item in students) {
                if (rowCounter > 0) {
                    Console.WriteLine(item);
                    string[] studentItems = item.Split(',');
                    gradesTest[rowCounter] = studentItems[3];
                }
                rowCounter++;
            }
            return gradesTest;
        }

        //Function reading grp files which returns all sections to be compared. PURPOSE OF GRP FILES IS TO BE DETERMINED
        public List<string> ReadGRPFile() {
            List<string> fileNames = new List<string>();
            bool ignoreTitle = true;

            try
            {
                string[] rows = System.IO.File.ReadAllLines(grpFilePath);

                foreach (string file_name in rows)
                {
                    if (!ignoreTitle) {
                        fileNames.Add(file_name); //Add file names to list
                    }
                    ignoreTitle = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error encountered: " + e.ToString());
            }

            return fileNames;
        }

        //Returns neatly formated string to show on message box after grp file has been selected
        private string GRPToString() {
            List<string> fileNames = ReadGRPFile();
            string result = "";
            foreach (string s in fileNames) {
                result += (s + "\n");
            }

            return result;
        }

        //Calculate GPA from a given list of grades
        public double CalculateGPA(string[] grades) {

            double gpa = 0;
            //Dictionary with grades as keys and their respective values as values in a 4.0 GPA scale 
            var gradePoints = new Dictionary<string, double> {
                { "A", 4.0},
                { "A-", 3.7},
                { "B+", 3.3},
                { "B", 3.0},
                { "B-", 2.7},
                { "C+", 2.3},
                { "C", 2.0},
                { "C-", 1.7},
                { "D+", 1.3},
                { "D", 1.0},
                { "D-", 0.7},
                { "F", 0.0}};

            foreach (string grade in grades) {
                foreach (KeyValuePair<string, double> pair in gradePoints) {
                    if (grade == pair.Key) {
                        gpa += pair.Value; //multiply by 3 due to comsc credit courses is 3.0
                    }
                }
            }
            return Math.Round(gpa/grades.Length, 2);
        }

        //function takes file specified by grp files and attempts to find them in the user's drive
        private void ComputeGroupAverage() {

            string path = "C:\\Users\\Roderick Ramirez\\Documents\\University\\JuniorSemesterOne\\COMSC.330\\Project\\TestingData";
            int fileCount = 0;
            string[] files = Directory.GetFiles(path);
            List<double> stdevList = new List<double>(); 
            
            foreach (string f in files) {
                if (!(f[f.Length - 1].Equals('P'))) //filter out grp files
                { 
                    //Console.WriteLine(GetFileName(f) + " " + CalculateGPA(GetSectionGrades(f)));
                    stdevList.Add(CalculateGPA(GetSectionGrades(f)));
                    cumulativeGPA += CalculateGPA(GetSectionGrades(f));
                    fileCount++;
                }
            }
            
            cumulativeGPA /= fileCount;
            overallStdev = StandardDeviation(stdevList);
            z = (CalculateGPA(GetSectionGrades(filePath)) - cumulativeGPA) / overallStdev;

        }

        //Function calculation standard deviation of a given list (used to calculate stdev of selected group)
        private double StandardDeviation(List<double> numList) {

            double temp = 0;

            
            foreach (double num in numList) {
                temp += Math.Pow(num - cumulativeGPA, 2);
            }
            
            temp /= (numList.Count);
            temp = Math.Sqrt(temp);
            return Math.Round(temp, 3);
        }

        //Function computing z-test and returning string messaging whether or not selected section is significantly different than overall section
        private string ComputeZTest() {
            string message = string.Empty;
            if (z > 2 || z < -2)
            {
                message = GetFileName(filePath) + " is signifcantly different than " + GetFileName(grpFilePath + " with z-value of " + Math.Round(z,2));
            }
            else {
                message = GetFileName(filePath) + " is not signifcantly different than " + GetFileName(grpFilePath + " with z-value of " + Math.Round(z, 2));
            }

            return message;
        }

        //Once button is pressed, file dialog will allow the user to select a grp file in order to start sections analysis
        private void btnSelectGRP_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "GRP|*.grp"; //filtering out all files except .grp file
            ofd.RestoreDirectory = true;
            ofd.Title = "Select Section GRP";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                grpFilePath = ofd.FileName;
                if (filePath == string.Empty)
                {
                    txtPathLabel.Text = GetFileName(grpFilePath);
                }
                else {
                    txtPathLabel.Text = GetFileName(filePath) + " " + "|" + " " + GetFileName(grpFilePath); //checking if filepath is empty in order to format label string accordingly
                }
                
                MessageBox.Show("Sections in " + GetFileName(grpFilePath) + ": \n" + GRPToString());
            }

            //new GRPTree().Show();
        }

        private void treeBtn_Click(object sender, EventArgs e)
        {
            //new GRPTree().Show();
        }
    }
}
