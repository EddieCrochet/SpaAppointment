using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xunit;

namespace SpaAppointmentTests
{
    public class AppointmentControllerTest
    {
        [Fact]
        public void CanApptContCreate()
        {
            //Arrange
            var ApptList = new List<Appointment>();
            var ApptCont = new AppointmentController(ApptList);

            //Act
            ApptCont.Add(new Appointment
            {

            });

            //Assemble
        }
    }
}
