using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugsSystem.Data.Infrastructure;
using DrugSystem.Service;
using DrugsSystem.WebUI.Models.Depots;

namespace DrugsSystem.WebUI.Controllers
{
    public class DepotsController : Controller
    {
        private IDrugUnitService _drugUnitService;
        
        public DepotsController(IDrugUnitService drugUnitService)
        {
            _drugUnitService = drugUnitService;
        }

        [HttpGet]
        public ViewResult DrugUnitsList()
        {
            var drugUnits = _drugUnitService.getAll();
            var model = new DrugUnitsListViewModel(drugUnits);
            return View(model);
        }

        [HttpGet]
        public PartialViewResult GetInfo(string id)
        {
            // id - DrugUnitID
            var model = _drugUnitService.GetAssociatedViewData(id);
            return PartialView(model);
        }
    }
}