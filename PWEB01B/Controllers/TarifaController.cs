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
    public class TarifaController : Controller
    {
        private CarteleraDBEntities db = new CarteleraDBEntities();

        // GET: Tarifa
        public ActionResult Index()
        {
            var tarifas = db.Tarifas.Include(t => t.Cine);
            return View(tarifas.ToList());
        }

        // GET: Tarifa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifas.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // GET: Tarifa/Create
        public ActionResult Create()
        {
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre");
            return View();
        }

        // POST: Tarifa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TarifaId,CineId,Dia,Precio")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                db.Tarifas.Add(tarifa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", tarifa.CineId);
            return View(tarifa);
        }

        // GET: Tarifa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifas.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", tarifa.CineId);
            return View(tarifa);
        }

        // POST: Tarifa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TarifaId,CineId,Dia,Precio")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarifa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", tarifa.CineId);
            return View(tarifa);
        }

        // GET: Tarifa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifas.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // POST: Tarifa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarifa tarifa = db.Tarifas.Find(id);
            db.Tarifas.Remove(tarifa);
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
