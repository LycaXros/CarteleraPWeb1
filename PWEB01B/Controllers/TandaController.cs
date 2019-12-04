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
    public class TandaController : Controller
    {
        private CarteleraDBEntities db = new CarteleraDBEntities();

        // GET: Tanda
        public ActionResult Index()
        {
            return View(db.Tandas.ToList());
        }

        // GET: Tanda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanda tanda = db.Tandas.Find(id);
            if (tanda == null)
            {
                return HttpNotFound();
            }
            return View(tanda);
        }

        // GET: Tanda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tanda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hora")] Tanda tanda)
        {
            if (ModelState.IsValid)
            {
                db.Tandas.Add(tanda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tanda);
        }

        // GET: Tanda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanda tanda = db.Tandas.Find(id);
            if (tanda == null)
            {
                return HttpNotFound();
            }
            return View(tanda);
        }

        // POST: Tanda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hora")] Tanda tanda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tanda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tanda);
        }

        // GET: Tanda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanda tanda = db.Tandas.Find(id);
            if (tanda == null)
            {
                return HttpNotFound();
            }
            return View(tanda);
        }

        // POST: Tanda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tanda tanda = db.Tandas.Find(id);
            db.Tandas.Remove(tanda);
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
