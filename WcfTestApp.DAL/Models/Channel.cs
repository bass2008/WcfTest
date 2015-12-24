using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestApp.DAL.Models
{
    /// <summary>
    /// Канал связи.
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// Id события.
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// Имя события.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Характеристики важности у данного канала связи.
        /// </summary>
        public virtual ICollection<Importance> Importances { get; set; }
    }
}
