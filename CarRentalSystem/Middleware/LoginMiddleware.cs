namespace CarRentalSystem.Middleware
{
    public class LoginMiddleware
    {
        private RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/test/public"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.ContainsKey("API-KEY"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API-KEY - NOT FOUND");
                return;
            }

            var apiKey = context.Request.Headers["API-KEY"];
            if (apiKey != "qwerty")
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Incorrect Key");
                return;
            }

            await _next(context);
        }
    }
}

