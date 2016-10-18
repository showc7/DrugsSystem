using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugSystem.Service.Models;
using DrugsSystem.Models;
using AutoMapper;

namespace DrugsSystem.WebUI.Controllers.Helpers
{
    public static class DrugUnitWithDepotHelperMethods
    {
        public static Models.DrugUnitWithDepotViewModel DrugUnitDepotToListItem(List<DrugUnitDepot> drugUnitWithDepot, List<Depot> depots)
        {
            Models.DrugUnitWithDepotViewModel result = new Models.DrugUnitWithDepotViewModel();
            /* save list of depots */
            result.Depots = new List<SelectListItem>() {
                new SelectListItem()
                {
                    Text = "Selected Item",
                    Value = null
                }
            };

            depots.ForEach(d => result.Depots.Add(Mapper.Map<Depot, SelectListItem>(d)));
            
            /* save list of drugUnits */
            result.DrugUnits = new List<Models.ViewModelDrugUnit>();
            drugUnitWithDepot.ForEach(du => result.DrugUnits.Add(Mapper.Map<DrugUnitDepot, Models.ViewModelDrugUnit>(du)));
            
            //foreach (DrugUnitDepot du in drugUnitWithDepot)
            //{
            //    result.DrugUnits.Add(new Models.ViewModelDrugUnit()
            //    {
                      // nullabale ?
            //        SelectedDepotID = du.Depot?.DepotID,
            //        DrugUnitID = du.DrugUnit.DrugUnitID,
            //        DrugUnitPickNumber = du.DrugUnit.PickNumber
            //    });
            //}
            
            return result;
        }
    }
}