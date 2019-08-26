using Microsoft.EntityFrameworkCore;
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
    public class CustomerRepositoryTest
    {
        [Fact]
        public void CanCustomerRepositoryGetCustomer()
        {
            //arrange
            var mockReadOnlyContext = new Mock<IReadOnlySpaContext>();
            var mockSpaContext = new Mock<SpaContext>(new DbContextOptionsBuilder<SpaContext>().Options);
            CustomerRepository repo = new CustomerRepository(mockSpaContext.Object, mockReadOnlyContext.Object);
            var testCustomer = new Customer()
            {
                Name = "Jay Winn",
                Id = 10
            };

            mockSpaContext.Setup(x => x.Customers.Add(testCustomer));
            mockSpaContext.Setup(x => x.SaveChanges());

            //act
            repo.Add(testCustomer);

            //assert
            var c = repo.GetCustomer(testCustomer.Id);
            Assert.NotNull(c);
        }
    }
}
