using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrugsSystem.WebUI.Models.OrderUnits
{
    public class DrugTypesViewModel
    {
        public List<string> Values { get; set; }
        public List<string> Names { get; set; }
        public List<int> IDs { get; set; }
        public int DepotID { get; set; }

        public DrugTypesViewModel()
        {
            Values = new List<string>();
            Names = new List<string>();
            IDs = new List<int>();
        }
    }
}