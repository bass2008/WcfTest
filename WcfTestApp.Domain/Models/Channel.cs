﻿using System.Collections.Generic;
using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Канал связи.
    /// </summary>
    public class Channel : DbElementBase
    {
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
