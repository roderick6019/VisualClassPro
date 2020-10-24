using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VisualClassPro
{
    class CSVManager
    {
        Main mainFrame;

        public CSVManager() {
            mainFrame = new Main();
        }
        
        //Function reading csv files 
        private void ReadCSV(string filePath) {

            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines) {
                string[] columns = line.Split(','); //separate by commas
                foreach (string column in columns) {
                    Console.WriteLine(column); //TESTING: Just to see what function picks up
                }
            }
        }
    }
}
