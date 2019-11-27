using PWEB01B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWEB01B.ViewModel
{
    public class ActorPelicula
    {
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
        public int ActorId { get; set; }

        public string ActorName => $"{Actor.Nombre} {Actor.Apellidos}";
    }
}