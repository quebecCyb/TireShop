using Newtonsoft.Json;
using TireShop.Exceptions;
using TireShop.Utils;
using TireShop.Utils.IP;

namespace TireShop.Middleware
{
    public class FirewallMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _blacklistedIps;
        private readonly string[] _whitelistedIps;

        public FirewallMiddleware( RequestDelegate next)
        {
            _next = next;
            _blacklistedIps = new string[0];
            _whitelistedIps = new string[0];
        }

        public async Task Invoke( HttpContext context )
        {
            if(_blacklistedIps.Contains(IP.GetIp(context))) {
                throw new Forbidden("IP is not allowed");
            }
            await _next(context);
        }
    }
}
