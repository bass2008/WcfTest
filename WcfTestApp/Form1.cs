using System;
using System.ServiceModel;
using System.ServiceModel.Description;
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
            //helper.StartRepository();

            using (var cf = new ChannelFactory<IService>(new WebHttpBinding(), "http://localhost:8000"))
            {
                cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                var channel = cf.CreateChannel();

                _loger.Write("Calling EchoWithGet via HTTP GET: ");
                var s = channel.ThrowNotice("middle", "php", "fatal error");
                _loger.Write(string.Format("   Output: {0}", s));
            }

            _loger.Write("Done!");
        }
    }
}

