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
    public class CarteleraController : Controller
    {
        private CarteleraDBEntities db = new CarteleraDBEntities();

        // GET: Cartelera
        public ActionResult Index()
        {
            var pasas = db.Pasas.Include(p => p.Cine).Include(p => p.Pelicula).Include(p => p.Tanda);
            return View(pasas.ToList());
        }

        // GET: Cartelera/Details/5
        public ActionResult Details(Guid? Cid, int? Pid, int? Tid)
        {
            if (Cid == null || Pid == null || Tid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasa pasa = db.Pasas.First(p => p.CineId == Cid && p.PeliculaId == Pid && p.TandaId == Tid);
            if (pasa == null)
            {
                return HttpNotFound();
            }
            return View(pasa);
        }

        // GET: Cartelera/Create
        public ActionResult Create()
        {
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre");
            ViewBag.PeliculaId = new SelectList(db.Peliculas, "PeliculaId", "Titulo");
            ViewBag.TandaId = new SelectList(db.Tandas, "Id", "Hora");
            return View();
        }

        // POST: Cartelera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CineId,PeliculaId,TandaId")] Pasa pasa)
        {
            if (ModelState.IsValid)
            {
                db.Pasas.Add(pasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", pasa.CineId);
            ViewBag.PeliculaId = new SelectList(db.Peliculas, "PeliculaId", "Titulo", pasa.PeliculaId);
            ViewBag.TandaId = new SelectList(db.Tandas, "Id", "Hora", pasa.TandaId);
            return View(pasa);
        }

        // GET: Cartelera/Edit/5
        public ActionResult Edit(Guid? Cid, int? Pid, int? Tid)
        {
            if (Cid == null || Pid == null || Tid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasa pasa = db.Pasas.First(p=> p.CineId == Cid && p.PeliculaId == Pid && p.TandaId == Tid);
            if (pasa == null)
            {
                return HttpNotFound();
            }
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", pasa.CineId);
            ViewBag.PeliculaId = new SelectList(db.Peliculas, "PeliculaId", "Titulo", pasa.PeliculaId);
            ViewBag.TandaId = new SelectList(db.Tandas, "Id", "Hora", pasa.TandaId);
            return View(pasa);
        }

        // POST: Cartelera/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CineId,PeliculaId,TandaId")] Pasa pasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", pasa.CineId);
            ViewBag.PeliculaId = new SelectList(db.Peliculas, "PeliculaId", "Titulo", pasa.PeliculaId);
            ViewBag.TandaId = new SelectList(db.Tandas, "Id", "Hora", pasa.TandaId);
            return View(pasa);
        }

        // GET: Cartelera/Delete/5
        public ActionResult Delete(Guid? Cid, int? Pid, int? Tid)
        {
            if (Cid == null || Pid == null || Tid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasa pasa = db.Pasas.First(p => p.CineId == Cid && p.PeliculaId == Pid && p.TandaId == Tid);
            if (pasa == null)
            {
                return HttpNotFound();
            }
            return View(pasa);
        }

        // POST: Cartelera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid Cid, int Pid, int Tid)
        {
            Pasa pasa = db.Pasas.First(p => p.CineId == Cid && p.PeliculaId == Pid && p.TandaId == Tid);
            db.Pasas.Remove(pasa);
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
