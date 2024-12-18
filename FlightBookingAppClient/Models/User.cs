using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class User
    {
        [Key]
        [StringLength(4)]
        public string UserId { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage ="password required")]
        [DisplayName("Password")]
       // [RegularExpression("^[A-Za-z\\d@]{6}$")]
        public string password { get; set; }

        [Required(ErrorMessage ="username required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="email required")]
        [EmailAddress(ErrorMessage ="enter valid email")]
        public string Email { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage ="mobile no required")]
        [DisplayName("Contact No")]
        public string UserPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}