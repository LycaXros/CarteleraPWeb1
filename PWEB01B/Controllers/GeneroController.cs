﻿using System;
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
    public class GeneroController : Controller
    {
        private CarteleraDBEntities db = new CarteleraDBEntities();

        // GET: Genero
        public ActionResult Index()
        {
            return View(db.Generoes.ToList());
        }

        // GET: Genero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = db.Generoes.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // GET: Genero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GeneroId,Nombre")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Generoes.Add(genero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        // GET: Genero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = db.Generoes.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // POST: Genero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GeneroId,Nombre")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        // GET: Genero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = db.Generoes.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        // POST: Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero genero = db.Generoes.Find(id);
            db.Generoes.Remove(genero);
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
