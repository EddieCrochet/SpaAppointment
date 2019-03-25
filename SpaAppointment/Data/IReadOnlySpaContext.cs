using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.Data
{
    public interface IReadOnlySpaContext
    {
        IQueryable<Appointment> Appointments { get; }
        IQueryable<Customer> Customers { get; }
        IQueryable<ServiceProvider> ServiceProviders { get; }
    }
}
