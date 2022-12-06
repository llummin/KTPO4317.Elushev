using KTPO4317.Elushev.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4317.Elushev.UnitTest.src.LogAn
{
    public class PresenterTests
    {
        /// <summary> Если вызвано событие, то класс вызывает отображение </summary>
        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender()
        {
            FakeLogAnalyzer stubLogAnalyzer = new FakeLogAnalyzer();
            IView mockView = Substitute.For<IView>();
            Presenter presenter = new Presenter(stubLogAnalyzer, mockView);

            stubLogAnalyzer.CallRaiseAnalyzedEvent();

            mockView.Received().Render("Обработка завершена");
        }

        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute()
        {
            ILogAnalyzer stubLogAnalyzer = Substitute.For<ILogAnalyzer>();
            IView mockView = Substitute.For<IView>();

            Presenter presenter = new Presenter(stubLogAnalyzer, mockView);

            stubLogAnalyzer.Analyzed += Raise.Event<LogAnalyzerAction>();

            mockView.Received().Render("Обработка завершена");
        }
    }

    class FakeLogAnalyzer : LogAnalyzer
    {
        public void CallRaiseAnalyzedEvent()
        {
            base.RaiseAnalyzedEvent();
        }
    }
}
