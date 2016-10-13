using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DrugsSystem.Models.Database;

namespace DrugsSystem.Controllers
{
    public class DrugTypeController : Controller
    {
        private DAL.DrugsContext _db = new DAL.DrugsContext();
        // GET: DrugType
        public ActionResult Index()
        {
            return View("List", _db.Drugtypes.ToList());
        }

        public ActionResult Delete(int id)
        {
            _db.Drugtypes.Remove(_db.Drugtypes.Where(x => x.DrugTypeID == id).FirstOrDefault());
            _db.SaveChanges();
            //return View(_db.Drugtypes.Where(x => x.DrugTypeID == id).FirstOrDefault());
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(DrugType model)
        {
            _db.Drugtypes.Remove(_db.Drugtypes.Where(x => x.DrugTypeID == model.DrugTypeID).FirstOrDefault());
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DrugType model)
        {
            _db.Drugtypes.Add(model);
            _db.SaveChanges();
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(_db.Drugtypes.Where(x => x.DrugTypeID == id).FirstOrDefault());
        }
        
        public ActionResult Edit(int id)
        {
            return View(_db.Drugtypes.Where(x => x.DrugTypeID == id).FirstOrDefault());
        }
    }
}