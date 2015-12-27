using System.Collections;
using System.Linq;
using WcfTestApp.DAL;
using WcfTestApp.DAL.DataAccess;
using WcfTestApp.Domain.Interfaces;
using WcfTestApp.Domain.Models;

namespace WcfTestApp.WcfService
{
    /// <summary>
    /// WCF Сервис.
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private ILoger _loger;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Service()
        {
            _loger = new FileLoger(StringResources.FileLogerPath);
        }

        /// <summary>
        /// Сгенерировать уведомление.
        /// </summary>
        /// <param name="impotance">Важность.</param>
        /// <param name="eventName">Событие.</param>
        /// <param name="message">Сообщение.</param>
        /// <returns></returns>
        public string ThrowNotice(string impotance, string eventName, string message)
        {
            var context = new ServiceContext();
            var eventRepository = new GenericRepository<Event>(context);
            var dbEvent = eventRepository.Get(x => x.Name == eventName);
            if (dbEvent == null)
            {
                var s = string.Format("Событие {0} не найдено", eventName);
                _loger.Write(s);
                return s;
            }

            var importanceRepository = new GenericRepository<Importance>(context);
            var dbImportance = importanceRepository.Get(x => x.Name == impotance);
            if (dbImportance == null)
            {
                var s = string.Format("Степень важности {0} не найдена", eventName);
                _loger.Write(s);
                return s;
            }
            var channels = dbImportance.Channels.ToArray();
            
            var users = dbEvent.Users.ToArray();

            foreach (var user in users)
            {
                foreach (var chan in channels)
                {
                    // Можно что-нибудь придумать, чтобы название каналов задавались в одном месте.
                    switch (chan.Name)
                    {
                        case "E-mail":
                            var emailSender = new EmailSender(StringResources.EmailSenderServer, StringResources.EmailSenderLogin, StringResources.EmailSenderPass);
                            emailSender.Send(user.Email, message);
                            break;
                        case "SMS":
                            var smsSender = new SmsSender(StringResources.SmsLogerPath);
                            smsSender.Send(user.Name, message);
                            break;
                    }
                }
            }

            return string.Format("Success");
        }
    }
}
