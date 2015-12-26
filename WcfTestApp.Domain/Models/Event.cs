using System.Collections.Generic;
using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Событие.
    /// </summary>
    public class Event : DbElementBase
    {
        /// <summary>
        /// Имя события.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Подписки на события текущего пользователя.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
