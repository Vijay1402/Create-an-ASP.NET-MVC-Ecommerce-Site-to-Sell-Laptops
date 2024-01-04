using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GamingsController : Controller
    {
        private LaptopsDbEntities db = new LaptopsDbEntities();

        // GET: Gamings
        public ActionResult Index()
        {
            return View(db.Gamings.ToList());
        }

        // GET: Gamings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gaming gaming = db.Gamings.Find(id);
            if (gaming == null)
            {
                return HttpNotFound();
            }
            return View(gaming);
        }

        // GET: Gamings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gamings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price")] Gaming gaming)
        {
            if (ModelState.IsValid)
            {
                db.Gamings.Add(gaming);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gaming);
        }

        // GET: Gamings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gaming gaming = db.Gamings.Find(id);
            if (gaming == null)
            {
                return HttpNotFound();
            }
            return View(gaming);
        }

        // POST: Gamings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price")] Gaming gaming)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gaming).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gaming);
        }

        // GET: Gamings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gaming gaming = db.Gamings.Find(id);
            if (gaming == null)
            {
                return HttpNotFound();
            }
            return View(gaming);
        }

        // POST: Gamings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gaming gaming = db.Gamings.Find(id);
            db.Gamings.Remove(gaming);
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
