using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Deployment.Internal;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Entities
{
    public class AuthenticateAgent
    {
        [Key]
        public int ApplicantNum {  get; set; }
        public string password {  get; set; }
        public string ApplicantName {  get; set; }
        public string ApplicantEmail {  get; set; }

        [StringLength(10)]
        public string ApplicantPhone {  get; set; }
        public string ApplicantCity { get; set; }
        public string ApplicantLocation { get; set; }
        public double CommissionRate { get; set; }
        public string ApprovalStatus { get; set; }
    }
}