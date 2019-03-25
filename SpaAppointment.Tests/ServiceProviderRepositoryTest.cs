using Moq;
using SpaAppointment.Data;
using SpaAppointment.Models;
using SpaAppointment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SpaAppointment.Tests
{
    public class ServiceProviderRepositoryTest
    {
        [Fact]
        public void CanServiceProviderRepositoryDeleteProvider()
        {
            //arrange
            var mockSpaContext = new Mock<SpaContext>(null);
            var mockReadOnlySpaContext = new Mock<IReadOnlySpaContext>();
            ServiceProviderRepository repo = new ServiceProviderRepository(
                mockSpaContext.Object, mockReadOnlySpaContext.Object);
            var testProvider = new ServiceProvider()
            {
                Id = 10,
                Name = "NoHands McGee"
            };

            //act
            repo.Add(testProvider);
            repo.DeleteProvider(testProvider.Id);

            //assert
            var p = repo.ServiceProviders.FirstOrDefault(x => x.Id == testProvider.Id);
            Assert.Null(p);
        }
    }
}
