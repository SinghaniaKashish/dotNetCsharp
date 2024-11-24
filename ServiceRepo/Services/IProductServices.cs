using ServiceRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepo.Services
{
    internal interface IProductServices
    {
        public Product GetProductById(int id);
        public IEnumerable<Product> GetProductAll();
        public void AddProduct(Product p);
        public void UpdateProduct(Product p);
        public void DeleteProduct(Product p);
    }
}
