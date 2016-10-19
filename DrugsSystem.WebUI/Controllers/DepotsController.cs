using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugsSystem.Data.Infrastructure;
using DrugSystem.Service;

namespace DrugsSystem.WebUI.Controllers
{
    public class DepotsController : Controller
    {
        private static DbFactory _dbfactory = new DbFactory();
        private IDrugUnitService _drugUnitService = new DrugUnitService(_dbfactory);
        // GET: Depots
        public ActionResult Index()
        {
            return RedirectToAction("DrugUnitsList");
        }

        [HttpGet]
        public ActionResult DrugUnitsList()
        {
            return View(new Models.Depots.DrugUnitsListViewModel(_drugUnitService.getAll()));
        }

        [HttpGet]
        public ActionResult GetInfo(string id)
        {
            // id - DrugUnitID
            return PartialView(_drugUnitService.GetAssociatedViewData(id));
        }
    }
}