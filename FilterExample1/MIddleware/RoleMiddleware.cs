using System.Security.Claims;

namespace FilterExample1.MIddleware
{
    public class RoleMiddleware
    {
        private RequestDelegate next;

        public RoleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].ToString();
            string role = "User";

            if(!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Role "))
            {
                var token = authHeader.Substring("Role ".Length).Trim(); //Role admin  --> admin
                if(token == "Admin")
                {
                    role = "Admin";
                }
            }

            var claims = new[] {new  Claim(ClaimTypes.Role, role)};
            var identity = new ClaimsIdentity(claims);
            var user = new ClaimsPrincipal(identity);

            context.User = user;

            await next(context);
        }
    }
}
