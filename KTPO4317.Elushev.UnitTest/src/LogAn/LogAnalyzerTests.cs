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
        public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
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
            fakeManager.WillBeValid = false;
            
            //..конфигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.extension");

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
                throw WillThrow;

            return WillBeValid;
        }
    }
}