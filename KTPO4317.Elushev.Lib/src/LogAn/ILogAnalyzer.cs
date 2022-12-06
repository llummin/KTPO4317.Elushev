namespace KTPO4317.Elushev.Lib.src.LogAn
{
    public interface ILogAnalyzer
    {
        event LogAnalyzerAction Analyzed;

        void Analyze(string fileName);
        bool IsValidLogFileName(string fileName);
        void RaiseAnalyzedEvent();
    }
}