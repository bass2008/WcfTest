namespace WcfTestApp.Domain.Models
{
    /// <summary>
    /// Событие.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Id события.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Имя события.
        /// </summary>
        public string Name { get; set; }
    }
}
