﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarteleraDBEntities : DbContext
    {
        public CarteleraDBEntities()
            : base("name=CarteleraDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cine> Cines { get; set; }
        public virtual DbSet<DireccionCine> DireccionCines { get; set; }
        public virtual DbSet<Genero> Generoes { get; set; }
        public virtual DbSet<Pasa> Pasas { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Tanda> Tandas { get; set; }
        public virtual DbSet<Tarifa> Tarifas { get; set; }
        public virtual DbSet<ConsultaCartelera> ConsultaCartelera { get; set; }
    }
}
