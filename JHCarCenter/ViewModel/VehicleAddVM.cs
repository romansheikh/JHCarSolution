using JHCarCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.ViewModel
{
    public class VehicleAddVM
    {

        public int VehicleID { get; set; }
        public string VehicleName { get; set; }

        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string ManfactureYear { get; set; }
        public int Cubic_Capacity { get; set; }
        public int ColorID { get; set; }
        public int LoadCapacity { get; set; }
        public bool IsSales { get; set; }
        public decimal UnitPrice { get; set; }
        public int VehicleTypeID { get; set; }
        public List<int> AccessoriesIds { get; set; }
    }
}
