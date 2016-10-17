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
            return View();
        }

        public ActionResult DrugUnits()
        {
            return View(new Models.DrugUnitWithDepot.DrugUnitsViewModel(_drugUnitService.getAll()));
        }
        [HttpGet]
        public ActionResult DrugUnitDepot()
        {
            //return View(new Models.DrugUnitWithDepot.DrugUnitDepotViewModel(_depotService.GetAll()));
            //return View(new Models.DrugUnitWithDepot.DrugUnitDepotViewModel(_drugUnitDepotService.DrugUnitWithDepot(), (List<Depot>) _depotService.GetAll()));
            return View(new Models.DrugUnitWithDepot.DrugUnitDepotViewModel(
                Helpers.DrugUnitWithDepotHelperMethods.DrugUnitDepotToListItem(_drugUnitDepotService.DrugUnitWithDepot(), (List<Depot>)_depotService.GetAll())));
        }

        [HttpPost]
        public ActionResult DrugUnitDepot(Models.DrugUnitWithDepot.DrugUnitDepotViewModel m)
        {
            // call service to transfrom data from object to database
            List<DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel> updateModels = new List<DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel>();
            return View(m);
            // use automapper insted
            foreach (var v in m.List)
            {
                updateModels.Add(new DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel()
                {
                    DepotID = v.DepotID,
                    DrugUnitPickNumber = v.DrugUnitPickNumber
                });
            }
            _drugUnitDepotService.UpdatedrugUnitWithDepot(updateModels);
            return RedirectToAction("DrugUnitDepot");
        }
    }
}