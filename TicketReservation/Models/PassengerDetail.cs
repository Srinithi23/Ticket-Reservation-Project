using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservation.Models
{
    public class PassengerDetail
    {
        [Required]
        public int SerialNo { get; set; }
        [Required]
        public int? TrainNo { get; set; }
        [Required]

        [DataType(DataType.Text)]

        public string PassengerName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]

        public int? Age { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
       public string EmailId { get; set; }
    }
}
