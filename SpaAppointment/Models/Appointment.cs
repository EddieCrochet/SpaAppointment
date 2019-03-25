using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
