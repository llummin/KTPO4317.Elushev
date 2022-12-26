using KTPO4317.Elushev.Lib.src.LogAn;
using KTPO4317.Elushev.Lib.src.SampleCommands;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4317.Elushev.UnitTest.src.Command
{
    class FirstCommandNSubstituteTests
    {
        [Test]
        public void Execute_WhenCalled_PrintsNumberOfCalls()
        {
            IView mockView = Substitute.For<IView>();
            ISampleCommand command = new FirstCommand(mockView);
            command.Execute();
            mockView.Received().Render("KTPO4317.Elushev.Lib.src.SampleCommands.FirstCommand\n iExecute = 1");
            command.Execute();
            mockView.Received().Render("KTPO4317.Elushev.Lib.src.SampleCommands.FirstCommand\n iExecute = 2");
        }
    }
}
