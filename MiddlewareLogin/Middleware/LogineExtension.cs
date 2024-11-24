namespace MiddlewareLogin.Middleware
{
    public static class LogineExtension
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoginMiddleware>();
        }
    }
}
       