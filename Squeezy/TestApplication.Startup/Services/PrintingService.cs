using System;

namespace TestApplication.Startup.Services
{
    public class PrintingService
    {
        private readonly MessageService _messageService;

        public PrintingService(MessageService messageService)
        {
            this._messageService = messageService;
        }

        public void Print()
        {
            Console.WriteLine($"Message received by { nameof(PrintingService) }:\n{ _messageService.Message()}");
        }
    }
}
