using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualClassPro
{
    class Manager
    {
        string filePath;
        Main mainFrame;

        public Manager() {
            mainFrame = new Main();
        }

        public string GetFilePath() {
            return filePath;
        }

        public void SetFilePath(string value) {
            filePath = value;
            Console.WriteLine(filePath);
        }

        private void GetFormInstance() {

        }


    }
}
