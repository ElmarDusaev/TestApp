using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Services
{
    public interface IProductService 
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetProducts();
        void Add(Product product);
    }
}
