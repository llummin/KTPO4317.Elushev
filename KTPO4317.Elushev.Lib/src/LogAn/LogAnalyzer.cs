namespace KTPO4317.Elushev.Lib.src.LogAn
{
    /// <summary> Анализатор лог. файлов </summary>
    public class LogAnalyzer : ILogAnalyzer
    {
        /// <summary> Объявление события </summary>
        public event LogAnalyzerAction Analyzed = null;

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
            // Если имя слишком короткое
            if (fileName.Length < 8)
            {
                try
                {
                    IWebService webService = WebServiceFactory.Create();
                    webService.LogError("Слишком короткое имя файла: " + fileName);
                }
                catch (Exception ex)
                {
                    // Отправить сообщение по электроннной почте
                    IEmailService emailService = EmailServiceFactory.Create();
                    emailService.SendEmail("someone@somewhere.com", "невозможно вызвать веб сервис", ex.Message); //здесь можно сломать тест
                }
            }

            // Обработка лога
            // ...
            RaiseAnalyzedEvent();
        }

        public void RaiseAnalyzedEvent()
        {
            if (Analyzed != null)
            {
                Analyzed();
            }
        }
    }
}