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
        private IDepotService _depotService;

        public OrderUnitsController(IDepotService depotService)
        {
            _depotService = depotService;
        }

        // depots list -> types list -> count for type -> count
        [HttpGet]
        public ActionResult List()
        {
            var data = _depotService.GetAll();
            var model = Helpers.OrdersHelper.ConvertDepotsToListViewModel(data);
            return View(model);
        }
        [HttpGet]
        public ActionResult GetDrugTypes(string id)
        {
            var idInt = int.Parse(id);
            var associatedDrugTypes = _depotService.GetAssociatedDrugTypes(idInt);
            var model = Helpers.OrdersHelper.ConvertToSelectList(associatedDrugTypes,idInt);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Calculate(Models.OrderUnits.DrugTypesViewModel model)
        {
            var viewName = "OrderResult";
            var viewModel = Helpers.OrdersHelper.CalculateOrder(model, _depotService);
            return PartialView(viewName, viewModel);
        }
    }
}