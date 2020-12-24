using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JHCarCenter.Models
{
   public class Quatation
    {
        public int QuatationID { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }
        public decimal Price { get; set; }
        public DateTime QuatationCreateDate { get; set; }
        public DateTime AcceptenceDate { get; set; }
        public int DelivaryPeriod { get; set; }
        public DateTime ConfrimationDate { get; set; }
        public int  ValidityDays { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public bool IsSales { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }

    }
}
