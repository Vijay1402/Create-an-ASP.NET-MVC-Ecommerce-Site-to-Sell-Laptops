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
    public class ThinLightsController : Controller
    {
        private LaptopsDbEntities db = new LaptopsDbEntities();

        // GET: ThinLights
        public ActionResult Index()
        {
            return View(db.ThinLights.ToList());
        }

        // GET: ThinLights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThinLight thinLight = db.ThinLights.Find(id);
            if (thinLight == null)
            {
                return HttpNotFound();
            }
            return View(thinLight);
        }

        // GET: ThinLights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThinLights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price")] ThinLight thinLight)
        {
            if (ModelState.IsValid)
            {
                db.ThinLights.Add(thinLight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thinLight);
        }

        // GET: ThinLights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThinLight thinLight = db.ThinLights.Find(id);
            if (thinLight == null)
            {
                return HttpNotFound();
            }
            return View(thinLight);
        }

        // POST: ThinLights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price")] ThinLight thinLight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thinLight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thinLight);
        }

        // GET: ThinLights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThinLight thinLight = db.ThinLights.Find(id);
            if (thinLight == null)
            {
                return HttpNotFound();
            }
            return View(thinLight);
        }

        // POST: ThinLights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThinLight thinLight = db.ThinLights.Find(id);
            db.ThinLights.Remove(thinLight);
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
