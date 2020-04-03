namespace PaulWeissInSite.API
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}
