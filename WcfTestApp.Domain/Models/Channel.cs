using System.Collections.Generic;
using WcfTestApp.Domain.DataAccess;
using WcfTestApp.WcfContracts;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Канал связи.
    /// </summary>
    public class Channel : DbElementBase
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Channel()
        {
            Importances = new List<Importance>();
        }

        /// <summary>
        /// Имя канала.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код канала.
        /// </summary>
        public EnumChannel Code { get; set; }

        /// <summary>
        /// Характеристики важности у данного канала связи.
        /// </summary>
        public virtual ICollection<Importance> Importances { get; set; }
    }
}
