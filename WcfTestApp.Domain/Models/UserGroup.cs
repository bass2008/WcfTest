using System.Collections.Generic;
using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Группа пользователей.
    /// </summary>
    public class UserGroup : DbElementBase
    {
        /// <summary>
        /// Имя группы пользователей.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Подписки на события.
        /// </summary>
        public virtual ICollection<Event> Events { get; set; }

        /// <summary>
        /// Пользователи группы.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
