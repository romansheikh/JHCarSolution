using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JHCarCenter.Models
{
   public class VehicleAccessories
    {

        public int ID { get; set; }
        [ForeignKey("Accessories")]
        public int AccessoriesID { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }

        public virtual Accessories Accessories { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
