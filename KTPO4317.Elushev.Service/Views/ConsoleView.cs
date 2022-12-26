using KTPO4317.Elushev.Lib.src.LogAn;

namespace KTPO4317.Elushev.Service.src.Views
{
    public class ConsoleView : IView
    {
        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}
