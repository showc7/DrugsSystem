using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Models;

namespace DrugSystem.Service.Models
{
    public class DrugUnitDepot
    {
        public DrugUnit DrugUnit { get; set; }
        public Depot Depot { get; set; }

        public DrugUnitDepot(DrugUnit du, Depot dpt)
        {
            DrugUnit = du;
            Depot = dpt;
        }
    }
}
