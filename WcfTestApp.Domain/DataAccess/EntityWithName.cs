namespace WcfTestApp.Domain.DataAccess
{
    /// <summary>
    /// Сущность в БД, которая имеет имя.
    /// </summary>
    public abstract class EntityWithName : DbElementBase
    {
        /// <summary>
        /// Имя сущности.
        /// </summary>
        public string Name { get; set; }
    }
}
