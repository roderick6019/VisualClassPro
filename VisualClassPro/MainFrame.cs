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
        string path;
        List<string> checkedNodes;
        List<string> filesToRead;
        List<double> stdevList;
        Dictionary<string, double> sectionAverages; //stores section name along with respective section average

        public Main()
        {
            filePath = string.Empty; //initialize fileName as empty string
            grpFilePath = string.Empty;
            cumulativeGPA = 0;
            overallStdev = 0;
            path = "C:\\Users\\Roderick Ramirez\\Documents\\University\\JuniorSemesterOne\\COMSC.330\\Project\\TestingData";
            checkedNodes = new List<string>();
            filesToRead = new List<string>();
            stdevList = new List<double>();
            sectionAverages = new Dictionary<string, double>();
            InitializeComponent();
        }

        #region User Interaction (Buttons etc...)
        private void treeSelectBtn_Click(object sender, EventArgs e)
        {
            SelectCheckedNodes(grpTree.Nodes);
            grpTree.Hide();
            treeSelectBtn.Hide();
            FindFiles(checkedNodes).ForEach(Console.WriteLine);
            ComputeGroupAverage();
            ComputeZTest();
            //checkedNodes.ForEach(Console.WriteLine); //For testing purposes
        }

        //Summary Frame button
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(filePath == string.Empty))
            {
                //MessageBox.Show("Average GPA for " + GetFileName(filePath) + ": " + CalculateGPA(GetSectionGrades(filePath)).ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Average GPA for " + GetFileName(filePath) + ": " + CalculateGPA(GetSectionGrades(filePath)).ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //MessageBox.Show(GetFileName(filePath) + " GPA: " + CalculateGPA(GetSectionGrades(filePath)) + "\n" + "Cumulative GPA: " + Math.Round(cumulativeGPA,2) + "\nStandard Deviation: " + overallStdev + "\n" + ComputeZTest());
            }
            else
            {
                MessageBox.Show("Please select a CSV file and GRP file to analyze", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Once button is clicked, list form will be called. 
        private void ListButton_Click(object sender, EventArgs e)
        {
            ClearData();
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
                else
                {
                    txtPathLabel.Text = GetFileName(grpFilePath);
                }

                MessageBox.Show("Sections in " + GetFileName(grpFilePath) + ": \n" + GRPToString());

                GRPTreeHandler();
            }
        }

        private void txtPathLabel_Click(object sender, EventArgs e)
        {

        }
        #endregion  

        private void Main_Load(object sender, EventArgs e)
        {
            grpTree.Hide();
            treeSelectBtn.Hide();
        }



        #region File Managing Functions
        //Function returning array of string with rows of input CSV files
        public List<string> /*string[]*/ ReadCSVFile(string path)
        {

            string[] lines = { };

            try
            {
                lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] columns = line.Split(','); //separate by commas
                    foreach (string column in columns)
                    {
                        string[] items = column.Split(',');
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error encountered: " + e.ToString());
            }

            //return lines;
            return lines.ToList();
        }

        //returns name of any given file with not path and no extension
        public string GetFileName(string pathName)
        {
            string[] directories = pathName.Split('\\');
            return Path.ChangeExtension(directories[directories.Length - 1], null);
        }

        //returns list of grades specificed by chosen file from open file dialog
        public List<string> GetSectionGrades(List<string> lines)
        {
            //List<string> students = ReadCSVFile(path);
            string[] gradesTest = new string[lines.Count];

            int rowCounter = 0; //used to ignore first row which consists of the name of the section

            foreach (string item in lines)
            {
                if (rowCounter > 0)
                {
                    string[] studentItems = item.Split(',');
                    gradesTest[rowCounter] = studentItems[3];
                }
                rowCounter++;
            }
            return gradesTest.ToList();
        }

        //Function used to find files according to selected group (can be used for both CSV and GRP files)
        private List<string> FindFiles(List<string> fileList)
        {
            List<string> f = new List<string>();

            try
            {
                foreach (string fileName in fileList)
                {
                    if (File.Exists(path + "\\" + fileName))
                    {
                        f.Add(path + "\\" + fileName);
                    }
                    else
                    {
                        checkedNodes.Clear();
                        MessageBox.Show("One or more of the checked files were not found. Please select existing files", "Information", MessageBoxButtons.OK);
                        break;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                checkedNodes.Clear();
                MessageBox.Show("One or more of the checked files were not found. Please select existing files", "Information", MessageBoxButtons.OK);
            }

            return f;

        }

        //Function reading grp files which returns all sections to be compared. 
        public List<string> ReadGRPFile(string grpPath)
        {
            List<string> fileNames = new List<string>();
            bool ignoreTitle = true;

            try
            {
                string[] rows = File.ReadAllLines(grpPath);

                foreach (string file_name in rows)
                {
                    if (!ignoreTitle)
                    {
                        fileNames.Add(file_name); //Add file names to list
                    }
                    ignoreTitle = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error encountered: " + e.ToString());
            }

            return fileNames; //file names being returns will be of csv files in the same directory
        }

        //Returns neatly formated string to show on message box after grp file has been selected
        private string GRPToString()
        {
            List<string> fileNames = ReadGRPFile(grpFilePath);
            string result = "";
            foreach (string s in fileNames)
            {
                result += (s + "\n");
            }

            return result;
        }
        #endregion

        #region Mathematics Backend
        //Calculate GPA from a given list of grades
        public double CalculateGPA(List<string> grades)
        {

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

            foreach (string grade in grades)
            {
                foreach (KeyValuePair<string, double> pair in gradePoints)
                {
                    if (grade == pair.Key)
                    {
                        gpa += pair.Value;
                        stdevList.Add(pair.Value);
                    }
                }
            }
            return Math.Round(gpa / grades.Count, 2);
        }

        //function takes file specified by grp files and attempts to find them in the user's drive
        private void ComputeGroupAverage()
        {

            filesToRead = FindFiles(checkedNodes);
            int sectionCount = 0;

            foreach (string f in filesToRead)
            {
                List<string> grp = ReadGRPFile(f);
                foreach (string csv in grp)
                {
                    double temp = CalculateGPA(GetSectionGrades(ReadCSVFile(path + "\\" + Path.ChangeExtension(csv, ".csv"))));
                    cumulativeGPA += temp;
                    sectionAverages.Add(path + "\\" + csv, temp);
                    sectionCount++;
                }
            }

            cumulativeGPA /= sectionCount;
            overallStdev = StandardDeviation(stdevList);
            Console.WriteLine("Standard DEV: " + overallStdev);
            Console.WriteLine("Cumulative GPA: " + cumulativeGPA);

            /*
            int fileCount = 0;
            string[] files = Directory.GetFiles(path);
            string[] files = ReadGRPFile(FindFiles(checkedNodes));
            List<double> stdevList = new List<double>(); 
            
            foreach (string f in files) {
                if(!(f[f.Length - 1].Equals('P'))){ //filter out grp files
                 
                    stdevList.Add(CalculateGPA(GetSectionGrades(f)));
                    cumulativeGPA += CalculateGPA(GetSectionGrades(f));
                    fileCount++;
                }
            }
            
            cumulativeGPA /= fileCount;
            overallStdev = StandardDeviation(stdevList);
            z = (CalculateGPA(GetSectionGrades(filePath)) - cumulativeGPA) / overallStdev;
            */
        }

        //Function calculation standard deviation of a given list (used to calculate stdev of selected group)
        private double StandardDeviation(List<double> numList)
        {

            double temp = 0;

            foreach (double num in numList)
            {
                temp += Math.Pow(num - cumulativeGPA, 2);
            }

            temp /= (numList.Count);
            temp = Math.Sqrt(temp);
            return Math.Round(temp, 3);
        }

        //Function computing z-test and returning string messaging whether or not selected section is significantly different than overall section
        private void ComputeZTest()
        {

            double z_val = 0;

            foreach (KeyValuePair<string, double> pair in sectionAverages)
            {
                z_val = (pair.Value - cumulativeGPA) / overallStdev;
                if (z_val > 2 || z_val < -2)
                {
                    Console.WriteLine(GetFileName(pair.Key) + " is signifcantly different with z_val of: " + Math.Round(z_val, 2));
                    //message = GetFileName(filePath) + " is signifcantly different than " + GetFileName(grpFilePath + " with z-value of " + Math.Round(z, 2));
                }
                else
                {
                    Console.WriteLine(GetFileName(pair.Key) + " is not significantly different with z_val of " + Math.Round(z_val, 2));
                    //message = GetFileName(filePath) + " is not signifcantly different than " + GetFileName(grpFilePath + " with z-value of " + Math.Round(z, 2));
                }
            }
        }
        #endregion

        #region Getting Checked Nodes
        // If a node is double-clicked, open the file indicated by the TreeNode.
        private void SelectCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    if (Path.GetExtension(node.Text).Equals(".GRP"))
                    {
                        checkedNodes.Add(node.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please select only GRP Files");
                        checkedNodes.Clear();
                        break;
                    }
                }
            }
        }
        #endregion 

        private void GRPTreeHandler()
        {
            grpTree.Nodes.Clear();
            grpTree.Show(); //show treeView
            treeSelectBtn.Show();//since tree is hiding, show so user can select group within grp 
            List<string> grpFileNames = ReadGRPFile(grpFilePath);

            foreach (string s in grpFileNames)
            {
                grpTree.Nodes.Add(s);
            }
        }

        //Cleares data set so new group files can be selected after report has been printed out
        private void ClearData()
        {
            checkedNodes.Clear();
            filesToRead.Clear();
            stdevList.Clear();
            sectionAverages.Clear();
            overallStdev = 0;
            cumulativeGPA = 0;
        }

        #region Select GRP Button
        //Once button is pressed, file dialog will allow the user to select a grp file in order to start sections analysis

        #endregion
        private void grpTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


    }
}
