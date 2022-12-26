using KTPO4317.Elushev.Lib.src.LogAn;

namespace KTPO4317.Elushev.Lib.src.SampleCommands
{
    public class SecondCommand : ISampleCommand 
    {
        private readonly IView view;

        private int iExecute = 0;

        public SecondCommand(IView view)
        {
            this.view = view;
        }

        public void Execute()
        {
            view.Render(this.GetType().ToString() + "\n iExecute = " + ++iExecute);
            throw new Exception();
        }
    }
}