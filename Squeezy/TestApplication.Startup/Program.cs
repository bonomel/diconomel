using System;
using Diconomel.Startup.ServiceConsumers;
using Diconomel.Startup.Services;
using Squeezy.Core;

namespace TestApplication.Startup
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new DependencyContainer();

            container.AddDependency<PrintingService>();
            container.AddDependency<MessageService>();
            container.AddDependency<ServiceConsumer>();

            var resolver = new DependencyResolver(container);

            var consumer = resolver.GetService<ServiceConsumer>();
            
            consumer.PrintMessage();

            Console.ReadLine();
        }
    }
}
