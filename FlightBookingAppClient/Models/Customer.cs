using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class Customer
    {
        [DisplayName("Customer Name")]
        [Required(ErrorMessage ="customer name required")]
        public string CustName { set; get; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="enter valid email ")]
        public string Email {  set; get; }

        [DisplayName("Mobile No")]
        [Required(ErrorMessage ="mobile no required")]
        public string Number { get; set; }

    }
}