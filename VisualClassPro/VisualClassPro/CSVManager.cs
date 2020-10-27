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
        /*public void ReadCSV() {

            string[] lines = System.IO.File.ReadAllLines(mainFrame.GetFilePath());

            foreach (string line in lines) {
                string[] columns = line.Split(','); //separate by commas
                foreach (string column in columns) {
                    string[] items = column.Split(','); //TESTING: Just to see what function picks up
                }
            }
        }*/
    }
}
