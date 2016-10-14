using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrugsSystem.WebUI.Models.DrugUnitWithDepot
{
    public class DrugUnitDepotViewModel
    {
        public IEnumerable<DrugsSystem.Models.Depot> Depots { get; set; }

        public DrugUnitDepotViewModel(IEnumerable<DrugsSystem.Models.Depot> depots)
        {
            Depots = depots;
        }
    }
}