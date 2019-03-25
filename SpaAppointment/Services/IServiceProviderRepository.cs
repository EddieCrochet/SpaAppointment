using System.Collections.Generic;
using System.Linq;
using SpaAppointment.Models;

namespace SpaAppointment.Services
{
    public interface IServiceProviderRepository
    {
        IQueryable<ServiceProvider> ServiceProviders { get; }

        void Add(ServiceProvider provider);
        void DeleteProvider(int id);
        List<Appointment> GetAppointmentsForProviderByDay(int providerId);
        ServiceProvider GetProvider(int id);
        bool ThisProviderExists(int id);
        void Update(int id, ServiceProvider provider);
    }
}