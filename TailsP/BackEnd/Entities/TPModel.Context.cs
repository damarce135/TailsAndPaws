﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using static Identity.Identity;

    public partial class TPEntities : IdentityDbContext<ApplicationUser>
    {
        public TPEntities()
            : base("name=TPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adopcion> adopcion { get; set; }
        public virtual DbSet<adoptante> adoptante { get; set; }
        public virtual DbSet<animal> animal { get; set; }
        public virtual DbSet<canton> canton { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cita> cita { get; set; }
        public virtual DbSet<distrito> distrito { get; set; }
        public virtual DbSet<donante> donante { get; set; }
        public virtual DbSet<grupoSanguineo> grupoSanguineo { get; set; }
        public virtual DbSet<organizacion> organizacion { get; set; }
        public virtual DbSet<prodCategoria> prodCategoria { get; set; }
        public virtual DbSet<prodProveedor> prodProveedor { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<provincia> provincia { get; set; }
        public virtual DbSet<recordatorio> recordatorio { get; set; }
        public virtual DbSet<seguimiento> seguimiento { get; set; }
    }
}
