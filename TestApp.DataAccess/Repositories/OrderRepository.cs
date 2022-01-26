using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Repositories;

namespace TestApp.DataAccess.Repositories
{
    public class OrderRepository: Repository<Order>, IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context):base(context)
        {
            _context = context;
        }

        public Task<Order> GetByIdAsync(int orderId)
        {
            return _context.Orders
                .Include(x=>x.Status)
                .Include(x=>x.OrderDetails)
                .ThenInclude(x=>x.Product)
                .AsNoTracking()
                .FirstAsync(x => x.Id == orderId);
        }
    }
}
