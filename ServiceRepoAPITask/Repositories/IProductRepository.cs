using ServiceRepoAPITask.Models;
namespace ServiceRepoAPITask.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task Addproduct(Product p);
        Task Updateproduct(Product p);
        Task Deleteproduct(int id);

    }
}
