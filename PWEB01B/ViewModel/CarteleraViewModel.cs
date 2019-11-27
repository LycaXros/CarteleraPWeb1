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
        public int PeliculaId { get; set; }

        public Cine Cine { get; set; }
        public Pelicula Pelicula { get; set; }
        public IEnumerable<string> Tandas { get; set; }

        public string TandasString => string.Join(", ", Tandas.ToArray());
    }
}