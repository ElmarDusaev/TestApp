using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<Order> GetByIdAsync(int orderId);
    }
}
