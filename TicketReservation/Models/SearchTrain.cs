using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservation.Models
{
    public class SearchTrain
    {
        [Required]
        public string FromStation { get; set; }
        [Required]
        public string ToStation { get; set; }
       /* public string searchTrain { get; set; }*/
    }
}
