using KTPO4317.Elushev.Lib.src.LogAn;

namespace KTPO4317.Elushev.Service
{
    public class Program
    {
        static void Main()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            if (analyzer.IsValidLogFileName("ff.htm"))
            {
                Console.WriteLine("Файл ff.htm с правильным расширением");
            }
            else
            {
                Console.WriteLine("Файл ff.htm с неправильным расширением");
            }

            if (analyzer.IsValidLogFileName("ff.html"))
            {
                Console.WriteLine("Файл ff.html с правильным расширением");
            }
            else
            {
                Console.WriteLine("Файл ff.html с неправильным расширением");
            }
        }
    }
}
