namespace MiddlewareLogin.Middleware
{
    public class LoginMiddleware
    {
        /*
         * 1. public data  no api key required
         * 2. secured data - need api key
         *  a. no key
         *  b. incorrect key
         *  c. correct key  -- access data
         *  
         *  
         *  api key is passed on header
         */

        private RequestDelegate rd;
        public  LoginMiddleware(RequestDelegate rd)
        {
            this.rd = rd;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/test/public"))
            {
                await rd(context);
                return;
            }

            if (!context.Request.Headers.ContainsKey("API-KEY"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API-KEY - NOT FOUND");
                return;
            }

            var apikey = context.Request.Headers["API-KEY"];
            if(apikey != "qwerty")
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Incorrect Key");
                return;
            }

            await rd(context); 
        }

    }
}
