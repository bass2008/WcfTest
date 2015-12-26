using System;
using System.IO;
using WcfTestApp.Domain.Interfaces;

namespace WcfTestApp.WcfService
{
    /// <summary>
    /// Отправляет смс в файл.
    /// </summary>
    public class SmsSender : ISender
    {
        /// <summary>
        /// Путь для файла.
        /// </summary>
        private string _logFile;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        /// <param name="path"></param>
        public SmsSender(string path)
        {
            _logFile = path;
            if (!File.Exists(path))
            {
                using (var sw = File.CreateText(path))
                {
                    sw.WriteLine(" ");
                }
            }
        }

        /// <summary>
        /// Отправить смс в файл.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="to">Получатель.</param>
        public void Send(string message, string to)
        {
            using (var sw = File.AppendText(_logFile))
            {
                sw.WriteLine(" ");
                sw.WriteLine("To {0}:",to);
                sw.WriteLine(message);
                sw.WriteLine("{0} : {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            }
        }
    }
}
