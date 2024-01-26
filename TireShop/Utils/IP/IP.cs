namespace TireShop.Utils.IP
{
    public static class IP
    {
        public static string GetIp(HttpContext context)
        {
            return context.Request.Headers["X-Forwarded-For"].ToString() ?? "";
        }
    }
}
