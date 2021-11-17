using System;

namespace Diconomel.Startup.Services
{
    public class PrintingService
    {
        private readonly MessageService messageService;

        public PrintingService(MessageService messageService)
        {
            this.messageService = messageService;
        }

        public void Print()
        {
            Console.WriteLine($"Message received by { nameof(PrintingService) }:\n{ MessageService.Message()}");
        }
    }
}
