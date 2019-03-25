using Microsoft.AspNetCore.Mvc;
using System;
using Moq;
using SpaAppointment.Controllers;
using SpaAppointment.Models;
using SpaAppointment.Services;
using System.Collections.Generic;
using Xunit;

namespace SpaAppointment.Tests
{
    public class AppointmentControllerTest
    {
        [Fact]
        public void CanAppointmentControllerCreate_AppointIsAdded()
        {
            //arrange
            var mockServRepo = new Mock<IServiceProviderRepository>();
            var mockAppRepo = new Mock<IAppointmentRepository>();
            var mockCustRepo = new Mock<ICustomerRepository>();
            var controller = new AppointmentController(mockAppRepo.Object,
                mockCustRepo.Object, mockServRepo.Object);
            var testApp = new Appointment()
            {
                AppTime = DateTime.Now,
                Id = 0,
                Description = "This is a test appointment",
                CustomerId = 1,
                ProviderId = 1
            };
            mockAppRepo.Setup(x => x.isAppointmentAvailable(testApp)).Returns(true);
            mockCustRepo.Setup(x => x.ThisCustomerExists(testApp.CustomerId)).Returns(true);
            mockServRepo.Setup(x => x.ThisProviderExists(testApp.ProviderId)).Returns(true);
            //act
            var result = controller.Create(testApp);

            //assert
            Assert.NotNull(testApp);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
