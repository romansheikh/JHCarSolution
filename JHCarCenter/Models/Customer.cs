using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JHCarCenter.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "Customer Name")]
        [StringLength(100)]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string NID { get; set; }
        public string DrivingLicence { get; set; }
        [ForeignKey("Gender")]
        public int GenderID { get; set; }
        public Gender Gender { get; set; } 
        public virtual IList<Quatation> Quatations { get; set; }
    }
}
