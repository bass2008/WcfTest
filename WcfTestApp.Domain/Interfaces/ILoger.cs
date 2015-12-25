using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestApp.Domain.Interfaces
{
    /// <summary>
    /// Логер.
    /// </summary>
    public interface ILoger
    {
        /// <summary>
        /// Запись в лог.
        /// </summary>
        /// <param name="s"></param>
        void Write(string s);
    }
}
