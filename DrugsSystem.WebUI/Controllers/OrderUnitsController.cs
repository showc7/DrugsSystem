using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrugsSystem.WebUI.Controllers
{
    public class OrderUnitsController : Controller
    {
        // GET: OrderUnits
        public ActionResult Index()
        {
            return View();
        }

        // список депотов -> список типов -> количество для каждого типа -> подсчет

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDrugTypes(int depotID)
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Calculate()
        {
            return PartialView();
        }
    }
}