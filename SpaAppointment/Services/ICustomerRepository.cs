using System.Linq;
using SpaAppointment.Models;

namespace SpaAppointment.Services
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }

        void Add(Customer customer);
        void DeleteCustomer(int id);
        Customer GetCustomer(int id);
        bool ThisCustomerExists(int id);
        void Update(int id, Customer customer);
    }
}