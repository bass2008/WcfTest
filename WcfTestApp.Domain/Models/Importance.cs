using System.Collections.Generic;
using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Категория важности.
    /// </summary>
    public class Importance : EntityWithName
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Importance()
        {
            Channels = new List<Channel>();
        }

        /// <summary>
        /// События с данной категорией.
        /// </summary>
        public virtual ICollection<Channel> Channels { get; set; }
    }
}
