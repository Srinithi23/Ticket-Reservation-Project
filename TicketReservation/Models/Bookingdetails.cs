using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservation.Models
{
    public class Bookingdetails
    {
       // [Range(0, 40000, ErrorMessage = "Enter the salary less than 40000/No negative numbers")]
       [Required]
        public int BookingId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]

        public string EmailId { get; set; }
        [Required]

        public int? TrainNo { get; set; }
        [Required]

        [DataType(DataType.Text)]

        public string FromStation { get; set; }
        [Required]

        [DataType(DataType.Text)]

        public string ToStation { get; set; }
        [Required]

        [DataType(DataType.Date)]
        [Remote("DateCheck", "BookingDetail",
               ErrorMessage = "Give Valid Date")]
        public DateTime? JourneyDate { get; set; }
        [Required]

        [Range(0, 50, ErrorMessage = "Enter the seats less than 50/No negative numbers")]

        public int? NoOfSeats { get; set; }
        [Required]

        public string BookingStatus { get; set; }

    }
}
