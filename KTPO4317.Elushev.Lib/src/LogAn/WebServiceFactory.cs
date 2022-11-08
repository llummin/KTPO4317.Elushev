namespace KTPO4317.Elushev.Lib.src.LogAn
{
    public static class WebServiceFactory
    {
        private static IWebService webService;
        
        public static IWebService Create()
        {
            if (webService != null)
            {
                return webService;
            }
            return new WebService();
        }

        public static void SetWebService(IWebService web)
        {
            webService = web;
        }
    }
}
