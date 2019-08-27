using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Controllers;
using SpaAppointment.Services;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace SpaAppointment.Tests
{
    public class CustomerControllerTest
    {
        [Fact]
        public void CanCustomerControllerReturnIndexView()
        {
            //arrange
            var mockRepo = new Mock<ICustomerRepository>();
            var controller = new CustomerController(mockRepo.Object);
            mockRepo.Setup(x => x.Customers).Returns(new List<Customer>()
            {
                new Customer() {}
            }.AsQueryable());

            //act
            var result = controller.Index();

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CanCustomerControllerReturnDetailsView()
        {
            //arrange
            var mockServRepo = new Mock<IServiceProviderRepository>();
            var mockCustRepo = new Mock<ICustomerRepository>();
            var mockAppRepo = new Mock<IAppointmentRepository>();
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
