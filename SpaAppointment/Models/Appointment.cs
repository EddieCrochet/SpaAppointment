using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SpaAppointment.Services;

namespace SpaAppointment.Models
{
    public class Appointment
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}")]
        public DateTime AppTime { get; set; }

        public int Id { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int ProviderId { get; set; }
        public string CustomerName { get; set; }
        public string ProviderName { get; set; }

        public Appointment()
        {
            //Need to find a way to set cust and servpro NAMES in THIS class...
            //get this data from the ID plugged into Appointment somehow??
            
        }
    }
}
