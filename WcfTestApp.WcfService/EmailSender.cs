using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using NLog;
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
        /// <param name="mailto">Получатель.</param>
        /// <param name="message">Сообщение.</param>
        public void Send(string mailto, string message)
        {
            try
            {
                var caption = StringResources.EmailSenderMailTheme;
                var mail = new MailMessage
                {
                    From = new MailAddress(_login),
                    Subject = caption,
                    Body = message
                };
                mail.To.Add(new MailAddress(mailto));
                var client = new SmtpClient
                {
                    Host = _smtpServer,
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_login.Split('@')[0], _pass),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetCurrentClassLogger();
                var newException = new Exception("Mail was not send", ex);
                logger.Error("Mail was not send" + ex.Message);
                throw newException;
            }
        }
    }
}
