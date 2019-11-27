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
}