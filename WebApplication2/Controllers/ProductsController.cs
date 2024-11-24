using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Product> prodList = new List<Product>
        {
            new Product {Id=1, Name="Chocolate", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=2, Name="Ice", Price=105, CreatedDate = DateTime.Now},
            new Product {Id=3, Name="Chocolate1", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=4, Name="Ice1", Price=105, CreatedDate = DateTime.Now},
            new Product {Id=5, Name="Chocolate2", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=6, Name="Ice2", Price=105, CreatedDate = DateTime.Now},
            new Product {Id=7, Name="Chocolate3", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=8, Name="Ice3", Price=105, CreatedDate = DateTime.Now},
            new Product {Id=9, Name="Chocolate4", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=10, Name="Ice4", Price=105, CreatedDate = DateTime.Now},
            new Product {Id=11, Name="Chocolate5", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=12, Name="Ice5", Price=105, CreatedDate = DateTime.Now},
            new Product {Id=13, Name="Chocolate6", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=14, Name="Ice7", Price=105, CreatedDate = DateTime.Now},
            new Product {Id=15, Name="Chocolate8", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=16, Name="Ice9", Price=105, CreatedDate = DateTime.Now},
            new Product {Id=17, Name="Chocolate10", Price=135, CreatedDate = DateTime.Now},
            new Product {Id=18, Name="Ice10", Price=105, CreatedDate = DateTime.Now},

        };

        //1 get all data
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return prodList;
        }

        //2. getting the product with ID
        [HttpGet("{id}")]
        public ActionResult<Product> GetByID(int id)
        {
            var prod = prodList.Find(x => x.Id == id);
            if (prod == null)
            {
                return NotFound();
            }
            return prod;
        }

        //3. Add a product
        [HttpPost]
        public ActionResult<Product> AddProduct(Product p)
        {
            if (p.Price <= 0)
            {
                return BadRequest("Price can't br Negative");
            }
            //p.Id = prodList.Any() ? prodList.Max(i => i.Id) + 1 : 1;
            p.Id = prodList.Count + 1;

            //p.CreatedDate = DateTime.Now;

            prodList.Add(p);

            return CreatedAtAction(nameof(GetByID), new { id = p.Id }, p);
        }


        //4. Updating the Product - with ID
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var prod = prodList.Find(x => x.Id == id);
            if (prod == null)
            {
                return NotFound();
            }
            prod.Name = p.Name;
            prod.Price = p.Price;
            prod.CreatedDate = p.CreatedDate;

            return NoContent();
        }

        //5. delete the Product -- with ID
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var prod = prodList.Find(x => x.Id == id);
            if (prod == null)
            {
                return NotFound();
            }
            prodList.Remove(prod);
            return NoContent();
        }


        //6. filtering
        [HttpGet("filter")]
        //optional parameters
        public ActionResult<IEnumerable<Product>> getFilteredData(string? name, decimal? minPrice, decimal? maxPrice)
        {
            var res = prodList.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                // exact Match
                // res=res.Where(i=>i.Name==name);

                // case insensitive and partial Search
                res = res.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                res = res.Where(i => i.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                res = res.Where(i => i.Price <= maxPrice.Value);
            }

            return res.ToList();
        }

        //7. Filter based on date range
        [HttpGet("byDate")]
        public ActionResult<IEnumerable<Product>> getFilteredbyDate(DateTime startDate, DateTime endDate)
        {
            //var dateRes = prodlist.AsQueryable();

            var dateRes = prodList.Where(i => i.CreatedDate >= startDate && i.CreatedDate <= endDate).ToList();

            if (!dateRes.Any())
            {
                return NotFound();
            }
            if (startDate >= endDate)
            {
                return BadRequest("Start Date can't be greater than the end date");
            }
            if(startDate > DateTime.Today)
            {
                return BadRequest("Start date should be less than todays date");
            }

            return dateRes;

        }

        //8 sorting
        [HttpGet("sort")]
        public ActionResult <IEnumerable<Product>> SortProducts(string sortby = "name", string sortorder = "asc")
        {                                                       //default parameter
            var res = prodList.AsQueryable();

            if(sortby.ToLower() == "name")
            {
                res = sortorder.ToLower() == "asc" ? res.OrderBy(i => i.Name): res.OrderByDescending( i => i.Name);
            }
            else if(sortby.ToLower() == "price")
            {
                res = sortorder.ToLower() == "asc" ? res.OrderBy(i => i.Price) : res.OrderByDescending(i => i.Price);
            }

            return res.ToList();
        }

        //extra--> costliest product
        [HttpGet("maxx")]
        public ActionResult<Product> CostlyProduct()
        {
            var maxPrice = prodList.Max(i => i.Price);
            var res = prodList.Find(i => i.Price == maxPrice);
            if(res == null)
            {
                return NotFound();
            }

            return res;

        }

        //9 Bulk Addition of Products
        [HttpPost("bulk")]
        public ActionResult<IEnumerable<Product>> AddProducts(List<Product> p)
        {
            if(p == null || !p.Any())
            {
                return BadRequest("Empty List");
            }
            foreach (var s in p)
            {
                if(s.Price <= 0)
                {
                    continue;
                }
                s.Id = prodList.Count + 1;
                s.CreatedDate = DateTime.Now;
                prodList.Add(s);

            }
            return CreatedAtAction(nameof(GetAll), prodList);
        }

        //10 Bulk Updation of products
        [HttpPut("bulk")]
        public ActionResult<IEnumerable<Product>> UpdateProducts(List<Product> prod)
        {
            if (prod == null || !prod.Any())
            {
                return BadRequest("No products to update");
            }
            foreach (var p in prod)
            {
                var product = prodList.Find(i => i.Id == p.Id);

                if (product == null)
                {
                    continue;
                    //return NotFound();
                }
                product.Name = p.Name;
                product.Price = p.Price;
                product.CreatedDate = p.CreatedDate;
            }
            return CreatedAtAction(nameof(GetAll), prodList);
        }

        //11 bulk deletion 
        [HttpDelete("bulk")]

        public ActionResult<IEnumerable<Product>> UpdateProducts(List<int> ids)
        {
            
            if(ids == null || !ids.Any())
            {
                return BadRequest("No products to delete");
            }
            /*
            var res = prodList.Where(i => ids.Contains(i.Id)).ToList();

            if (!res.Any())
            {
                return NotFound("Ids not available");
            }
            foreach (var i in res)
            {
                prodList.Remove(i);   
            }
            */

            int removedItem = prodList.RemoveAll(i => ids.Contains(i.Id));
            if(removedItem < 1)
            {
                return NotFound("Ids not available");
            }
            return CreatedAtAction(nameof(GetAll), prodList);
        }

        //12 pagination
        [HttpGet("page")]
        public ActionResult<IEnumerable<Product>> GetPageData(int page = 1,int size = 5)
        {
            var res = prodList.Skip((page-1)*size).Take(size).ToList();
            return res;
        }

        //13  update by percentage
        [HttpPatch("hike")]
        public ActionResult<IEnumerable<Product>> PriceHike(int percent)
        {
            if(percent <= 0)
            {
                return BadRequest("percent should be greater than 0");
            }
            foreach (var item in prodList)
            {
                item.Price = item.Price +  ((item.Price * percent)/100);
            }
            return prodList;
        }

        //discount

        [HttpPatch("discount")]
        public ActionResult<IEnumerable<Product>> PriceHikes(int percent)
        {
            if(percent <= 0)
            {
                return BadRequest("percent should be greater than 0");
            }
            foreach (var item in prodList)
            {
                item.Price = item.Price - ((item.Price * percent) / 100);
            }
            return prodList;
        }


    }
}
