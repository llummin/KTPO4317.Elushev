namespace KTPO4317.Elushev.Lib.src.LogAn
{
    /// <summary>Фабрика диспетчеров расширений файлов</summary>

    public static class ExtensionManagerFactory
    {
        private static IExtensionManager? customManager;

        /// <summary>Создание объектов</summary>

        public static IExtensionManager Create()
        {
            if (customManager != null)
            {
                return customManager;
            }
            return new FileExtensionManager();
        }
        /// <summary>Метод позволит тестам контролировать, 
        /// что возвращает фабрика</summary>
        /// <param name="mgr"></param>

        public static void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
    }
}
