namespace WcfTestApp.Domain.Interfaces
{
    public interface ISender
    {
        /// <summary>
        /// Отправить сообщение на E-mail.
        /// </summary>
        /// <param name="to">Получатель.</param>
        /// <param name="message">Сообщение.</param>
        void Send(string to, string message);
    }
}
