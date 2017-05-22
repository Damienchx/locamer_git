using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WACamping.Models;

namespace WACamping.Views
{
    public class LocationsController : Controller
    {
        private LOCAMERDataEntities db = new LOCAMERDataEntities();

        // GET: Locations
        public ActionResult Index()
        {
            var locations = db.locations.Include(l => l.option).Include(l => l.sejour);
            return View(locations.ToList());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            location location = db.locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            ViewBag.Id_option = new SelectList(db.options, "id_loc", "libelle");
            ViewBag.Id_sejour = new SelectList(db.sejours, "Id_sejour", "Id_sejour");
            return View();
        }

        // POST: Locations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "quantite,duree_loc,Id_sejour,Id_option")] location location)
        {
            if (ModelState.IsValid)
            {
                db.locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_option = new SelectList(db.options, "id_loc", "libelle", location.Id_option);
            ViewBag.Id_sejour = new SelectList(db.sejours, "Id_sejour", "Id_sejour", location.Id_sejour);
            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            location location = db.locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_option = new SelectList(db.options, "id_loc", "libelle", location.Id_option);
            ViewBag.Id_sejour = new SelectList(db.sejours, "Id_sejour", "Id_sejour", location.Id_sejour);
            return View(location);
        }

        // POST: Locations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "quantite,duree_loc,Id_sejour,Id_option")] location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_option = new SelectList(db.options, "id_loc", "libelle", location.Id_option);
            ViewBag.Id_sejour = new SelectList(db.sejours, "Id_sejour", "Id_sejour", location.Id_sejour);
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            location location = db.locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            location location = db.locations.Find(id);
            db.locations.Remove(location);
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
