using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TP.Models
{
    public partial class TPContext : DbContext
    {
        public TPContext()
        {
        }

        public TPContext(DbContextOptions<TPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adopcion> Adopcions { get; set; }
        public virtual DbSet<Adoptante> Adoptantes { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Calendario> Calendarios { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Donante> Donantes { get; set; }
        public virtual DbSet<GrupoSanguineo> GrupoSanguineos { get; set; }
        public virtual DbSet<Organizacion> Organizacions { get; set; }
        public virtual DbSet<ProdCategorium> ProdCategoria { get; set; }
        public virtual DbSet<ProdProveedor> ProdProveedors { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Provincium> Provincia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tailsandpaws.database.windows.net;Database=TP;User Id=tailsandpaws;Password=fidelitas123!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adopcion>(entity =>
            {
                entity.HasKey(e => e.IdAdopcion)
                    .HasName("PK__adopcion__210DF8AD52FE3D92");

                entity.ToTable("adopcion");

                entity.Property(e => e.IdAdopcion).HasColumnName("idAdopcion");

                entity.Property(e => e.FechaAdopcion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAdopcion");

                entity.Property(e => e.FechaSeguimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaSeguimiento");

                //entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.IdAdoptante).HasColumnName("idAdoptante");

                entity.Property(e => e.IdAnimal).HasColumnName("idAnimal");

                entity.HasOne(d => d.IdAdoptanteNavigation)
                    .WithMany(p => p.Adopcions)
                    .HasForeignKey(d => d.IdAdoptante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__adopcion__idAdop__7C4F7684");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Adopcions)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__adopcion__idAnim__7D439ABD");
            });

            modelBuilder.Entity<Adoptante>(entity =>
            {
                entity.HasKey(e => e.IdAdoptante)
                    .HasName("PK__adoptant__B3BB8FCEE7385A66");

                entity.ToTable("adoptante");

                entity.HasIndex(e => e.Cedula, "UQ__adoptant__415B7BE5D262FB6A")
                    .IsUnique();

                entity.Property(e => e.IdAdoptante).HasColumnName("idAdoptante");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.DetalleDireccion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("detalleDireccion");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                //entity.Property(e => e.IdCanton).HasColumnName("idCanton");

                //entity.Property(e => e.IdDistrito).HasColumnName("idDistrito");

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                //entity.HasOne(d => d.IdCantonNavigation)
                //    .WithMany(p => p.Adoptantes)
                //    .HasForeignKey(d => d.IdCanton)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__adoptante__idCan__7E37BEF6");

                //entity.HasOne(d => d.IdDistritoNavigation)
                //    .WithMany(p => p.Adoptantes)
                //    .HasForeignKey(d => d.IdDistrito)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__adoptante__idDis__7F2BE32F");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Adoptantes)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__adoptante__idPro__00200768");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                    .HasName("PK__animal__0276B50398A82262");

                entity.ToTable("animal");

                entity.Property(e => e.IdAnimal).HasColumnName("idAnimal");

                entity.Property(e => e.Adoptado).HasColumnName("adoptado");

                entity.Property(e => e.Castrado).HasColumnName("castrado");

                entity.Property(e => e.Edad)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("edad");

                entity.Property(e => e.Especie)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("especie");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.Caracteristicas)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("caracteristicas");

                //entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                //entity.Property(e => e.IdGsanguineo).HasColumnName("idGSanguineo");

                entity.Property(e => e.IdOrganizacion).HasColumnName("idOrganizacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tamano)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("raza");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                //entity.HasOne(d => d.IdGsanguineoNavigation)
                //    .WithMany(p => p.Animals)
                //    .HasForeignKey(d => d.IdGsanguineo)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__animal__idGSangu__01142BA1");

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__animal__idOrgani__02084FDA");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasKey(e => e.IdCalendario)
                    .HasName("PK__calendar__C661AF173FFA7A17");

                entity.ToTable("calendario");

                entity.Property(e => e.IdCalendario).HasColumnName("idCalendario");

                entity.Property(e => e.Asunto)
                    .HasMaxLength(100)
                    .HasColumnName("asunto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .HasColumnName("descripcion");

                entity.Property(e => e.DiaCompleto).HasColumnName("diaCompleto");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFinal");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.TemaColor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("temaColor");
            });

            //modelBuilder.Entity<Canton>(entity =>
            //{
            //    entity.HasKey(e => e.IdCanton)
            //        .HasName("PK__canton__622851F2CC5E22A7");

            //    entity.ToTable("canton");

            //    entity.Property(e => e.IdCanton)
            //        .ValueGeneratedNever()
            //        .HasColumnName("idCanton");

            //    entity.Property(e => e.NombreCanton)
            //        .IsRequired()
            //        .HasMaxLength(45)
            //        .IsUnicode(false)
            //        .HasColumnName("nombreCanton");
            //});

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__8A3D240C55EDD721");

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreCategoria");
            });

            //modelBuilder.Entity<Distrito>(entity =>
            //{
            //    entity.HasKey(e => e.IdDistrito)
            //        .HasName("PK__distrito__494092A8DBDBD146");

            //    entity.ToTable("distrito");

            //    entity.Property(e => e.IdDistrito)
            //        .ValueGeneratedNever()
            //        .HasColumnName("idDistrito");

            //    entity.Property(e => e.NombreDistrito)
            //        .HasMaxLength(45)
            //        .IsUnicode(false)
            //        .HasColumnName("nombreDistrito");
            //});

            modelBuilder.Entity<Donante>(entity =>
            {
                entity.HasKey(e => e.IdDonante)
                    .HasName("PK__donante__88EDC70B2988F4BA");

                entity.ToTable("donante");

                entity.Property(e => e.IdDonante).HasColumnName("idDonante");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                //entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<GrupoSanguineo>(entity =>
            {
                entity.HasKey(e => e.IdGsanguineo)
                    .HasName("PK__grupoSan__0DD9600EA281BB10");

                entity.ToTable("grupoSanguineo");

                entity.Property(e => e.IdGsanguineo).HasColumnName("idGSanguineo");

                entity.Property(e => e.NombreGsanguineo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreGSanguineo");
            });

            modelBuilder.Entity<Organizacion>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacion)
                    .HasName("PK__organiza__E31291EE94283359");

                entity.ToTable("organizacion");

                entity.Property(e => e.IdOrganizacion).HasColumnName("idOrganizacion");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.DetalleDireccion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("detalleDireccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                //entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                //entity.Property(e => e.IdCanton).HasColumnName("idCanton");

                //entity.Property(e => e.IdDistrito).HasColumnName("idDistrito");

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                //entity.HasOne(d => d.IdCantonNavigation)
                //    .WithMany(p => p.Organizacions)
                //    .HasForeignKey(d => d.IdCanton)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__organizac__idCan__02FC7413");

                //entity.HasOne(d => d.IdDistritoNavigation)
                //    .WithMany(p => p.Organizacions)
                //    .HasForeignKey(d => d.IdDistrito)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__organizac__idDis__03F0984C");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Organizacions)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__organizac__idPro__04E4BC85");
            });

            modelBuilder.Entity<ProdCategorium>(entity =>
            {
                entity.HasKey(e => e.IdProdCategoria)
                    .HasName("PK__prodCate__2D25CE78CE00D6FE");

                entity.ToTable("prodCategoria");

                entity.Property(e => e.IdProdCategoria).HasColumnName("idProdCategoria");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.ProdCategoria)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prodCateg__idCat__05D8E0BE");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProdCategoria)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prodCateg__idPro__06CD04F7");
            });

            modelBuilder.Entity<ProdProveedor>(entity =>
            {
                entity.HasKey(e => e.IdProdProveedor)
                    .HasName("PK__prodProv__809C77CB2ECCDA04");

                entity.ToTable("prodProveedor");

                entity.Property(e => e.IdProdProveedor).HasColumnName("idProdProveedor");

                entity.Property(e => e.IdOrganizacion).HasColumnName("idOrganizacion");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.ProdProveedors)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prodProve__idOrg__08B54D69");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProdProveedors)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prodProve__idPro__07C12930");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__producto__07F4A1329AE572F3");

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                //entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__provinci__5F9F113CB5050902");

                entity.ToTable("provincia");

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.Property(e => e.NombreProvincia)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreProvincia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
