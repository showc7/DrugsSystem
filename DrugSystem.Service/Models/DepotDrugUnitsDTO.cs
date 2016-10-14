using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugSystem.Service.Models
{
    public class DepotDrugUnitsDTO
    {
        public int DepotID { get; set; }
        public string DepotName { get; set; }
        public List<DrugUnitDTO> DrugUnits { get; set; }
    }
}
