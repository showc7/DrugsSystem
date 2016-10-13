using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugsSystem.Models.Database;

namespace DrugsSystem.Controllers
{
    //[RoutePrefix("Drugs")]
    public class DrugsController : Controller
    {
        private DAL.DrugsContext _dataContext = new DAL.DrugsContext();
        // GET: Drugs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Drugs()
        {
            return RedirectToAction("View");
        }

        public ActionResult DrugUnits()
        {
            ViewBag.Units = _dataContext.DrugUnits.ToList();

            return View();
        }

        public ActionResult View()
        {
            return View(_dataContext.DrugUnits.ToList());
        }

        public ActionResult Details(string id)
        {
            return View(_dataContext.DrugUnits.Where(x => x.DrugUnitID == id).FirstOrDefault());
        }

        public ActionResult Delete(string id)
        {
            _dataContext.DrugUnits.Remove(_dataContext.DrugUnits.Where(x => x.DrugUnitID == id).FirstOrDefault());
            _dataContext.SaveChanges();
            return RedirectToAction("View");
        }

        public ActionResult Create()
        {
            return View("DrugUnitsCreate",new DrugUnit());
        }
        //[Route("{id}/edit")]
        public ActionResult Edit(string id)
        {
            return View("DrugUnitsEdit", _dataContext.DrugUnits.Where(x => x.DrugUnitID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(DrugUnit drugUnit)
        {
            _dataContext.Entry(drugUnit).State = System.Data.Entity.EntityState.Modified;
            _dataContext.SaveChanges();
            return RedirectToAction("View");
        }
    }
}