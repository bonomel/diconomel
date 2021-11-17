using Diconomel.Startup.ServiceConsumers;
using Diconomel.Startup.Services;
using System;

namespace Diconomel.Startup
{
    public class Program
    {
        static void Main(string[] args)
        {
            var service = new PrintService();
            var consumer = new ServiceConsumer(service);

            consumer.Print();

            Console.ReadLine();
        }
    }
}
