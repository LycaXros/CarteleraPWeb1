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
            ViewBag.Cartelera = db.Pasas
                .Include(p => p.Pelicula)
                .Include(p => p.Pelicula.Genero)
                .Include(p => p.Pelicula.Actors)
                .Include(p => p.Tanda)
                .Include(p => p.Cine)
                .Include(p => p.Cine.DireccionCine)
                .Include(p => p.Cine.Tarifas);
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