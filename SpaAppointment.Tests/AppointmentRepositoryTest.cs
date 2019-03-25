using SpaAppointment.Models;
using SpaAppointment.Services;
using SpaAppointment.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace SpaAppointment.Tests
{
    public class AppointmentRepositoryTest
    {
        [Fact]
        public void CanAppointmentRepositoryAdd()    
        {
            // arrange
            var mockSpaContext = new Mock<SpaContext>(new DbContextOptionsBuilder<SpaContext>().Options);
            var mockReadOnlyContext = new Mock<IReadOnlySpaContext>();
            AppointmentRepository repo = new AppointmentRepository(mockSpaContext.Object, mockReadOnlyContext.Object);
            var testAppt = new Appointment()
            {
                AppTime = DateTime.Now,
                Id = 0,
                Description = "This is a test appointment",
                CustomerId = 1,
                ProviderId = 1
            };

            mockSpaContext.Setup(x => x.Appointments.Add(testAppt));
            mockSpaContext.Setup(x => x.SaveChanges());

            //act
            repo.Add(testAppt);

            // assert
            var a = repo.Appointments.FirstOrDefault(x => x.Id == testAppt.Id);
            Assert.NotNull(a);
        }
    }
}
