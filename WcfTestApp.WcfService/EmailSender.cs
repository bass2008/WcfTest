using System;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using WcfTestApp.DAL;
using WcfTestApp.Domain.Interfaces;

namespace WcfTestApp.WcfService
{
    /// <summary>
    /// Отправление сообщений на E-Mail.
    /// </summary>
    public class EmailSender : ISender
    {
        /// <summary>
        /// SMTP сервер.
        /// </summary>
        private string _smtpServer;

        /// <summary>
        /// Логин отправителя.
        /// </summary>
        private string _login;

        /// <summary>
        /// Пароль отправителя.
        /// </summary>
        private string _pass;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        /// <param name="smtpServer">SMTP сервер.</param>
        /// <param name="login">Логин.</param>
        /// <param name="pass">Пароль.</param>
        public EmailSender(string smtpServer, string login, string pass)
        {
            _smtpServer = smtpServer;
            _login = login;
            _pass = pass;
        }

        /// <summary>
        /// Отправить сообщение на E-mail.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="to">Получатель.</param>
        public void Send(string message, string to)
        {
            var from = StringResources.MailFrom;
            
            var mailMessage = new MailMessage(from, to)
            {
                Subject = StringResources.MailTheme,
                Body = message
            };

            var client = new SmtpClient(_smtpServer);
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                var loger = new FileLoger(StringResources.FileLogerPath);
                loger.Write(ex.Message);
            }
        }
    }
}
