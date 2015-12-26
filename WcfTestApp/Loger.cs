using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WcfTestApp.Domain.Interfaces;
using System.Windows.Forms;

namespace WcfTestApp.WinForms
{
    /// <summary>
    /// Реализация логера для формы.
    /// </summary>
    public class Loger : ILoger
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private RichTextBox _loger;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        /// <param name="textBox"></param>
        public Loger(RichTextBox textBox)
        {
            _loger = textBox;
        }

        /// <summary>
        /// Запись в лог.
        /// </summary>
        /// <param name="s"></param>
        public void Write(string s)
        {
            _loger.AppendText(s);
            _loger.AppendText("\n");
        }
    }
}
