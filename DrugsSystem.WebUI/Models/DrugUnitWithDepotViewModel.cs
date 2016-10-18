using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

using DrugsSystem.Models;

namespace DrugsSystem.WebUI.Models
{
    public class DrugUnitWithDepotViewModel
    {
        // new logic
        public List<SelectListItem> Depots { get; set; }
        public List<ViewModelDrugUnit> DrugUnits { get; set; }

        public List<SelectListItem> SelectItem(List<SelectListItem> depots, int? value)
        {
            string valueString = value.ToString();

            List<SelectListItem> resultDepots = new List<SelectListItem>(depots.Count);
            // in fact - copy objects
            depots.ForEach(x => resultDepots.Add(AutoMapper.Mapper.Map<SelectListItem, SelectListItem>(x)));
            resultDepots.ForEach(x => x.Selected = x.Value == valueString);

            return resultDepots;
        }
    }
}