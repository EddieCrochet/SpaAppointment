using SpaAppointment.Controllers;
using SpaAppointment.Data;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpaAppointment.Services
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly SpaContext _spaContext;
        private readonly IReadOnlySpaContext _readOnlySpaContext;
        public IQueryable<Appointment> Appointments => _spaContext.Appointments;

        public AppointmentRepository(SpaContext spaContext, IReadOnlySpaContext readOnlySpaContext)
        {
            _spaContext = spaContext;
            _readOnlySpaContext = readOnlySpaContext;
        }

        public bool isAppointmentAvailable(Appointment ProposedApp)
        {
            foreach (Appointment x in _spaContext.Appointments )
            {
                if (x.AppTime.ToString("{0:MM/dd/yyyy h:mm tt}") ==
                    ProposedApp.AppTime.ToString("{0:MM/dd/yyyy h:mm tt}"))
                {
                    if (x.ProviderId == ProposedApp.ProviderId)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public void Add(Appointment appointment)
        {
            _spaContext.Appointments.Add(appointment);
            _spaContext.SaveChanges();
        }

        public Appointment GetAppointment(int id)
        {
            return _spaContext.Appointments.First(SelectAppointmentById(id));
        }

        public void DeleteAppointment(int id)
        {
            var index = _spaContext.Appointments.First(SelectAppointmentById(id));
            _spaContext.Appointments.Remove(index);
            _spaContext.SaveChanges();
        }

        public void Update(int id, Appointment appointment)
        {
            appointment.Id = id;
            _spaContext.Appointments.Update(appointment);
            _spaContext.SaveChanges();
        }

        //Selector Functions
        private static Func<Appointment, bool> SelectAppointmentById(int id)
        {
            return App => App.Id == id;
        }
    }
}
