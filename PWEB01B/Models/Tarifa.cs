//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PWEB01B.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tarifa
    {
        public int TarifaId { get; set; }
        public System.Guid CineId { get; set; }
        public DiaSemana Dia { get; set; }
        public decimal Precio { get; set; }
    
        public virtual Cine Cine { get; set; }
    }
}
