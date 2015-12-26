using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.DAL.DataAccess
{
    /// <summary>
    /// Унфицированный репозиторий.
    /// </summary>
    /// <typeparam name="T">Объект домена.</typeparam>
    public class GenericRepository<T> : IRepository<T> where T : DbElementBase
    {
        /// <summary>
        /// Представляет коллекцию всех сущностей указанного типа, которые
        /// содержатся в контексте или могут быть запрошены из БД.
        /// </summary>
        protected readonly DbSet<T> Set;

        /// <summary>
        /// Контекст данных.
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// Инициализировать экземпляр типа.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public GenericRepository(DbContext context)
        {
            Context = context;
            Set = Context.Set<T>();
        }

        /// <summary>
        /// Добавить элемент.
        /// </summary>
        /// <param name="item">Добавляемый элемент.</param>
        public virtual void Add(T item)
        {
            if (item.IsNew)
            {
                Set.Add(item);
            }
            else
            {
                throw new DbUpdateConcurrencyException("Cannot insert existing entity. Use update instead.");
            }
        }

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="item">Удаляемый элемент.</param>
        public virtual void Delete(T item)
        {
            Set.Remove(item);
        }

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="id">Идентификатор элемента.</param>
        /// <returns>Требуемый элемент или null.</returns>
        public T Get(int id)
        {
            return Set.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="where">Условие выборки.</param>
        /// <returns>Требуемый элемент.</returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            return Set.FirstOrDefault(where);
        }

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <typeparam name="TProperty">Свойство элемента.</typeparam>
        /// <param name="where">Условие выборки.</param>
        /// <param name="childSelector">Условие выборки свойства.</param>
        /// <returns>Возврвщает искомый элемент.</returns>
        public T Get<TProperty>(Expression<Func<T, bool>> where, Expression<Func<T, TProperty>>[] childSelector)
        {
            return Set.FirstOrDefault(where);
        }

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <typeparam name="TProperty">Свойство элемента.</typeparam>
        /// <param name="id">Уникальный идентификатор элемента.</param>
        /// <param name="childSelector">Условие выборки свойства.</param>
        /// <returns>Искомый элемент.</returns>
        public T Get<TProperty>(int id, Expression<Func<T, TProperty>>[] childSelector)
        {
            var temp = Set.AsQueryable();

            for (var i = 0; i < childSelector.Length; i++)
            {
                temp = Set.Include(childSelector[i]);
            }

            return temp.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Получить все элементы.
        /// </summary>
        /// <returns>Набор элементов.</returns>
        public T[] GetAll()
        {
            return Set.Where(c => c.Id > 0).ToArray();
        }

        /// <summary>
        /// Получить набор элементов.
        /// </summary>
        /// <param name="where">Условые выборки.</param>
        /// <returns>Набор элементов.</returns>
        public T[] GetAll(Expression<Func<T, bool>> where)
        {
            return Set.Where(c => c.Id > 0).Where(where).ToArray();
        }

        /// <summary>
        /// Получить набор элементов.
        /// </summary>
        /// <typeparam name="TProperty">Свойство элемента.</typeparam>
        /// <param name="where">Условие выборки.</param>
        /// <param name="include">Условие включения свойства.</param>
        /// <returns>Набор элементов.</returns>
        public T[] GetAll<TProperty>(Expression<Func<T, bool>> where, Expression<Func<T, TProperty>>[] include)
        {
            var temp = Set.Where(c => c.Id > 0);

            for (var i = 0; i < include.Length; i++)
            {
                temp = temp.Include(include[i]);
            }

            return temp.Where(where).ToArray();
        }

        /// <summary>
        /// Получить набор элементов с учетом страниц.
        /// </summary>
        /// <param name="skip">К-во записей для пропуска.</param>
        /// <param name="take">К-во записей, которое необходимо взять.</param>
        /// <param name="orderBy">Правила сортировки.</param>
        /// <param name="where">Условие выбоки.</param>
        /// <returns>Общее к-во записей и набор элементов.</returns>
        public T[] GetAll(
            int skip, int take, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Expression<Func<T, bool>> where)
        {
            return orderBy(Set.Where(c => c.Id > 0).Where(where).Skip(skip).Take(take)).ToArray();
        }

        /// <summary>
        /// Найти элементы.
        /// </summary>
        /// <param name="where">Условие поиска.</param>
        /// <returns>Набор элементов.</returns>
        public T[] Find(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).ToArray();
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
