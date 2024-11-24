using FilterExample1.Filters;
using FilterExample1.Models;
using FilterExample1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilterExample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("admin-only")]
        [TransactionLog]
        [RoleAuthorize("Admin")]

        public IActionResult GetAdminData()
        {
            return Ok("Accessible only to admin");
        }

        [HttpGet("user-only")]
        [TransactionLog]
        [RoleAuthorize("User")]

        public IActionResult GetUserData()
        {
            return Ok("Accessible only to user");
        }


        [HttpGet("all")]
        [TransactionLog]

        public IActionResult GetData()
        {
            return Ok("Accessible only to all");
        }

        [HttpGet("logs")]
        public IActionResult GetLogs(TransactionLogService transactionLogService)
        {
            var logs = transactionLogService.GetTransactions();
            return Ok(logs);
        }
        [HttpPost]
        [ValidationFilter]
        public IActionResult CreateProduct(Product p)
        {
            return Ok(p);
        }
    }
}
