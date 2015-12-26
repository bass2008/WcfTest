using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestApp.Domain.DataAccess
{
    /// <summary>
    /// Базовый тип для элементов БД.
    /// </summary>
    public class DbElementBase
    {
        /// <summary>
        /// Уникальный идентификатор элемента.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Признак нового элемента.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return Id == 0;
            }
        }
    }
}
