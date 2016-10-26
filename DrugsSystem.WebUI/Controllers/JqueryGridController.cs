using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using DrugSystem.Service;
using DrugsSystem.Models;
using DrugSystem.Service.Models;

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
            var model = Helper.DrugUnitDepotToModel(drugUnitWithDepot, depots, pageNumber, totalPagesCount, totalDrugUnits);
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

    public class AjaxResponceDataObject
    {
        public string drugUnitID { get; set; }
        public string depotID { get; set; }
    }

    public class DrugUnitDepotJsonModel
    {
        public class JsonRow
        {
            public class Cell
            {
                public string id { get; set; }
                public int selectedIndex { get; set; }
                public string[] values { get; set; }
                public int[] ids { get; set; }
                public int pickNumber { get; set; }
                public string DrugUnitID { get; set; }

                public Cell(string id, int selectedIndex, int pickNumber, string drugUnitID)
                {
                    this.id = id;
                    this.selectedIndex = selectedIndex;
                    this.pickNumber = pickNumber;
                    this.DrugUnitID = drugUnitID;
                }
            }

            public string id { get; set; }
            public Cell cell { get; set; }

            public JsonRow(string id)
            {
                this.id = id;
            }
        }

        public int page { get; set; }
        public int total { get; set; }
        public int records { get; set; }
        public JsonRow[] rows { get; set; }

        public DrugUnitDepotJsonModel(int page, int total, int records)
        {
            this.page = page;
            this.total = total;
            this.records = records;
        }
    }

    public static class Helper
    {
        public static DrugUnitDepotJsonModel DrugUnitDepotToModel(List<DrugUnitDepot> drugUnitWithDepot, List<Depot> depots, int page, int total, int records)
        {
            DrugUnitDepotJsonModel result = new DrugUnitDepotJsonModel(page, total, records)
            {
                rows = new DrugUnitDepotJsonModel.JsonRow[drugUnitWithDepot.Count]
            };
            
            for(int i = 0; i < drugUnitWithDepot.Count; i++ )
            {
                var dud = drugUnitWithDepot[i];
                int selectedIndex = depots.IndexOf(dud.Depot);
                result.rows[i] = new DrugUnitDepotJsonModel.JsonRow(dud.DrugUnit.DrugUnitID);
                result.rows[i].cell = new DrugUnitDepotJsonModel.JsonRow.Cell(
                        dud.DrugUnit.DrugUnitID,
                        selectedIndex,
                        dud.DrugUnit.PickNumber,
                        dud.DrugUnit.DrugUnitID
                    );
                result.rows[i].cell.values = depots.Select(d => d.DepotName).ToArray();
                result.rows[i].cell.ids = depots.Select(d => d.DepotID).ToArray();
            }

            return result;
        }
    }
}