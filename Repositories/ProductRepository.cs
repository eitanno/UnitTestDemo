using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Interfaces;
using UnitTestDemo.Models;

namespace UnitTestDemo.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public IEnumerable<Product> GetAll()
        {
            // This would normally fetch data from a database
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" }
            };
        }
    }
}
