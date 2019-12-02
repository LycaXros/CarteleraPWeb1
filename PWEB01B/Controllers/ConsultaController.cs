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
    public class ConsultaController : Controller
    {
        private CarteleraDBEntities db = new CarteleraDBEntities();

        // GET: Consulta
        public ActionResult Index(string Pel, Guid? Cid, int? Tid, int? Gid)
        {
            var data = db.ConsultaCartelera.AsQueryable();
            if (!string.IsNullOrEmpty(Pel))
            {
                Pel = Pel.ToLower();
                data = data.Where(x => x.Pelicula.ToLower().Contains(Pel));
            }
            if (Cid.HasValue)
            {
                data = data.Where(x => x.CineId == Cid.Value);
            }
            if (Tid.HasValue)
            {
                data = data.Where(x => x.TandaId == Tid.Value);
            }
            if (Gid.HasValue)
            {
                data = data.Where(x => x.GeneroId == Gid.Value);
            }

            //ViewBag.PeliculaId = new SelectList(db.Peliculas, "PeliculaId", "Titulo", Pid);
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre", Gid);
            ViewBag.TandaId = new SelectList(db.Tandas, "Id", "Hora", Tid);
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", Cid);
            return View(data.ToList());
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
