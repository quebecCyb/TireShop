using System.Net;

namespace TireShop.Exceptions
{
    public class NotFound : LocalException
    {
        public NotFound(string message = "Repository: Not Found - ") : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
