using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.ViewModels
{
    public class ServProAppVM
    {
        public Appointment appointment { get; set; }
        public ServiceProvider serviceProvider { get; set; }
    }
}
