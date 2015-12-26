using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.DAL.DataAccess
{
    /// <summary>
    /// Реализация паттерна "Единица работы".
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Контекст данных.
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Запись в лог.
            }

        }

        /// <summary>
        /// Очистить ресурсы.
        /// </summary>
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
