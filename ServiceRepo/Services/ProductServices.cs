using ServiceRepo.Models;
using ServiceRepo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepo.Services
{
    internal class ProductServices: IProductServices
    {
        private readonly IProductRepository _productRepo;
        public ProductServices(IProductRepository productRepo)
        {
           _productRepo = productRepo;
        }
        public Product GetProductById(int id)
        {
            return _productRepo.GetById(id);
        }
        public IEnumerable<Product> GetProductAll()
        {
            return _productRepo.GetAll();
        }
        public void AddProduct(Product p)
        {
            _productRepo.Add(p);
        }
        public void UpdateProduct(Product p)
        {
            _productRepo.Update(p);
        }
        public void DeleteProduct(Product p)
        {
            _productRepo.Delete(p);
        }
    }
}
