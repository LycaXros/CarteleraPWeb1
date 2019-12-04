using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PWEB01B.Models;
using PWEB01B.ViewModel;

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

            var q = (from d in data
                     group d by new { d.CineId, d.PeliculaId } into Carte
                     select new
                     {
                         Carte.Key.CineId,
                         Carte.Key.PeliculaId,
                         Carte.FirstOrDefault().Cinema,
                         Carte.FirstOrDefault().Pelicula,
                         Carte.FirstOrDefault().Genero,
                         Carte.FirstOrDefault().Direccion,
                         Carte.FirstOrDefault().Telefono,
                         Hora_Tandas = Carte.Select(x => x.Hora_Tanda)
                     })
                    .ToList()
                    .Select(x => new Cartelera2ViewModel() {
                        CineId = x.CineId,
                        PeliculaId = x.PeliculaId,
                        Cinema = x.Cinema,
                        Telefono = x.Telefono,
                        Pelicula = x.Pelicula,
                        Direccion = x.Direccion,
                        Genero = x.Genero,
                        Hora_Tandas = x.Hora_Tandas
                    });
            ViewBag.Data = q.ToList();

            //ViewBag.PeliculaId = new SelectList(db.Peliculas, "PeliculaId", "Titulo", Pid);
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre", Gid);
            ViewBag.TandaId = new SelectList(db.Tandas, "Id", "Hora", Tid);
            ViewBag.CineId = new SelectList(db.Cines, "CineId", "Nombre", Cid);
            //return View(data.ToList());
            return View(q.ToList());
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
