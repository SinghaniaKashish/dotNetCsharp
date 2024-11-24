using ServiceRepoAPITask.Models;
namespace ServiceRepoAPITask.Services
{
    public interface IProductServices
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task Add(Product p);
        public Task Update(Product p);
        public Task Delete(int id);
    }
}
