using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using DrugSystem.Service;
using DrugsSystem.Models;
using DrugSystem.Service.Models;
using DrugsSystem.WebUI.Models.JqueryGrid;

namespace DrugsSystem.WebUI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0)]
    public class JqueryGridController : Controller
    {
        private IDrugUnitService _drugUnitService;
        private IDepotService _depotService;
        private IDrugUnitDepotService _drugUnitDepotService;

        public JqueryGridController(IDrugUnitService drugUnitService, IDepotService depotService, IDrugUnitDepotService drugUnitDepotService)
        {
            _drugUnitService = drugUnitService;
            _depotService = depotService;
            _drugUnitDepotService = drugUnitDepotService;
        }

        // GET: JqueryGrid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var filePath = "d:/projects/git/DrugsSystem/jsondata.json";
            using (StreamReader sr = new StreamReader(filePath))
            {
                return Content(sr.ReadToEnd(), "application/json");
            }
        }

        public ViewResult Test()
        {
            return View();
        }
        //http://localhost:56893/JqueryGrid/GetData2?_search=false&nd=1477464336619&rows=10&page=2&sidx=name&sord=desc
        [HttpGet]
        public ActionResult GetData2(string page)
        {
            int totalDrugUnits = _drugUnitDepotService.GetDrugUnitsCount();
            int pageRecordsCount = 5;
            int totalPagesCount = (int) Math.Ceiling(totalDrugUnits / (double)pageRecordsCount);
            int pageNumber = int.Parse(page);
            int offset = pageRecordsCount * (pageNumber - 1);

            var drugUnitWithDepot = _drugUnitDepotService.DrugUnitWithDepot(offset, pageRecordsCount);
            var depots = (List<Depot>) _depotService.GetAll();
            var model = Helpers.JqueryGridHelper.DrugUnitDepotToModel(drugUnitWithDepot, depots, pageNumber, totalPagesCount, totalDrugUnits);
            return Json(model, JsonRequestBehavior.AllowGet);
            /*
            var filePath = "d:/projects/git/DrugsSystem/jsondata2.json";
            using (StreamReader sr = new StreamReader(filePath))
            {
                return Content(sr.ReadToEnd(), "application/json");
            }
            */
        }
        [HttpPost]
        public ActionResult GetData2(AjaxResponceDataObject obj)
        {
            //return Content("OK");
            _drugUnitDepotService.AssociateDrugUnitWithDepot(obj.drugUnitID,int.Parse(obj.depotID));
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}