namespace Diconomel.Startup.Services
{
    public class MessageService
    {
        public static string Message()
        {
            return $"{ nameof(MessageService) } sends its regards!";
        }
    }
}
