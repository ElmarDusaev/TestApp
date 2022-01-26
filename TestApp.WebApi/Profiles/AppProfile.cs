using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.WebApi.Models;

namespace TestApp.WebApi.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<Order, OrderDto> ()
                .ForMember(x => x.StatusName, c => c.MapFrom(a => a.Status.Id == 1 ? "A": "I"))
                .ForMember(x => x.Id, c => c.MapFrom(a => a.Id))
                .ForMember(x => x.OrderDate, c => c.MapFrom(a => a.OrderDate))
                .ForMember(x=>x.OrderDetais, c=>c.MapFrom(a=>a.OrderDetails))
                .ForMember(x=>x.Total, c=>c.MapFrom(a=>a.OrderDetails.Sum(v=>v.Product.Price)));

            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(x => x.Id, c => c.MapFrom(a => a.Id))
                .ForMember(x => x.ProductName, c => c.MapFrom(a => a.Product.Name))
                .ForMember(x => x.ProductPrice, c => c.MapFrom(a => a.Product.Price))
                .ForMember(x => x.IsDeleted, c => c.MapFrom(c => c.IsDeleted));
        }

    }
}
