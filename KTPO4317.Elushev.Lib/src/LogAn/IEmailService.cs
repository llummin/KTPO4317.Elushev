namespace KTPO4317.Elushev.Lib.src.LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
