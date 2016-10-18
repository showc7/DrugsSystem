using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugSystem.Service.Models
{
    public class DrugUnitAssociatedViewDataDTO
    {
        public string DepotName { get; set; }
        public string CountryName { get; set; }
        public string DrugTypeName { get; set; }
        public string DrugUnitID { get; set; }
        public int PickNumber { get; set; }
    }
}
