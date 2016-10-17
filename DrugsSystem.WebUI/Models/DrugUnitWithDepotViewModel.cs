using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace DrugsSystem.WebUI.Models
{
    public class DrugUnitWithDepotViewModel
    {
        public int DepotID { get; set; }
        public int DrugUnitPickNumber { get; set; }
        public string DrugUnitID { get; set; }
        public List<SelectListItem> Depots { get; set; }
    }
}