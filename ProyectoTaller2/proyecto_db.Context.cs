﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTaller2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class proyecto_taller2Entities : DbContext
    {
        public proyecto_taller2Entities()
            : base("name=proyecto_taller2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<factura> factura { get; set; }
        public virtual DbSet<factura_detalle> factura_detalle { get; set; }
        public virtual DbSet<marca> marca { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<tipo_usuario> tipo_usuario { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
