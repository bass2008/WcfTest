using System;
using System.Windows.Forms;
using WcfTestApp.DAL;
using WcfTestApp.Domain.Interfaces;

namespace WcfTestApp.WinForms
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Логер для формы.
        /// </summary>
        private ILoger _loger;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _loger = new Loger(richTextBox1);
        }

        /// <summary>
        /// Обработчик кнопки запуска.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var helper = new Helper(_loger);
            //helper.Start();
            helper.StartRepository();
            MessageBox.Show("ok");
        }
    }
}

