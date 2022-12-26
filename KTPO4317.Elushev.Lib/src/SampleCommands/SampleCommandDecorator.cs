using KTPO4317.Elushev.Lib.src.LogAn;

namespace KTPO4317.Elushev.Lib.src.SampleCommands
{
    public class SampleCommandDecorator : ISampleCommand
    {
        private readonly ISampleCommand sampleCommand;
        private readonly IView view;

        public SampleCommandDecorator(ISampleCommand sampleCommand, IView view)
        {
            this.sampleCommand = sampleCommand;
            this.view = view;
        }

        public void Execute()
        {
            view.Render("Начало: " + this.GetType().ToString());
            try
            {
                sampleCommand.Execute();
            }
            finally
            {
                view.Render("Конец: " + this.GetType().ToString());
            }
        }
    }
}
