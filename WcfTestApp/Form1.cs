using System;
using System.Windows.Forms;
using WcfTestApp.DAL;

namespace WcfTestApp.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var helper = new Helper();
            var s = helper.Start();
            MessageBox.Show(s);
        }
    }
}

