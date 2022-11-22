using KTPO4317.Elushev.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4317.Elushev.UnitTest.src.Sample
{
    public class SampleNSubstituteTests
    {
        [Test]

        public void Returns_ParticularArg_Works()
        {
            // Создаем поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            // Настраиваем объект, чтобы метод возвращал true для заданного зачения входного параметра
            fakeExtensionManager.IsValid("validfile.ext").Returns(true);

            // Воздействуем на тестируемый объект
            bool result = fakeExtensionManager.IsValid("validfile.ext");

            // Проверяем ожидаемый результат
            Assert.IsTrue(result);
        }

        [Test]

        public void Returns_ArgAny_Works()
        {
            // Создаем поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            // Настраиваем объект, чтобы метод возвращал true независимо от параметров
            fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);

            // Воздействуем на тестируемый объект
            bool result = fakeExtensionManager.IsValid("anyfile.ext");

            // Проверяем ожидаемый результат
            Assert.IsTrue(result);
        }

        [Test]

        public void Returns_ArgAny_Throws()
        {
            // Создаем поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            // Настраиваем объект, чтобы метод вызвал исключение, независимо от входных аргументов
            fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
                .Do(context => { throw new Exception("fake exception"); });

            // Проверяем, что было вызвано исключение
            Assert.Throws<Exception>(() => fakeExtensionManager.IsValid("anything"));
        }

        [Test]

        public void Received_ParticularArg_Saves()
        {
            // Создаем поддельный объект
            IWebService mockWebService = Substitute.For<IWebService>();

            // Воздействуем на поддельный объект
            mockWebService.LogError("Поддельное сообщение");

            // Проверяем, что поддельный объект сохранил параметры вызова
            mockWebService.Received().LogError("Поддельное сообщение");            
        }

    }
}
