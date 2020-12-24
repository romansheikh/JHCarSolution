using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JHCarCenter.Models
{
   public class Accessories
    {
     
        public int AccessoriesID { get; set; }
        [Display(Name = "Accessories Name")]
        public string AccessoriesName { get; set; }
        public ICollection<VehicleAccessories> VehicleAccessories { get; set; }


    }
}
