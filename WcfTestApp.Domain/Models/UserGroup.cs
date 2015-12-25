using System.Collections.Generic;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Группа пользователей.
    /// </summary>
    public class UserGroup
    {
        /// <summary>
        /// Id группы пользователей.
        /// </summary>
        public int UserGroupId { get; set; }

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
