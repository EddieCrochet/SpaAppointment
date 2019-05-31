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
        //to access list of appointment and iterate through

        public Appointment appointment { get; set; }
        //to get name and properties of appointment class for table display

        public ServiceProvider serviceProvider { get; set; }
        //to access data from the service provider

        public Customer customer { get; set; }
        //to also access the customers data or info
    }
}
