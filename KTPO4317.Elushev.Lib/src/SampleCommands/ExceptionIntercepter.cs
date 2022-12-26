using KTPO4317.Elushev.Lib.src.LogAn;

namespace KTPO4317.Elushev.Lib.src.SampleCommands
{
    public class ExceptionIntercepter : ISampleCommand
    {
        private readonly ISampleCommand sampleCommandDecorator;
        private readonly IView view;

        public ExceptionIntercepter(ISampleCommand sampleCommandDecorator, IView view)
        {
            this.sampleCommandDecorator = sampleCommandDecorator;
            this.view = view;
        }

        public void Execute()
        {
            try
            {
                sampleCommandDecorator.Execute();
            }
            catch
            {
                view.Render("Перехвачено исключение!");
            }
        }
    }
}
