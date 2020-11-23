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
        public DbSet<TP.Models.Donante> Donante { get; set; }
        public DbSet<TP.Models.Adopcion> Adopcion { get; set; }
        public DbSet<TP.Models.Adoptante> Adoptante { get; set; }
        public DbSet<TP.Models.Animal> Animal { get; set; }
        public DbSet<TP.Models.Organizacion> Organizacion { get; set; }
        public DbSet<TP.Models.Producto> Producto { get; set; }
        public DbSet<TP.Models.Calendario> Calendario { get; set; }
    }
}
