using Newtonsoft.Json;
using TireShop.Exceptions;
using TireShop.Schemas.Auth;
using TireShop.Utils;
using TireShop.Utils.IP;
using System.Linq;

namespace TireShop.Middleware
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate _next;
        Dictionary<string, int> requests = new Dictionary<string, int>();
        Dictionary<string, int> limits = new Dictionary<string, int>();

        public AuthorizeMiddleware( RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke( HttpContext context )
        {
            var role = context.User.Claims.First(c => c.Type == AuthTypes.Role);
            var email = context.User.Claims.First(c => c.Type == AuthTypes.Email);

            int limit = limits.TryGetValue(role.Value, out int result)
            ? result
            : -1;

            if (requests.TryGetValue(email.Value, out int valueForKey))
            {
                requests[email.Value] = 0;
            }

            if (limit != -1 && requests[email.Value] >= limit) {
                throw new Forbidden("Limit is Reached");
            }

            requests[email.Value]++;

            await _next(context);
        }
    }
}
