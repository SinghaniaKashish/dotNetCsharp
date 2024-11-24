using ServiceRepoAPITask.Models;
namespace ServiceRepoAPITask.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product>  products = new List<Product>();

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return Task.FromResult(products.AsEnumerable());
        }
        public Task<Product> GetProductById(int id)
        {
            var prod = products.Find(i => i.Id == id);
            return Task.FromResult(prod);
        }
        public Task Addproduct(Product p)
        {
            products.Add(p);
            return Task.CompletedTask;
        }
        public Task Updateproduct(Product p)
        {
            var prod = products.Find(i => i.Id == p.Id);
            if (prod != null)
            {
                prod.Name = p.Name;
                prod.Price = p.Price;
                prod.CreatedDate = DateTime.Now;
            }
            return Task.CompletedTask;
        }
        public Task Deleteproduct(int id)
        {
            var prod = products.Find(i => id == i.Id);
            if (prod != null)
            {
                products.Remove(prod);
            }
            return Task.CompletedTask;
        }
    }
}
