using KTPO4317.Elushev.Lib.src.LogAn;
using KTPO4317.Elushev.Lib.src.SampleCommands;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4317.Elushev.UnitTest.src.Decorator
{
    class SampleCommandDecoratorTestsNSubstituteTests
    {
        [Test]
        public void Execute_WhenCalled_ExecutesDecoratedObjectMethod()
        {
            IView stubViev = Substitute.For<IView>();
            ISampleCommand mockDecoratedCommand = Substitute.For<ISampleCommand>();

            ISampleCommand commandDecorator = new SampleCommandDecorator(mockDecoratedCommand, stubViev);
            commandDecorator.Execute();

            mockDecoratedCommand.Received().Execute();
        }

        [Test]
        public void Execute_WhenCalled_PrintsMessage()
        {
            ISampleCommand stubCommand = Substitute.For<ISampleCommand>();
            IView mockView = Substitute.For<IView>();

            ISampleCommand commandDecorator = new SampleCommandDecorator(stubCommand, mockView);
            commandDecorator.Execute();
            mockView.Received().Render("Начало: KTPO4317.Elushev.Lib.src.SampleCommands.SampleCommandDecorator");
            mockView.Received().Render("Конец: KTPO4317.Elushev.Lib.src.SampleCommands.SampleCommandDecorator");
        }

    }
}
