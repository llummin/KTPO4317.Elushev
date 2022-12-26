using KTPO4317.Elushev.Lib.src.LogAn;
using KTPO4317.Elushev.Lib.src.SampleCommands;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4317.Elushev.UnitTest.src.Decorator
{
    class ExceptionCommandDecoratorNSubstituteTests
    {
        [Test]
        public void Execute_WhenCalled_ExecutesDecoratedObjectMethod()
        {
            IView stubViev = Substitute.For<IView>();
            ISampleCommand mockDecoratedCommand = Substitute.For<ISampleCommand>();

            ISampleCommand commandDecorator = new ExceptionIntercepter(mockDecoratedCommand, stubViev);
            commandDecorator.Execute();

            mockDecoratedCommand.Received().Execute();
        }

        [Test]
        public void Execute_CommandThrowsException_PrintsMessage()
        {
            ISampleCommand stubCommand = Substitute.For<ISampleCommand>();
            stubCommand
                .When(x => x.Execute())
                .Do(context => { throw new Exception(); });

            IView mockView = Substitute.For<IView>();

            ISampleCommand commandDecorator = new ExceptionIntercepter(stubCommand, mockView);
            commandDecorator.Execute();
            mockView.Received().Render("Перехвачено исключение!");
        }
    }
}
