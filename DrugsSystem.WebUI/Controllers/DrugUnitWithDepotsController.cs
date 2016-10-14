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
        private IDepotService _drugUnitService = new DepotService(new DbFactory());
        // GET: DrugUnitWithDepots
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DrugUnitDepot()
        {
            return View(new Models.DrugUnitWithDepot.DrugUnitDepotViewModel(_drugUnitService.GetAll()));
        }
    }
}