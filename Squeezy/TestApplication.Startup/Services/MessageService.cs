using System;

namespace TestApplication.Startup.Services
{
    public class MessageService
    {
        private readonly int _random;

        public MessageService()
        {
            _random = new Random().Next();
        }

        public string Message()
        {
            return $"{ nameof(MessageService) } sends its { _random } regards!";
        }
    }
}
