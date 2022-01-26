using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Repositories;

namespace TestApp.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public OrderService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public Task<Order> GetByIdAsync(int orderId)
        {
            return _unitOfWorks.OrderRepository.GetByIdAsync(orderId);
        }
    }
}
