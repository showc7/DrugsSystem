using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugsSystem.Models.Database;

namespace DrugsSystem.Controllers
{
    public class DrugUnitController : Controller
    {
        private DAL.DrugsContext _db = new DAL.DrugsContext();
        // GET: DrugUnit
        public ActionResult Index()
        {
            return View("List",_db.DrugUnits.ToList());
        }

        public ActionResult Details(string id)
        {
            return View(_db.DrugUnits.Where(x => x.DrugUnitID == id).FirstOrDefault());
        }
    }
}