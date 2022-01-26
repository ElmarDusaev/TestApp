using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.WebApi.Models
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
