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
    public partial class SummaryFrame : Form
    {
        private static SummaryFrame _instance;

        public static SummaryFrame GetInstance() {
            if(_instance ==null) _instance = new SummaryFrame();
            return _instance;
        }

        public SummaryFrame()
        {
            InitializeComponent();
        }
    }
}
