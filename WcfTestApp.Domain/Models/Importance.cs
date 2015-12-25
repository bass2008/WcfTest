using System.Collections.Generic;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Категория важности.
    /// </summary>
    public class Importance
    {
        /// <summary>
        /// Id категории важности.
        /// </summary>
        public int ImportanceId { get; set; }

        /// <summary>
        /// Имя категории важности.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// События с данной категорией.
        /// </summary>
        public virtual ICollection<Event> Events { get; set; }
    }
}
