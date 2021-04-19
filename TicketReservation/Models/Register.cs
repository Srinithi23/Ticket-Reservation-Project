using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservation.Models
{
    public class Register
    {

        [RegularExpression(@"^[a-zA-Z ]*$",
            ErrorMessage = "Please enter the valid name !!")]
        [Required]

        public string Firstname { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$",
            ErrorMessage = "Please enter the valid name !!")]

        public string Lastname { get; set; }
        [Required]
      
              [RegularExpression(@"^[#.0-9a-zA-Z\s,-]+$",
            ErrorMessage = "Invalid Address !!  Address format: #1, North Street, Chennai - 11 ")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter phone Number")]
        [Display(Name = "Phone Number")]

        [RegularExpression(@"(\+91)?(-)?\s*?(91)?\s*?(\d{3})-?\s*?(\d{3})-?\s*?(\d{4})",
            ErrorMessage = "Invalid Mobile Number !!")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            ErrorMessage = "Invalid Email id !!")]
        public string EmailId { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password does'nt Match")]

        public string ConfirmPassword { get; set; }
    }
}
