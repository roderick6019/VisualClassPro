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
    public partial class Main : Form
    { 
        private string filePath;
        private string grpFilePath;
        private double cumulativeGPA;
        private double overallStdev;
        private bool ifAllSection;
        private string outputFileName;

        string path;
        List<string> checkedNodes;
        List<string> filesToRead;
        List<string> allSections;
        List<double> stdevList;
        Dictionary<string, double> sectionAverages; //stores section name along with respective section average
        
        public Main()
        {
            filePath = string.Empty; //initialize fileName as empty string
            grpFilePath = string.Empty;
            cumulativeGPA = 0;
            overallStdev = 0;
            overallStdev = 0;
            path = "C:\\Users\\Roderick Ramirez\\Documents\\University\\JuniorSemesterOne\\COMSC.330\\Project\\TestingData";
            checkedNodes = new List<string>(); 
            stdevList = new List<double>();
            filesToRead = new List<string>();
            sectionAverages = new Dictionary<string, double>();
            allSections = Directory.GetFiles(path, "*.csv").ToList();
            ifAllSection = false;
            outputFileName = "Report.txt";
            InitializeComponent();
        }

        #region User Interaction (Buttons etc...)
        private void treeSelectBtn_Click(object sender, EventArgs e)
        {
            SelectCheckedNodes(grpTree.Nodes);
            grpTree.Hide();
            treeSelectBtn.Hide();
            ComputeSchoolAverageGPA();
        }
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //once analysis button is clicked, analysis form will open 
        private void AnalysisButton_Click(object sender, EventArgs e)
        {
            if (filesToRead.Count != 0)
            {
                WriteToReport();
                DialogResult dialogResult = MessageBox.Show("A report has been in " + path + ". Would you like to open the file now?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes) {
                    Process.Start(path + "\\" + outputFileName);
                }
            }
            else
            {
                MessageBox.Show("Please select a group file before printing out a report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK){

                grpFilePath = ofd.FileName;
                if (filePath == string.Empty){

                    txtPathLabel.Text = GetFileName(grpFilePath);
                }
                else{

                    txtPathLabel.Text = GetFileName(grpFilePath);
                }
                GRPTreeHandler();
            }
        }

        private void txtPathLabel_Click(object sender, EventArgs e)
        {

        }
        #endregion  

        private void Main_Load(object sender, EventArgs e)
        {
            //Hiding tree and selectTree button as soon as the main frame loads
            grpTree.Hide();
            treeSelectBtn.Hide();
        }



        #region File Managing Functions
        //Function returning array of string with rows of input CSV files
        public List<string> /*string[]*/ ReadCSVFile(string path)
        {

            string[] lines = { };

            try{

                lines = File.ReadAllLines(path);

                foreach (string line in lines){

                    string[] columns = line.Split(','); //separate by commas
                    foreach (string column in columns){

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
        public string GetFileName(string pathName){

            string[] directories = pathName.Split('\\');
            return Path.ChangeExtension(directories[directories.Length - 1], null);
        }

        //returns list of grades specificed by chosen file from open file dialog
        public List<string> GetSectionGrades(List<string> lines){
            //List<string> students = ReadCSVFile(path);
            string[] gradesTest = new string[lines.Count];

            int rowCounter = 0; //used to ignore first row which consists of the name of the section

            foreach (string item in lines){

                if (rowCounter > 0){

                    string[] studentItems = item.Split(',');
                    gradesTest[rowCounter] = studentItems[3];
                }
                rowCounter++;
            }
            return gradesTest.ToList();
        }

        //Function used to find files according to selected group (can be used for both CSV and GRP files)
        private List<string> FindFiles(List<string> fileList){

            List<string> f = new List<string>();

            try{
                foreach (string fileName in fileList){
                    if (File.Exists(path + "\\" + fileName)){
                        f.Add(path + "\\" + fileName);
                    }
                    else{
                        checkedNodes.Clear();
                        MessageBox.Show("One or more of the checked files were not found. Please select existing files", "Information", MessageBoxButtons.OK);
                        break;
                    }
                }
            }
            catch (FileNotFoundException){
                checkedNodes.Clear();
                MessageBox.Show("One or more of the checked files were not found. Please select existing files", "Information", MessageBoxButtons.OK);
            }
            return f;
        }

        //Function reading grp files which returns all sections to be compared. 
        public List<string> ReadGRPFile(string grpPath){
            
            List<string> fileNames = new List<string>();
            bool ignoreTitle = true;

            try{
                string[] rows = File.ReadAllLines(grpPath);

                foreach (string file_name in rows){
                    if (!ignoreTitle){
                        fileNames.Add(file_name); //Add file names to list
                    }
                    ignoreTitle = false;
                }
            }
            catch (Exception e){
                MessageBox.Show("Error encountered: " + e.ToString());
            }
            return fileNames; //file names being returns will be of csv files in the same directory
        }
        #endregion

        #region Mathematics Backend
        //Calculate GPA from a given list of grades
        public double CalculateGPA(List<string> grades){

            double gpa = 0;
            //Dictionary with grades as keys and their respective values as values in a 4.0 GPA scale 

            var gradePoints = new Dictionary<string, double> { //dictionary used to compute gpa by comparing keys and summing respective values
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

            foreach (string grade in grades){

                foreach (KeyValuePair<string, double> pair in gradePoints){

                    if (grade == pair.Key){
                        gpa += pair.Value;

                        if (ifAllSection){
                            stdevList.Add(pair.Value);
                        }
                    }
                    
                }
            }
            return Math.Round(gpa / grades.Count, 2);
        }

        //Function return count of each individual grade throughout specified sections
        private List<string> ProduceGradeList(List<string> fileList) {

            List<string> grades = new List<string>();
            bool isRow = true;

            foreach (string s in fileList) {
                List<string> section = ReadCSVFile(s);
                section = GetSectionGrades(section);
                foreach (string str in section) {
                    if (!isRow) {
                        grades.Add(str);
                    }
                    isRow = false;
                }
                isRow = true;
            }

            return grades;
        }

        private string GetGradeCount(List<string> fileList) {

            List<string> grades = ProduceGradeList(fileList);
            int[] gradesArr = new int[12];
            string[] gradeLetter = {"A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "F"};
            string outputString = string.Empty;

            //Getting count of each grade in given list using switch statement (UNDERSIRED BUT HAVE NOT OTHER OPTION)
            foreach (string s in grades) {
                for(int i = 0; i < gradeLetter.Length; i++){
                    if (gradeLetter[i].Equals(s)) {
                        gradesArr[i] = gradesArr[i] + 1;
                    }
                }
            }

            //Properly formatting output string for easier reading and interpretation
            for(int i = 0; i < gradeLetter.Length; i++) {
                outputString += (" " + gradeLetter[i] + ": " + gradesArr[i] + "\n");
            }

            return outputString;
        }

        //Returns numbers of students in given list of sections
        private string GetStudentCount(List<string> fileRead) { //fileRead is meant to be a list of sections

            int studentCount = 0;
            bool isRow = true; //Omit course title. ROWS ARE NOT STUDENTS!!
            
            foreach (string s in fileRead) {
                List<string> sec = ReadCSVFile(s);
                foreach (string line in sec) {
                    if (!(isRow)) {
                        studentCount++;
                    }
                    isRow = false;
                }
                isRow = true;
            }

            return studentCount.ToString();
        }

        //function takes file specified by grp files and attempts to find them in the user's drive
        private void ComputeSchoolAverageGPA(){

            ifAllSection = true;
            filesToRead = FindFiles(checkedNodes);
            int sectionCount = 0;

            foreach (string f in filesToRead){

                List<string> grp = ReadGRPFile(f);

                foreach (string csv in grp){
                    double temp = CalculateGPA(GetSectionGrades(ReadCSVFile(path + "\\" + Path.ChangeExtension(csv, ".csv"))));
                    cumulativeGPA += temp;
                    sectionAverages.Add(path + "\\" + csv, temp);
                    sectionCount++;
                }
            }
            ifAllSection = false;
            overallStdev = StandardDeviation(stdevList);
            cumulativeGPA /= sectionCount;
        }

        //returns all csv files from checked group files in tree node (Redundant but meh...)
        private List<string> GetCSVFRomFileToRead() {

            List<string> readFiles = FindFiles(checkedNodes);
            List<string> output = new List<string>();

            foreach (string str in readFiles) {
                
                List<string> grp = ReadGRPFile(str);
                foreach (string g in grp) {
                    output.Add(path + "\\" + Path.ChangeExtension(g, ".csv"));
                }
            }

            return output;
        }

        //Function calculation standard deviation of a given list (used to calculate stdev of selected group)
        private double StandardDeviation(List<double> numList){
            
            double temp = 0;

            foreach (double num in numList){
                temp += Math.Pow(num - GetAllSectionsGPA(), 2);
            }

            temp /= (numList.Count);
            temp = Math.Sqrt(temp);
            return Math.Round(temp, 3);
        }

        //Function that gets all sections in order to display school level information
        private double GetAllSectionsGPA() {

            List<string> allSections = Directory.GetFiles(path, "*.csv").ToList();
            //getting all school sections
            double gpa = 0;

            foreach (string s in allSections) {
                gpa += CalculateGPA(GetSectionGrades(ReadCSVFile(s)));
            }

            return Math.Round(gpa / allSections.Count, 2);
        }

        //Returns all checked nodes. Used to display selected sections in printed report
        private string GetCheckedNodes() {

            string output = string.Empty;
            foreach (string str in checkedNodes) {
                output += str + " ";
            }

            return output;
        }

        //Function computing z-test and returning string messaging whether or not selected section is significantly different than overall section
        private void WriteToReport(){

            double z_val = 0;

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, outputFileName))) {

                outputFile.WriteLine("School Stats:\nAverage School GPA: " + GetAllSectionsGPA() + "\nNumber of Courses: " + allSections.Count + "\nTotal Students: " + GetStudentCount(allSections) +"\nNumber of each grade:\n" + GetGradeCount(allSections));
                outputFile.WriteLine("Section Stats:\nAverage GPA for " + GetCheckedNodes() + ": " + Math.Round(cumulativeGPA, 2) + "\nNumber of students: " + GetStudentCount(GetCSVFRomFileToRead()) +"\nNumber of each grade:\n" + GetGradeCount(GetCSVFRomFileToRead()));
                
                foreach (KeyValuePair<string, double> pair in sectionAverages){
                    z_val = (pair.Value - GetAllSectionsGPA()) / overallStdev;
                    if (z_val > 2 || z_val < -2){
                        //Writing section level information to output file
                        outputFile.WriteLine(GetFileName(pair.Key) + " average GPA: " + pair.Value + " | Section is significantly different from school average with z_val of: " + Math.Round(z_val, 2));
                    }
                    else{
                        outputFile.WriteLine(GetFileName(pair.Key) + " average GPA: " + pair.Value + " | Section is not significantly different from school average with z_val of: " + Math.Round(z_val, 2));
                    }
                }
            }
        }
        #endregion

        #region Getting Checked Nodes
        // If a node is double-clicked, open the file indicated by the TreeNode.
        private void SelectCheckedNodes(TreeNodeCollection nodes){
            foreach (TreeNode node in nodes){
                if (node.Checked){
                    if (Path.GetExtension(node.Text).Equals(".GRP")){
                        checkedNodes.Add(node.Text);
                    }
                    else{
                        MessageBox.Show("Please select only GRP Files");
                        checkedNodes.Clear();
                        break;
                    }
                }
            }
        }
        #endregion 

        private void GRPTreeHandler(){
            grpTree.Nodes.Clear();
            grpTree.Show(); //show treeView
            treeSelectBtn.Show();//since tree is hiding, show so user can select group within grp 
            List<string> grpFileNames = ReadGRPFile(grpFilePath);

            foreach (string s in grpFileNames){
                grpTree.Nodes.Add(s);
            }
        }

        //Cleares data set so new group files can be selected after report has been printed out if necessary
        private void ClearData(){
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
