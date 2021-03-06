﻿using SpaAppointment.Data;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpaAppointment.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SpaContext _spaContext;
        private readonly IReadOnlySpaContext _readOnlySpaContext;
        public IQueryable<Customer> Customers => _spaContext.Customers.AsQueryable();

        public CustomerRepository(SpaContext spaContext, IReadOnlySpaContext readOnlySpaContext)
        {
            _spaContext = spaContext;
            _readOnlySpaContext = readOnlySpaContext;
        }

        //method allows me to add customers to my list
        public void Add(Customer customer)
        {
            _spaContext.Customers.Add(customer);
            _spaContext.SaveChanges();
        }

        public void Update(int id, Customer customer)
        {
            customer.Id = id;
            _spaContext.Customers.Update(customer);
            _spaContext.SaveChanges();
        }

        //to delete from the list
        public void DeleteCustomer(int id)
        {
            var index = _spaContext.Customers.First(SelectCustomerById(id));
            _spaContext.Customers.Remove(index);
            _spaContext.SaveChanges();
        }

        public Customer GetCustomer(int id)
        {
            return _spaContext.Customers.FirstOrDefault(SelectCustomerById(id));
        }

        public bool ThisCustomerExists(int id)
        {
            foreach(Customer cust in _spaContext.Customers)
            {
                if(cust.Id == id)
                return true;
            }
            return false;
        }

        public bool CustNameFitsId(int id, string name)
        {
            foreach (Customer cust in _spaContext.Customers)
            {
                if (cust.Id == id && cust.Name == name)
                return true;
            }
            return false;
        }

        //Selector Functions
        private static Func<Customer, bool> SelectCustomerById(int id)
        {
            return Customer => Customer.Id == id;
        }
    }
}
