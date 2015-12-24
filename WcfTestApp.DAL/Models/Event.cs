using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestApp.DAL.Models
{
    /// <summary>
    /// Событие.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Id события.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Имя события.
        /// </summary>
        public string Name { get; set; }
    }
}
