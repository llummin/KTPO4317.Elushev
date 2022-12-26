using Castle.Windsor;

namespace KTPO4317.Elushev.Lib.src.Common
{
    public static class CastleFactory
    {
        /// <summary> Контейнер </summary>
        public static IWindsorContainer container { get; private set; }

        static CastleFactory()
        {
            // Создать объект контейнер
            container = new WindsorContainer();
        }
    }
}
