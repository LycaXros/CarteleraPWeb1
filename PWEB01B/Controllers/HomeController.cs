using PWEB01B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PWEB01B.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CarteleraDBEntities db = new CarteleraDBEntities();
            var data = db.Pasas
                .Include(p => p.Pelicula)
                .Include(p => p.Pelicula.Genero)
                .Include(p => p.Pelicula.Actores)
                .Include(p => p.Tanda)
                .Include(p => p.Cine)
                .Include(p => p.Cine.Direccion)
                .Include(p => p.Cine.Tarifas);
            var query = (from c in data
                         group c by new { c.CineId, c.PeliculaId } into Cartelera
                         orderby Cartelera.Key.CineId
                         select new
                         {
                             Cartelera.Key.CineId,
                             Cartelera.Key.PeliculaId,
                             Tandas = Cartelera.Select(x => x.Tanda.Hora),
                             Cartelera.FirstOrDefault().Pelicula,
                             Cartelera.FirstOrDefault().Cine,
                         })
                                 .ToList()
                                 .Select(c => new ViewModel.CarteleraViewModel
                                 {
                                     Cine = c.Cine,
                                     Pelicula = c.Pelicula,
                                     Tandas = c.Tandas,
                                     CineId = c.CineId,
                                     PeliculaId = c.PeliculaId
                                 }).ToList();
            ViewBag.Cartelera = query;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicacion Trabajo Final Programacion WEB 1";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}