using System;
using System.Linq.Expressions;

namespace WcfTestApp.Domain.DataAccess
{
    /// <summary>
    /// Интерфейс доступа к объектам БД.
    /// </summary>
    /// <typeparam name="T">Объект домена.</typeparam>
    public interface IRepository<T> : IDisposable
    {
        /// <summary>
        /// Получить элемент по идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор элемента.</param>
        /// <returns>Возвращает объект домена или null.</returns>
        T Get(int id);

        /// <summary>
        /// Получить элемент по условию.
        /// </summary>
        /// <param name="where">Условие выборки элемента.</param>
        /// <returns>Требуемый элемент.</returns>
        T Get(Expression<Func<T, bool>> where);

        /// <summary>
        /// Получить все элементы.
        /// </summary>
        /// <returns>Возвращает все объекты домена или null.</returns>
        T[] GetAll();

        /// <summary>
        /// Получить все релевантные значения.
        /// </summary>
        /// <param name="where">Условие выборки элементов.</param>
        /// <returns>Набор элементов.</returns>
        T[] GetAll(Expression<Func<T, bool>> where);

        /// <summary>
        /// Добавить новый элемент.
        /// </summary>
        /// <param name="item">Новый элемент.</param>
        void Add(T item);

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="item">Элемент, который необходимо удалить.</param>
        void Delete(T item);
    }
}