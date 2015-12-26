namespace WcfTestApp.Domain.Interfaces
{
    public interface ISender
    {
        /// <summary>
        /// Послать сообщение.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="to">Получатель.</param>
        /// <returns>Ответ.</returns>
        void Send(string message, string to);
    }
}
