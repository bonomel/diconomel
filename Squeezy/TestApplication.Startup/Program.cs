using System;
using Diconomel.Startup.ServiceConsumers;
using Squeezy.Core;
using TestApplication.Startup.Services;

namespace TestApplication.Startup
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new DependencyContainer();

            container.AddTransient<PrintingService>();
            container.AddSingleton<MessageService>();
            container.AddSingleton<ServiceConsumer>();

            var resolver = new DependencyResolver(container);

            var consumerOne = resolver.GetService<ServiceConsumer>();
            consumerOne.PrintMessage();

            var consumerTwo = resolver.GetService<ServiceConsumer>();
            consumerTwo.PrintMessage();

            var consumerThree = resolver.GetService<ServiceConsumer>();
            consumerThree.PrintMessage();

            Console.ReadLine();
        }
    }
}
