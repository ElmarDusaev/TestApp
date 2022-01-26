using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Repositories;

namespace TestApp.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public ProductService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public  void Add(Product product)
        {
            _unitOfWorks.ProductRepository.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWorks.ProductRepository.GetAll();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _unitOfWorks.ProductRepository.GetProducts();
        }
    }
}
