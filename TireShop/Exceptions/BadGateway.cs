using System.Net;

namespace TireShop.Exceptions
{
    public class BadGateway : LocalException
    {
        public BadGateway(string message = "BadGateway") : base(message, HttpStatusCode.BadGateway)
        {
        }
    }
}
