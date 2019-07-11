using Microsoft.AspNetCore.Mvc;
using Moq;
using SpaAppointment.Controllers;
using SpaAppointment.Models;
using SpaAppointment.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SpaAppointment.Tests
{
    public class ServiceProviderControllerTest
    {
        [Fact]
        public void CanServiceProviderControllerViewDetails()
        {
            //arrange
            var mockServRepo = new Mock<IServiceProviderRepository>();
            var mockCustRepo = new Mock<ICustomerRepository>();
            var mockAppRepo = new Mock<IAppointmentRepository>();
            //needed to have all repos passed in to my mock controller
            var controller = new ServiceProviderController(mockServRepo.Object,
                mockCustRepo.Object, mockAppRepo.Object);
            var testProvider = new ServiceProvider();

            //act
            var result = controller.Details(testProvider.Id);

            //assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
