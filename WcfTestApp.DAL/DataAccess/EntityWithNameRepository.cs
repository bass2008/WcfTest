using System.Data.Entity;
using System.Linq;
using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.DAL.DataAccess
{
    public class EntityWithNameRepository<T> : GenericRepository<T> where T : EntityWithName
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public EntityWithNameRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Получить сущность по имени.
        /// </summary>
        /// <param name="name">Имя сущности.</param>
        /// <returns>Получаем сущность.</returns>
        public T GetByName(string name)
        {
            return Set.FirstOrDefault(c => c.Name == name);
        }
    }
}
