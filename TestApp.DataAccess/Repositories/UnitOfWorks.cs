using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Repositories;

namespace TestApp.DataAccess.Repositories
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly Context _context;

        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        public UnitOfWorks(Context context)
        {
            _context = context;
        }

        public IOrderRepository OrderRepository { get {
                if (_orderRepository != null) return _orderRepository;
                _orderRepository = new OrderRepository(_context);
                return _orderRepository;
            } }

        public IProductRepository ProductRepository { get {
                if (_productRepository != null) return _productRepository;
                _productRepository = new ProductRepository(_context);
                return _productRepository;
            }  }


    }
}
