using Newtonsoft.Json;
using TireShop.Exceptions;
using TireShop.Utils;

namespace TireShop.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (LocalException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, new BadGateway(ex.Message));
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, LocalException ex)
        {
            var result = JsonConvert.SerializeObject(new ResponseFormat <Array> { Message = ex.Message, Status = ex.Status });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)ex.Status < 500 ? (int)ex.Status : 400;
            return context.Response.WriteAsync(result);
        }

    }
}
