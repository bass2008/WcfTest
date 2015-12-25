namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Подписки на события.
        /// </summary>
        //public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
