using System.Linq;
using SpaAppointment.Models;

namespace SpaAppointment.Services
{
    public interface IAppointmentRepository
    {
        IQueryable<Appointment> Appointments { get; }

        void Add(Appointment appointment);
        void DeleteAppointment(int id);
        Appointment GetAppointment(int id);
        bool isAppointmentAvailable(Appointment ProposedApp);
        void Update(int id, Appointment appointment);
    }
}