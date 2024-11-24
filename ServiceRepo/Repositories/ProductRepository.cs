using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceRepo.Models;
using ServiceRepo.Repositories;
using ServiceRepo.Services;

namespace ServiceRepo.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>
            {
                new Product {Id = 1, Name = "coco", Price=100, CreatedDate = DateTime.Now},
                new Product {Id = 2, Name = "ice", Price=200, CreatedDate = DateTime.Now}

            };
        }

        public Product GetById(int id)
        {
            return products.Find(i => i.Id == id);
        }
        public IEnumerable<Product> GetAll()
        {
            return products;
        }
        public void Add(Product p)
        {
            products.Add(p);
        }
        public void Update(Product p)
        {
            var prod = products.Find(i => i.Id == p.Id);
            if (prod != null)
            {
                prod.Name = p.Name;
                prod.Price = p.Price;
                prod.CreatedDate = p.CreatedDate;
            }

        }
        public void Delete(Product p)
        {
            products.Remove(p);
        }

    }
}
