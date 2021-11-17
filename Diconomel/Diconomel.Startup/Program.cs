using Diconomel.Core;
using Diconomel.Startup.ServiceConsumers;
using Diconomel.Startup.Services;
using System;

namespace Diconomel.Startup
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new DependencyContainer();
            container.AddDependency(typeof(PrintingService));
            container.AddDependency<ServiceConsumer>();

            var resolver = new DependencyResolver(container);

            var consumer = resolver.GetService<ServiceConsumer>();
            
            consumer.Print();

            Console.ReadLine();
        }
    }
}
