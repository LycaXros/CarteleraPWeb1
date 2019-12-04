using PWEB01B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWEB01B.ViewModel
{
    public class CarteleraViewModel
    {
        public System.Guid CineId { get; set; }


        public Cine Cine { get; set; }
        public IEnumerable<Pelicula> Peliculas { get; set; }
        public IEnumerable<string> Tandas { get; set; }

        public string TandasString => string.Join(", ", Tandas.ToArray());
    }
    public class Cartelera2ViewModel
    {
        public System.Guid CineId { get; set; }
        public int PeliculaId { get; set; }

        public string Cinema { get; set; }
        public string Pelicula { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public IEnumerable<string> Hora_Tandas { get; set; }

        public string Hora_Tanda => string.Join(", ", Hora_Tandas.ToArray());
        
    }
}