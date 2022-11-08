namespace KTPO4317.Elushev.Lib.src.LogAn
{
    public class EmailServiceFactory
    {
        private static IEmailService emailService;

        public static IEmailService Create()
        {
            if (emailService != null)
            {
                return emailService;
            }

            throw new NotImplementedException();

        }

        public static void SetEmailService(IEmailService email)
        {
            emailService = email;
        }

    }
}
