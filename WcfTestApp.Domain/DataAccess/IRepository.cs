using System;
using System.Linq.Expressions;

namespace WcfTestApp.Domain.DataAccess
{
    /// <summary>
    /// Интерфейс доступа к объектам БД.
    /// </summary>
    /// <typeparam name="T">
    /// Объект домена.
    /// </typeparam>
    public interface IRepository<T> : IDisposable
    {
        /// <summary>
        /// Получить элемент по идентификатору.
        /// </summary>
        /// <param name="id">
        /// Уникальный идентификатор элемента.
        /// </param>
        /// <returns>
        /// Возвращает объект домена или null.
        /// </returns>
        T Get(int id);

        /// <summary>
        /// Получить элемент по условию.
        /// </summary>
        /// <param name="where">Условие выборки элемента.</param>
        /// <returns>Требуемый элемент.</returns>
        T Get(Expression<Func<T, bool>> where);

        /// <summary>
        /// Получить элемент по условию и его дочерние элементы по условию.
        /// </summary>
        /// <typeparam name="TProperty">Свойство элемента.</typeparam>
        /// <param name="where">Условие выборки.</param>
        /// <param name="childSelector">Условие выборки свойства.</param>
        /// <returns>Возврвщает искомый элемент.</returns>
        T Get<TProperty>(Expression<Func<T, bool>> where, Expression<Func<T, TProperty>>[] childSelector);

        /// <summary>
        /// Получить элемент и его дочерние элементы по условию.
        /// </summary>
        /// <typeparam name="TProperty">Тип дочерних элементов.</typeparam>
        /// <param name="id">Уникальный идентификатор элемента.</param>
        /// <param name="childSelector">Выражение для выборки дочерних элементов.</param>
        /// <returns>Требуемый элемент.</returns>
        T Get<TProperty>(int id, Expression<Func<T, TProperty>>[] childSelector);

        /// <summary>
        /// Получить все элементы.
        /// </summary>
        /// <returns>
        /// Возвращает все объекты домена или null.
        /// </returns>
        T[] GetAll();

        /// <summary>
        /// Получить все релевантные значения.
        /// </summary>
        /// <param name="where">Условие выборки элементов.</param>
        /// <returns>Набор элементов.</returns>
        T[] GetAll(Expression<Func<T, bool>> where);

        /// <summary>
        /// Получить все релевантные значения, включая свойства.
        /// </summary>
        /// <typeparam name="TProperty">Тип дочерних элементов.</typeparam>
        /// <param name="where">Условие выборки элементов.</param>
        /// <param name="include">Выражение для включения свойств.</param>
        /// <returns>Набор элементов.</returns>
        T[] GetAll<TProperty>(
            Expression<Func<T, bool>> where, Expression<Func<T, TProperty>>[] include);

        /// <summary>
        /// Искать элемент по ключу.
        /// </summary>
        /// <param name="key">
        /// Параметр поиска.
        /// </param>
        /// <returns>
        /// Возвращает искомый элемент или null.
        /// </returns>
        T Find(string key);

        /// <summary>
        /// Добавить новый элемент.
        /// </summary>
        /// <param name="item">
        /// Новый элемент.
        /// </param>
        void Add(T item);

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="item">
        /// Элемент, который необходимо удалить.
        /// </param>
        void Delete(T item);
    }
}