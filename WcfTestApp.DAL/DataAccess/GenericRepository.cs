﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
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
