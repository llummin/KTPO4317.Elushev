#nullable disable
using KTPO4317.Elushev.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4317.Elushev.UnitTest.src.LogAn
{
    public class LogAnalyzerNSubstituteTests
    {
        [TearDown]
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
            WebServiceFactory.SetWebService(null);
            EmailServiceFactory.SetEmailService(null);
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            // Создаем поддельный объект
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();

            // Настраиваем объект, чтобы метод возвращал true независимо от параметров
            fakeManager.IsValid(Arg.Any<string>()).Returns(true);

            ExtensionManagerFactory.SetManager(fakeManager);

            // Воздействуем на тестируемый объект
            bool result = fakeManager.IsValid("short.ext");

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_NoneSupportedExtension_ReturnsFalse()
        {
            // Создаем поддельный объект
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();

            // Настраиваем объект, чтобы метод возвращал false независимо от параметров
            fakeManager.IsValid(Arg.Any<string>()).Returns(false);

            ExtensionManagerFactory.SetManager(fakeManager);

            // Воздействуем на тестируемый объект
            bool result = fakeManager.IsValid("short.ext");

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            //Проверка ожидаемого результата
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            // Создаем поддельный объект
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();

            // Настраиваем объект, чтобы метод вызвал исключение, независимо от входных аргументов
            fakeManager
                .When(x => x.IsValid(Arg.Any<string>()))
                .Do(context => { throw new Exception("fake exception"); });

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("short.ext");
            Assert.False(result);
        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            //Подготовка теста
            IWebService mockWebService = Substitute.For<IWebService>();
            WebServiceFactory.SetWebService(mockWebService);
            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            mockWebService.Received().LogError("Слишком короткое имя файла: " + tooShortFileName);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            Exception exception = new Exception();

            IWebService stubWebService = Substitute.For<IWebService>();
            stubWebService
                .When(x => x.LogError(Arg.Any<String>()))
                .Do(context => { throw exception; });
            WebServiceFactory.SetWebService(stubWebService);

            IEmailService mockEmail = Substitute.For<IEmailService>();
            EmailServiceFactory.SetEmailService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            mockEmail.Received().SendEmail("someone@somewhere.com", "невозможно вызвать веб сервис", exception.Message);
        }
    }
}
