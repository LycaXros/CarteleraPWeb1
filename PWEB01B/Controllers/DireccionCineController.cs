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
    public class DireccionCineController : Controller
    {
        private CarteleraDBEntities db = new CarteleraDBEntities();

        // GET: DireccionCine
        public ActionResult Index()
        {
            var direccionCines = db.DireccionCines.Include(d => d.Cine);
            return View(direccionCines.ToList());
        }

        // GET: DireccionCine/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCine direccionCine = db.DireccionCines.Find(id);
            if (direccionCine == null)
            {
                return HttpNotFound();
            }
            return View(direccionCine);
        }

        // GET: DireccionCine/Create
        public ActionResult Create()
        {
            var cinesFree = db.Cines.Where(c => c.Direccion == null);
            ViewBag.CineId = new SelectList(cinesFree, "CineId", "Nombre");
            return View();
        }

        // POST: DireccionCine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CineId,Calle,Numero,Ciudad")] DireccionCine direccionCine)
        {
            if (ModelState.IsValid)
            {
                db.DireccionCines.Add(direccionCine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var cinesFree = db.Cines.Where(c => c.Direccion == null);
            ViewBag.CineId = new SelectList(cinesFree, "CineId", "Nombre", direccionCine.CineId);
            return View(direccionCine);
        }

        // GET: DireccionCine/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCine direccionCine = db.DireccionCines.Find(id);
            if (direccionCine == null)
            {
                return HttpNotFound();
            }
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", direccionCine.CineId);
            return View(direccionCine);
        }

        // POST: DireccionCine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CineId,Calle,Numero,Ciudad")] DireccionCine direccionCine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccionCine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", direccionCine.CineId);
            return View(direccionCine);
        }

        // GET: DireccionCine/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCine direccionCine = db.DireccionCines.Find(id);
            if (direccionCine == null)
            {
                return HttpNotFound();
            }
            return View(direccionCine);
        }

        // POST: DireccionCine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DireccionCine direccionCine = db.DireccionCines.Find(id);
            db.DireccionCines.Remove(direccionCine);
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
