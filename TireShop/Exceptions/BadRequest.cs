using System.Net;

namespace TireShop.Exceptions
{
    public class BadRequest : LocalException
    {
        public BadRequest(string message = "BadRequest") : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
