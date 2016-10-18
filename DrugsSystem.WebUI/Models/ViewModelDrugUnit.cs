using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrugsSystem.WebUI.Models
{
    public class ViewModelDrugUnit
    {
        public int? SelectedDepotID { get; set; }
        public string DrugUnitID { get; set; }
        public int DrugUnitPickNumber { get; set; }
    }
}