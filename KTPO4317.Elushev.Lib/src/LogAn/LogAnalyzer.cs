namespace KTPO4317.Elushev.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            IExtensionManager mrg = ExtensionManagerFactory.Create();
            try
            {
                return mrg.IsValid(fileName);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    IWebService webService = WebServiceFactory.Create();
                    webService.LogError("Слишком короткое имя файла: " + fileName);
                }
                catch(Exception ex)
                {
                    // Отправить сообщение по электроннной почте
                    IEmailService emailService = EmailServiceFactory.Create();
                    emailService.SendEmail("someone@somewhere.com", "невозможно вызвать веб сервис", ex.Message); //здесь можно сломать тест
                }
            }
        }
    }
}