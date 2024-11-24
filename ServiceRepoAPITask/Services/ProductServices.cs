using ServiceRepoAPITask.Models;
using ServiceRepoAPITask.Repositories;

namespace ServiceRepoAPITask.Services
{
    public class ProductServices: IProductServices 
    {
        private IProductRepository prodrepo;

        public ProductServices(IProductRepository prodrepo)
        {
            this.prodrepo = prodrepo;
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return prodrepo.GetAllProducts();
        }

        public Task<Product> GetById(int id)
        {
            return prodrepo.GetProductById(id);
        }
        public Task Add(Product p)
        {
            return prodrepo.Addproduct(p);
        }
        public Task Update(Product p)
        {
            return prodrepo.Updateproduct(p);
        }
        public Task Delete(int id)
        {
            return prodrepo.Deleteproduct(id);
        }
    }
}
