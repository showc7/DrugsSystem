using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugSystem.Service.Models;
using DrugsSystem.Models;
//using DrugsSystem.WebUI.Models;

namespace DrugsSystem.WebUI.Controllers.Helpers
{
    public static class DrugUnitWithDepotHelperMethods
    {
        // один список депотов на все
        // использовать JQuery для подгрузки списков
        public static List<Models.DrugUnitWithDepotViewModel> DrugUnitDepotToListItem(List<DrugUnitDepot> drugUnitWithDepot, List<Depot> depots)
        {
            List<Models.DrugUnitWithDepotViewModel> drugUnitsView = new List<Models.DrugUnitWithDepotViewModel>();
            foreach (DrugUnitDepot dud in drugUnitWithDepot)
            {
                var view = new Models.DrugUnitWithDepotViewModel()
                {
                    DrugUnitPickNumber = dud.DrugUnit.PickNumber,
                    Depots = new List<SelectListItem>()
                    {
                        new SelectListItem()
                        {
                            Text = "Selected Item",
                            Value = null,
                            Selected = dud.Depot == null
                        }
                    },
                    DepotID = dud.Depot == null ? -1 : dud.Depot.DepotID
                };

                foreach(Depot d in depots)
                {
                    view.Depots.Add(new SelectListItem()
                    {
                        Text = d.ToString(),
                        Value = d.DepotID.ToString(),
                        Selected = dud.Depot?.DepotID == d.DepotID
                    });
                }

                drugUnitsView.Add(view);
            }
            return drugUnitsView;
        }
    }
}