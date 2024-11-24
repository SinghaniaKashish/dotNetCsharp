using Microsoft.AspNetCore.Mvc.Filters;
using FilterExample1.Services;
using System.Reflection.Metadata.Ecma335;
namespace FilterExample1.Filters
{
    public class TransactionLogAttribute : ActionFilterAttribute
    {
        //on action executing
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var res = context.HttpContext.RequestServices.GetService<TransactionLogService>();

            var user = context.HttpContext.User.Identity?.Name ?? "Unknown User";
            var endpoint = context.HttpContext.Request.Path;
            var method = context.HttpContext.Request.Method;

            //Functions from service to be retrived
            res.LogTransaction($"User:{user} accessed the {endpoint} with method {method}");

        }
    }
}
