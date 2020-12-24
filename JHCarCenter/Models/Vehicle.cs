using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JHCarCenter.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VehicleName { get; set; }

        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string ManfactureYear { get; set; }
        public int Cubic_Capacity { get; set; }
        [ForeignKey("Color")]
        public int ColorID { get; set; }
        public int LoadCapacity { get; set; }
        public bool IsSales { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual IList<VehicleAccessories> VehicleAccessories { get; set; }
        public virtual Color Color { get; set; }
        public virtual IList<Quatation> Quatations { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeID { get; set; }
        public VehicleType VehicleType { get; set; }

    }
}
