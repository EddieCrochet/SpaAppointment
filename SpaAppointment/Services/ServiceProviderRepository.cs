using SpaAppointment.Data;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpaAppointment.Services
{
    public class ServiceProviderRepository : IServiceProviderRepository
    {
        private readonly SpaContext _spaContext;
        private readonly IReadOnlySpaContext _readOnlySpaContext;
        public IQueryable<ServiceProvider> ServiceProviders => _spaContext.ServiceProviders;

        public ServiceProviderRepository(SpaContext spaContext, IReadOnlySpaContext readOnlySpaContext)
        {
            _spaContext = spaContext;
            _readOnlySpaContext = readOnlySpaContext;
        }

        public void Add(ServiceProvider provider)
        {
            _spaContext.ServiceProviders.Add(provider);
            _spaContext.SaveChanges();
        }

        public void Update(int id, ServiceProvider provider)
        {
            provider.Id = id;
            _spaContext.ServiceProviders.Update(provider);
            _spaContext.SaveChanges();
        }

        //to delete from the list
        public void DeleteProvider(int id)
        {
            var index = _spaContext.ServiceProviders.First(SelectProviderById(id));
            _spaContext.ServiceProviders.Remove(index);
            _spaContext.SaveChanges();
        }


        //List method to return service providers for one certain provider by day
        public List<Appointment> GetAppointmentsForProviderByDay(int providerId)
        {
            return _spaContext.Appointments
                .Where(x => x.ProviderId == providerId)
                .OrderBy(x => x.AppTime)
                .ToList();
        }

        public ServiceProvider GetProvider(int id)
        {
            return _spaContext.ServiceProviders.Single(SelectProviderById(id));
        }

        public bool ThisProviderExists(int id)
        {
            foreach(ServiceProvider serv in _spaContext.ServiceProviders)
            {
                if (serv.Id == id)
                return true;
            }
            return false;
        }

        //Selector Functions
        private static Func<ServiceProvider, bool> SelectProviderById(int id)
        {
            return ServiceProviders => ServiceProviders.Id == id;
        }
    }
}
