using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Repositories;
using TestApp.Domain.Services;

namespace TestApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _prodictRepositories;

        public ProductService(IProductRepository prodictRepositories)
        {
            this._prodictRepositories = prodictRepositories;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _prodictRepositories.GetProducts();
        }
    }
}
