using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final2.Models;

namespace Final2.Controllers
{
    public class MainsController : Controller
    {
        private Final2Entities db = new Final2Entities();

        // GET: Mains
        public ActionResult Index()
        {
            return View(db.Mains.ToList());
        }

        // GET: Mains/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        // GET: Mains/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Screenshot,Git,ProjectID")] Main main)
        {
            if (ModelState.IsValid)
            {
                db.Mains.Add(main);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(main);
        }

        // GET: Mains/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Description,Screenshot,Git,ProjectID")] Main main)
        {
            if (ModelState.IsValid)
            {
                db.Entry(main).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(main);
        }

        // GET: Mains/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        // POST: Mains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Main main = db.Mains.Find(id);
            db.Mains.Remove(main);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
