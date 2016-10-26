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
        private IDrugUnitService _drugUnitService;
        private IDepotService _depotService;
        private IDrugUnitDepotService _drugUnitDepotService;
        public DrugUnitWithDepotsController(IDrugUnitService drugUnitService, IDepotService depotService, IDrugUnitDepotService drugUnitDepotService)
        {
            _drugUnitService = drugUnitService;
            _depotService = depotService;
            _drugUnitDepotService = drugUnitDepotService;
        }

        public ActionResult DrugUnits()
        {
            var data = _drugUnitService.getAll();
            var model = new Models.DrugUnitWithDepot.DrugUnitsViewModel(data);
            return View(model);
        }
        [HttpGet]
        public ActionResult DrugUnitDepot()
        {
            var drugUnitWithDepot = _drugUnitDepotService.DrugUnitWithDepot();
            var depots = (List<Depot>)_depotService.GetAll();
            var model = Helpers.DrugUnitWithDepotHelperMethods.DrugUnitDepotToListItem(drugUnitWithDepot, depots);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult DrugUnitDepot(Models.DrugUnitWithDepotViewModel m)
        {
            List<DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel> updateModels = new List<DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel>();
            m.DrugUnits.ForEach(v => updateModels.Add(AutoMapper.Mapper.Map<Models.ViewModelDrugUnit, DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel>(v)));
            
            _drugUnitDepotService.UpdateDrugUnitWithDepot(updateModels);
            return RedirectToAction("DrugUnitDepot");
        }

        public JsonResult GetData(string search, string nd, string rows, string page, string sidx, string sord)
        {

            return Json(
                new {
                    total = 2,
                    page = 1,
                    records = 2,
                    rows = new[ ]
                        {
                            new { id = 0, cell = new [] { "Alex", "Yashin" } },
                            new { id = 1, cell = new [] { "Dimon", "Laschykovsky" } }
                        }
            }, JsonRequestBehavior.AllowGet);
        }
    }
}