using System.Net;

namespace TireShop.Exceptions
{
    public class Forbidden : LocalException
    {
        public Forbidden(string message = "Forbidden") : base(message, HttpStatusCode.Forbidden)
        {
        }
    }
}
