using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JHCarCenter.Models
{
   public class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Sales")]
        public int SalesID { get; set; }
        public Sales Sales { get; set; }

    }
}
