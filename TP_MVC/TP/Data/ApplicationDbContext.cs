using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TP.Models;

namespace TP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Adopcion> Adopcion { get; set; }
        public virtual DbSet<Adoptante> Adoptante { get; set; }
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Donante> Donante { get; set; }
        public virtual DbSet<GrupoSanguineo> GrupoSanguineo { get; set; }
        public virtual DbSet<Organizacion> Organizacion { get; set; }
        public virtual DbSet<ProdCategorium> ProdCategoria { get; set; }
        public virtual DbSet<ProdProveedor> ProdProveedor { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Provincium> Provincia { get; set; }
    }
}
