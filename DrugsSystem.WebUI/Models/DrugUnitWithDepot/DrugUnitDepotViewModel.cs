using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrugsSystem.Models;
using DrugSystem.Service.Models;

namespace DrugsSystem.WebUI.Models.DrugUnitWithDepot
{
    public class DrugUnitDepotViewModel
    {
        public List<DrugUnitWithDepotViewModel> List { get; set; }

        public DrugUnitDepotViewModel()
        {

        }

        public DrugUnitDepotViewModel(List<DrugUnitWithDepotViewModel> list)
        {
            this.List = list;
        }
    }
}