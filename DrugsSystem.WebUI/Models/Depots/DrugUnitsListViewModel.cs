using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrugsSystem.Models;
using AutoMapper;
using System.Web.Mvc;

namespace DrugsSystem.WebUI.Models.Depots
{
    public class DrugUnitsListViewModel
    {
        public List<SelectListItem> DrugUnits { get; set; }
        public DrugUnitsListViewModel(IEnumerable<DrugUnit> drugUnits)
        {
            DrugUnits = new List<SelectListItem>();
            // check automapper
            (drugUnits as List<DrugUnit>).ForEach(du => DrugUnits.Add(Mapper.Map<DrugUnit,SelectListItem>(du)));
        }
    }
}