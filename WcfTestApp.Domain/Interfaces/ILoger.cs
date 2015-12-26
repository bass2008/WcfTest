namespace WcfTestApp.Domain.Interfaces
{
    /// <summary>
    /// Логер.
    /// </summary>
    public interface ILoger
    {
        /// <summary>
        /// Запись в лог.
        /// </summary>
        /// <param name="s"></param>
        void Write(string s);
    }
}
