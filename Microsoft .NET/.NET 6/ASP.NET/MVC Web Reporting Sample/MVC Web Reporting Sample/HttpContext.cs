using Microsoft.AspNetCore.Http;

namespace WebReporting
{
    public class HttpContext
    {
        private static IHttpContextAccessor _context;
        public static void Configure(IHttpContextAccessor context)
        {
            _context = context;
        }

        public static Microsoft.AspNetCore.Http.HttpContext Current => _context.HttpContext; 
    }
}
