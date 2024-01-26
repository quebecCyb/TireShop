using System.Net;

namespace TireShop.Exceptions
{
    public class NotEnoughBalance : LocalException
    {
        public NotEnoughBalance(string message = "Not Enough Balance On External API") : base(message, HttpStatusCode.BadGateway)
        {
        }
    }
}
