using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WcfTestApp.DAL.Models
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
