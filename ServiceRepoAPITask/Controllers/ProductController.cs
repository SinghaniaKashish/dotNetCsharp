using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceRepoAPITask.Services;
using ServiceRepoAPITask.Models;

namespace ServiceRepoAPITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductServices prodserv;
        public ProductController(IProductServices prodserv)
        {
            this.prodserv = prodserv;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var prod = await prodserv.GetAll();
            return Ok(prod);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult< Product>> GetProductById(int id)
        {
            var prod = await prodserv.GetById(id);
            if(prod != null)
            {
                return Ok(prod);
            }
            return NotFound();
            
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product p)
        {
            await prodserv.Add(p);
            return CreatedAtAction(nameof(GetAllProducts), p);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(Product p)
        {
            await prodserv.Update(p);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await prodserv.Delete(id);
            return NoContent();
        }
    }
}
