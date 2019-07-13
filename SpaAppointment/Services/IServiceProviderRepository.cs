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
        List<Appointment> GetAppointmentsByProvider(int providerId);
        ServiceProvider GetProvider(int id);
        bool ThisProviderExists(int id);
        bool ProvNameFitsId(int id, string name);
        void Update(int id, ServiceProvider provider);
    }
}