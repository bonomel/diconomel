using Diconomel.Startup.ServiceConsumers;
using Diconomel.Startup.Services;
using System;

namespace Diconomel.Startup
{
    public class Program
    {
        static void Main(string[] args)
        {
            var service = (PrintService)Activator.CreateInstance(typeof(PrintService));
            var consumer = (ServiceConsumer)Activator.CreateInstance(typeof(ServiceConsumer), service);

            consumer.Print();

            Console.ReadLine();
        }
    }
}
