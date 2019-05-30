using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.ViewModels
{
    public class ServProAppVM
    {
        public IEnumerable<Appointment> appointments { get; set; }
        public IEnumerable<ServiceProvider> serviceProviders { get; set; }
    }
}
