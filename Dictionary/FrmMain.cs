using KbHook;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class FrmMain : Form
    {
        private string _source;
        private string _phonetic;
        private string _mean;

        public FrmMain(string source, string phonetic, string mean)
        {
            InitializeComponent();
            _source = source;
            _phonetic = phonetic;
            _mean = mean;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblSource.Text = _source;
            lblPhonetic.Text = _phonetic;
            txtMean.Text = _mean;
        }
    }
}
