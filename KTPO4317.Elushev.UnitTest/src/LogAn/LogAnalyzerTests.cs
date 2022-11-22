using KTPO4317.Elushev.Lib.src.LogAn;
using NUnit.Framework;

namespace KTPO4317.Elushev.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {

        [TearDown]
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
            WebServiceFactory.SetWebService(null);
            EmailServiceFactory.SetEmailService(null);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            //Подготовка теста
            FakeWebService stubWebService = new FakeWebService();
            WebServiceFactory.SetWebService(stubWebService);
            stubWebService.WillThrow = new Exception("это подделка");

            FakeEmailService mockEmail = new FakeEmailService();
            EmailServiceFactory.SetEmailService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка ожидаемого результата
            StringAssert.Contains("someone@somewhere.com", mockEmail.To);
            StringAssert.Contains("это подделка", mockEmail.Body);
            StringAssert.Contains("невозможно вызвать веб сервис", mockEmail.Subject);
        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            //Подготовка теста
            FakeWebService mockWebService = new FakeWebService();
            WebServiceFactory.SetWebService(mockWebService);
            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка ожидаемого результата
            StringAssert.Contains("Слишком короткое имя файла: " + tooShortFileName, mockWebService.LastError);

        }
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            //Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            //..конфигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.ext");

            //Проверка ожидаемого результата
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_NoneSupportedExtension_ReturnsFalse()
        {
            //Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            //..конфигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.ext");

            //Проверка ожидаемого результата
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            //Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = new Exception();

            //..конфигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("short.ext");

            //Проверка ожидаемого результата
            Assert.False(result);
        }
    }

    /// <summary>Поддельный менеджер расширений</summary>

    internal class FakeExtensionManager : IExtensionManager
    {
        /// <summary>Это поле позволяет настроить
        /// поддельный результат для метода IsValid</summary>
        public bool WillBeValid = false;

        /// <summary>Это поле позволяет настроить
        /// поддельное исключение в методе IsValid</summary>
        public Exception? WillThrow = null;

        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            {
                return false;
            }

            return WillBeValid;
        }
    }

    /// <summary> Поддельная веб - служба </summary>
    internal class FakeWebService : IWebService
    {
        public string LastError;
        public Exception WillThrow;

        public void LogError(string message)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
            LastError = message;
        }
    }

    public class FakeEmailService : IEmailService
    {
        public string To;
        public string Subject;
        public string Body;

        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}