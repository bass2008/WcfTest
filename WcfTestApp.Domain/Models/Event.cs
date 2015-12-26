using WcfTestApp.Domain.DataAccess;

namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Событие.
    /// </summary>
    public class Event : DbElementBase
    {
        /// <summary>
        /// Имя события.
        /// </summary>
        public string Name { get; set; }
    }
}
