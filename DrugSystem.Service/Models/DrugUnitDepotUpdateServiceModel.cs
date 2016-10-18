using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugSystem.Service.Models
{
    public class DrugUnitDepotUpdateServiceModel
    {
        public int? DepotID { get; set; }
        public int DrugUnitPickNumber { get; set; }
    }
}
