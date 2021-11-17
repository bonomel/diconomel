using Diconomel.Startup.Services;

namespace Diconomel.Startup.ServiceConsumers
{
    public class ServiceConsumer
    {
        private readonly PrintService printService;

        public ServiceConsumer(PrintService printService) 
        {
            this.printService = printService;
        }

        public void Print()
        {
            printService.Print();
        }
    }
}
