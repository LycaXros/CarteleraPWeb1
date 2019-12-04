using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PWEB01B.Models;

namespace PWEB01B.Controllers
{
    public class CineController : Controller
    {
        private CarteleraDBEntities db = new CarteleraDBEntities();

        // GET: Cine
        public ActionResult Index()
        {
            var cines = db.Cines.Include(c => c.Direccion);
            return View(cines.ToList());
        }

        // GET: Cine/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cines.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
        }

        // GET: Cine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CineId,Nombre,Telefono")] Cine cine)
        {
            if (ModelState.IsValid)
            {
                cine.CineId = Guid.NewGuid();
                db.Cines.Add(cine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cine);
        }

        // GET: Cine/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cines.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
        }

        // POST: Cine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CineId,Nombre,Telefono")] Cine cine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cine);
        }

        // GET: Cine/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cines.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
        }

        // POST: Cine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Cine cine = db.Cines.Find(id);
            db.Cines.Remove(cine);
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
