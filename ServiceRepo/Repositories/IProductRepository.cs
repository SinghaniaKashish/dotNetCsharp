using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceRepo.Models;

namespace ServiceRepo.Repositories
{
    internal interface IProductRepository
    {
        public Product GetById(int id);
        public IEnumerable<Product> GetAll();
        public void Add(Product p);
        public void Update(Product p);
        public void Delete(Product p);

    }
}
