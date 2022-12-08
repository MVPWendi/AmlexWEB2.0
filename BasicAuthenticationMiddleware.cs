using AmlexWEB.Services;

namespace AmlexWEB
{
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<BasicAuthenticationMiddleware> _logger;
        public BasicAuthenticationMiddleware(RequestDelegate next, ILogger<BasicAuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().Contains("api") == false) await _next.Invoke(context);
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                var token = authHeader.Substring("Basic ".Length).Trim();
                var credentials = token.Split(':');
                if (credentials[0]=="Amlex" && credentials[1]=="123456q")
                {
                    await _next.Invoke(context);
                    return;

                }
                context.Response.StatusCode = 401;
                return;

            }
            context.Response.StatusCode = 401;
            return;

        }
    }
}
