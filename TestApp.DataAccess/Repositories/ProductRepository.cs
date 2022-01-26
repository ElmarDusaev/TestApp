using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Repositories;

namespace TestApp.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
