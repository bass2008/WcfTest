using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using WcfTestApp.WcfContracts;

namespace WcfTestApp.WinForms
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Логер для формы.
        /// </summary>
        private RichTextBox richTextBox;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            richTextBox = richTextBox1;
        }

        /// <summary>
        /// Обработчик кнопки запуска.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (var cf = new ChannelFactory<IService>(new WebHttpBinding(), "http://localhost:8000"))
            {
                cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                var channel = cf.CreateChannel();

                richTextBox.AppendText("Calling EchoWithGet via HTTP GET: ");
                var s = channel.ThrowNotice("Low", "php", "fatal error");
                richTextBox.AppendText(string.Format("   Output: {0}", s));
            }
        }
    }
}

