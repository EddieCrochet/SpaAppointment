using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SpaAppointment.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void CanHomeControllerReturnPrivacyView()
        {
            //arrange
            var controller = new HomeController();

            //act
            var result = controller.Privacy();

            //assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
