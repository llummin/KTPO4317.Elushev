namespace KTPO4317.Elushev.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public LogAnalyzer()
        {

        }

        public bool IsValidLogFileName(string fileName)
        {
            return ExtensionManagerFactory.Create().IsValid(fileName);
        }
    }
}