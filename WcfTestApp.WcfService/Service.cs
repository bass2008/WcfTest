using System;
using System.Collections;
using System.Linq;
using NLog;
using WcfTestApp.DAL;
using WcfTestApp.DAL.DataAccess;
using WcfTestApp.Domain.Interfaces;
using WcfTestApp.Domain.Models;
using WcfTestApp.WcfContracts;

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
        private ILogger _loger;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Service()
        {
            _loger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Сгенерировать уведомление.
        /// </summary>
        /// <param name="importance">Важность.</param>
        /// <param name="eventName">Событие.</param>
        /// <param name="message">Сообщение.</param>
        /// <returns></returns>
        public string ThrowNotice(string importance, string eventName, string message)
        {
            var context = new ServiceContext();
            var eventRepository = new EntityWithNameRepository<Event>(context);
            var dbEvent = eventRepository.GetByName(eventName);
            if (dbEvent == null)
            {
                var s = string.Format("Событие {0} не найдено", eventName);
                _loger.Error(s);
                return s;
            }

            var importanceRepository = new EntityWithNameRepository<Importance>(context);
            var dbImportance = importanceRepository.GetByName(importance);
            if (dbImportance == null)
            {
                var s = string.Format("Степень важности {0} не найдена", eventName);
                _loger.Error(s);
                return s;
            }
            var channels = dbImportance.Channels.ToArray();
            
            var users = dbEvent.Users.ToArray();

            foreach (var user in users)
            {
                foreach (var chan in channels)
                {
                    // Можно что-нибудь придумать, чтобы название каналов задавались в одном месте.
                    switch (chan.Code)
                    {
                        case EnumChannel.Email:
                            var emailSender = new EmailSender(StringResources.EmailSenderServer, StringResources.EmailSenderLogin, StringResources.EmailSenderPass);
                            emailSender.Send(user.Email, message);
                            break;
                        case EnumChannel.Sms:
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
