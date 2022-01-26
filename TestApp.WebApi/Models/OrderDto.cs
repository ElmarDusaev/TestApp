using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.WebApi.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string StatusName { get; set; }
        public int Total { get; set; }
        public List<OrderDetailDto> OrderDetais { get; set; }
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public bool IsDeleted { get; set; }

    }
}
