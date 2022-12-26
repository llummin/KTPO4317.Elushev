using KTPO4317.Elushev.Lib.src.Common;
using KTPO4317.Elushev.Lib.src.SampleCommands;
using KTPO4317.Elushev.Service.src.WindsorInstallers;

namespace KTPO4317.Elushev.Service
{
    public class Program
    {
        static void Main()
        {
            CastleFactory.container.Install(
                new SampleCommandInstaller(),
                new ViewInstaller()
                );

            for (int i = 0; i < 3; i++)
            {
                ISampleCommand sampleCommand = CastleFactory.container.Resolve<ISampleCommand>();
                sampleCommand.Execute();
            }
        }
    }
}
