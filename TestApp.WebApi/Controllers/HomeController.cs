using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Services;
using TestApp.WebApi.Models;

namespace TestApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public HomeController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {

            return Ok("Ok");
            //return Ok(_productService.GetAll());
        }

        [HttpGet("new")]
        public IActionResult NewGet()
        {
            return Ok(_productService.GetProducts());
        }


        [HttpPost]
        public IActionResult Post([FromBody] ProductDto productDto)
        {

            if (productDto == null) return BadRequest();

            var product = _mapper.Map<Product>(productDto);

            _productService.Add(product);

            return StatusCode(StatusCodes.Status201Created);
        }


    }
}
