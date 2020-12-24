using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JHCarCenter.Models
{
   public class Sales
    {
        public int SalesID { get; set; }
        [ForeignKey("Quatation")]
        public int QuatationID { get; set; }
        
        public DateTime DelivaryLastDate { get; set; }
        public bool IsDeliverd { get; set; }
        public Quatation Quatation { get; set; }

    }
}
