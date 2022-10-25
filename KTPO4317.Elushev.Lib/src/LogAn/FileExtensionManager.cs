using System.Configuration;

namespace KTPO4317.Elushev.Lib.src.LogAn
{
    /// <summary>Менеджер расширений файлов</summary>
    public class FileExtensionManager : IExtensionManager
    {
        /// <summary>Проверка правильности расширения</summary>

        public bool IsValid(string fileName)
        {
            string configExtension = ConfigurationManager.AppSettings["goodExtension"];
            if (fileName.EndsWith(configExtension))
            {
                return true;
            }

            return false;
        }
    }
}
