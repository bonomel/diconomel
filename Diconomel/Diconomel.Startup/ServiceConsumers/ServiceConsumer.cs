using Diconomel.Startup.Services;

namespace Diconomel.Startup.ServiceConsumers
{
    public class ServiceConsumer
    {
        private readonly PrintingService printService;

        public ServiceConsumer(PrintingService printService) 
        {
            this.printService = printService;
        }

        public void PrintMessage()
        {
            printService.Print();
        }
    }
}
