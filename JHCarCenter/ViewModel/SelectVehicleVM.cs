using JHCarCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.ViewModel
{
    public class SelectVehicleVM
    {
        public Customer Customer { get; set; }
        public IList<Vehicle> Vehicles { get; set; }
    }
}
