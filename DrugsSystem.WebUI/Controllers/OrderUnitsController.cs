using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugsSystem.Data.Infrastructure;
using DrugSystem.Service;

namespace DrugsSystem.WebUI.Controllers
{
    public class OrderUnitsController : Controller
    {
        private static DbFactory _dbfactory = new DbFactory();
        private IDepotService _depotService = new DepotService(_dbfactory);
        // GET: OrderUnits
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // список депотов -> список типов -> количество для каждого типа -> подсчет

        [HttpGet]
        public ActionResult List()
        {
            return View(
                Helpers.DepotsToListViewModel.ConvertDepotsToListViewModel(
                    _depotService.GetAll()
                )
            );
        }
        [HttpGet]
        public ActionResult GetDrugTypes(string id)
        {
            return PartialView(
                Helpers.DepotsToListViewModel.ConvertToSelectList(
                    _depotService.GetAssociatedDrugTypes(int.Parse(id)
                    ),
                    int.Parse(id)
                )
            );
        }
        [HttpPost]
        public ActionResult Calculate(Models.OrderUnits.DrugTypesViewModel model)
        {
            return PartialView(
                "OrderResult",
                Helpers.DepotsToListViewModel.CalculateOrder(
                    model,
                    _depotService
                )
            );
        }
    }
}