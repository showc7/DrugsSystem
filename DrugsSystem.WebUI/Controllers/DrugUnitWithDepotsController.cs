using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugSystem.Service;
using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

namespace DrugsSystem.WebUI.Controllers
{
    public class DrugUnitWithDepotsController : Controller
    {
        private static DbFactory _dbfactory = new DbFactory();
        private IDrugUnitService _drugUnitService = new DrugUnitService(_dbfactory);
        private IDepotService _depotService = new DepotService(_dbfactory);
        private IDrugUnitDepotService _drugUnitDepotService = new DrugUnitsDepotService(_dbfactory);
        // GET: DrugUnitWithDepots
        public ActionResult Index()
        {
            return RedirectToAction("DrugUnitDepot");
        }

        public ActionResult DrugUnits()
        {
            return View(new Models.DrugUnitWithDepot.DrugUnitsViewModel(_drugUnitService.getAll()));
        }
        [HttpGet]
        public ActionResult DrugUnitDepot()
        {
            return View(
                Helpers.DrugUnitWithDepotHelperMethods.DrugUnitDepotToListItem(
                    _drugUnitDepotService.DrugUnitWithDepot(),
                    (List<Depot>)_depotService.GetAll()
                )
            );
        }
        
        [HttpPost]
        public ActionResult DrugUnitDepot(Models.DrugUnitWithDepotViewModel m)
        {
            //return View(m);
            List<DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel> updateModels = new List<DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel>();
            m.DrugUnits.ForEach(v => updateModels.Add(AutoMapper.Mapper.Map<Models.ViewModelDrugUnit, DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel>(v)));
            
            _drugUnitDepotService.UpdateDrugUnitWithDepot(updateModels);
            return RedirectToAction("DrugUnitDepot");
        }
    }
}