using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservation.Models
{
    public class TrainDetail
    {
        [Required]
        public int TrainNo { get; set; }
        [Required]

        public string TrainName { get; set; }
        [Required]
        public string FromStation { get; set; }
        [Required]
        public string ToStation { get; set; }
        [Required]

        public DateTime? JourneyDate { get; set; }
        [Required]
        public int? SeatAvailA { get; set; }
        [Required]
        public int? SeatAvailB { get; set; }
        [Required]
        public int? SeatAvailC { get; set; }
        [Required]
        public int? FareA { get; set; }
        [Required]
        public int? FareB { get; set; }
        [Required]
        public int? FareC { get; set; }
      


    }
}
