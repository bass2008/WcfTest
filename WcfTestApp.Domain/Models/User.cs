using System.Collections.Generic;
using System.Collections.ObjectModel;
using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User : DbElementBase
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public User()
        {
            Events = new List<Event>();
        }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Подписки на события текущего пользователя.
        /// </summary>
        public virtual ICollection<Event> Events { get; set; }
    }
}
