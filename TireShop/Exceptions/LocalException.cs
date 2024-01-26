using System.Net;

namespace TireShop.Exceptions
{
    public class LocalException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public LocalException(string message, HttpStatusCode Status) : base(message)
        {
            this.Status = Status;
        }
    }
}
