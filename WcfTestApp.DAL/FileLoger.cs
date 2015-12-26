using System;
using System.IO;
using WcfTestApp.Domain.Interfaces;

namespace WcfTestApp.DAL
{
    /// <summary>
    /// Реализация файлового логера.
    /// </summary>
    public class FileLoger : ILoger
    {
        /// <summary>
        /// Путь для файла.
        /// </summary>
        private string _logFile;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        /// <param name="fullFileName"></param>
        public FileLoger(string fullFileName)
        {
            _logFile = fullFileName;
            if (!File.Exists(fullFileName))
            {
                using (var sw = File.CreateText(fullFileName))
                {
                    sw.WriteLine(DevStrings.FileLogerHeader);
                }
            }
        }

        /// <summary>
        /// Запись ошибки в лог файл.
        /// </summary>
        /// <param name="s"></param>
        public void Write(string s)
        {
            using (var sw = File.AppendText(_logFile))
            {
                sw.WriteLine(" ");
                sw.WriteLine("{0} : {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                sw.WriteLine(s);
            }
        }
    }
}
