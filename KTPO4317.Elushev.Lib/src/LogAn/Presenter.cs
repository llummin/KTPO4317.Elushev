using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4317.Elushev.Lib.src.LogAn
{
    public class Presenter
    {
        private ILogAnalyzer LogAnalyzer;
        private IView View; 

        public Presenter(ILogAnalyzer LogAnalyzer, IView View)
        {
            this.LogAnalyzer = LogAnalyzer;
            this.View = View;
            LogAnalyzer.Analyzed += OnLogAnalyzer;
        }

        private void OnLogAnalyzer()
        {
            View.Render("Обработка завершена");
        }
    }
}
