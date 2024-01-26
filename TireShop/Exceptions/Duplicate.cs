using System.Net;

namespace TireShop.Exceptions
{
    public class Duplicate : BadRequest
    {
        public Duplicate(string message = "Repository: Duplicate") : base(message)
        {
        }
    }
}
