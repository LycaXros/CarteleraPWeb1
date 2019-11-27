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
    public class PeliculaController : Controller
    {
        private CarteleraDBEntities db = new CarteleraDBEntities();

        // GET: Pelicula
        public ActionResult Index()
        {
            var peliculas = db.Peliculas.Include(p => p.Genero);
            return View(peliculas.ToList());
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre");
            return View();
        }

        // POST: Pelicula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeliculaId,Titulo,Director,GeneroId,Clasificacion")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre", pelicula.GeneroId);
            return View(pelicula);
        }

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre", pelicula.GeneroId);
            return View(pelicula);
        }

        // POST: Pelicula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeliculaId,Titulo,Director,GeneroId,Clasificacion")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre", pelicula.GeneroId);
            return View(pelicula);
        }

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddActor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            var ids = pelicula.Actores.Select(x => x.Id).ToArray();
            var query = db.Actors
                .Where(x=> !ids.Contains(x.Id))
                .Select(x => new
                {
                    x.Id,
                    Text = x.Nombre+" "+x.Apellidos
                }).ToList();
            ViewBag.ActorId = new SelectList(query, "Id", "Text");
            return View(new ViewModel.ActorPelicula { Pelicula=pelicula, PeliculaId = (int)id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddActor([Bind(Include = "PeliculaId, ActorId")] ViewModel.ActorPelicula actPeli)
        {
            Pelicula pelicula = db.Peliculas.Find(actPeli.PeliculaId);
            Actor act = db.Actors.Find(actPeli.ActorId);
            if (pelicula == null || act == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                pelicula.Actores.Add(act);
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var ids = pelicula.Actores.Select(x => x.Id).ToArray();
            var query = db.Actors
                .Where(x => !ids.Contains(x.Id))
                .Select(x => new
                {
                    x.Id,
                    Text = x.Nombre + " " + x.Apellidos
                }).ToList();
            ViewBag.ActorId = new SelectList(query, "Id", "Text", actPeli.ActorId);
            return View(actPeli);
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
