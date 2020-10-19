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
    public partial class AnalysisFrame : Form
    {
        private static AnalysisFrame _instance;

        public static AnalysisFrame GetInstance() {
            if (_instance == null) _instance = new AnalysisFrame();
            return _instance;
        }

        public AnalysisFrame()
        {
            InitializeComponent();
        }
    }
}
