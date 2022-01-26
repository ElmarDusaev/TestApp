using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Services;
using TestApp.WebApi.Controllers;
using Xunit;

namespace TestApp.Tests
{
    public class HomeControllerTest
    {


        [Fact]
        public void Post_ShouldReturnBadRequest()
        {
            HomeController controller = new HomeController(null, null);
            var result = controller.Post(null) as BadRequestResult;
            Assert.IsType<BadRequestResult>(result);
        }

    }
}
