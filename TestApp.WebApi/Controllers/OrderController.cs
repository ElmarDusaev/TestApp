using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Services;
using TestApp.WebApi.Models;

namespace TestApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> Get()
        {
            var order = await _orderService.GetByIdAsync(1);
            var result = _mapper.Map<OrderDto>(order);
            
            return Ok(result);
        }
    }
}
