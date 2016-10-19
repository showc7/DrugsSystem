using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrugsSystem.WebUI.Models.OrderUnits
{
    public class ListViewModel
    {
        public List<string> DepotName { get; set; }
        public List<int> DepotID { get; set; }
        public List<SelectListItem> Depots { get; set; }

        public ListViewModel()
        {
            DepotID = new List<int>();
            DepotName = new List<string>();
            Depots = new List<SelectListItem>();
        }
    }
}