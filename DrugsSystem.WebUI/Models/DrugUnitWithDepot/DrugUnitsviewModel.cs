using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrugsSystem.Models;

namespace DrugsSystem.WebUI.Models.DrugUnitWithDepot
{
    public class DrugUnitsViewModel
    {
        public IEnumerable<DrugUnit> DrugUnits { get; set; }

        public DrugUnitsViewModel(IEnumerable<DrugUnit> units)
        {
            this.DrugUnits = units;
        }
    }
}