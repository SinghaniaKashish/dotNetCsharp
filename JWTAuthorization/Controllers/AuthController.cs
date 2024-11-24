using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWTAuthorization.Models;
using JWTAuthorization.Data;
using Microsoft.AspNetCore.Authorization;

namespace JWTAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext context;

        public AuthController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize(Roles ="User, Admin")]
        public IActionResult GetProducts()
        {
            var res = context.Products.ToList();
            return Ok(res);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    var t = new Transaction
                    {
                        ProductId = product.Id,
                        Action = "ADD",
                        Timestamp = DateTime.Now
                    };
                    context.Transactions.Add(t);
                    context.SaveChanges();

                    trans.Commit();
                    return Ok();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return StatusCode(500, "error Occured");
                }
            }            
        }
    }
}
