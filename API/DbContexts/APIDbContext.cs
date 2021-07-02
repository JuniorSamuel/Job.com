using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;



namespace API.DbContexts
{
    public partial class APIDbContext : DbContext
    {
        public APIDbContext()
        {

        }
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Solicitud> Solicitudes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vacante> Vacantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:jobbddbserver.database.windows.net,1433;Initial Catalog=JobBD;Persist Security Info=False;User ID=Junior;Password=ASanto 2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C67C6A53F");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584C867FA551");

                entity.ToTable("Rol");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("PK__Solicitu__36899CEFD05F3FF4");

                entity.ToTable("Solicitud");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Solicitud__IdUsu__403A8C7D");

                entity.HasOne(d => d.IdVacanteNavigation)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Solicitud__IdVac__412EB0B6");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97B0B36473");

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula).HasColumnType("numeric(11, 0)");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnType("numeric(15, 0)");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuario__IdRol__3A81B327");
            });

            modelBuilder.Entity<Vacante>(entity =>
            {
                entity.HasKey(e => e.IdVacante)
                    .HasName("PK__Vacante__A58A8FA8D68A2AD6");

                entity.ToTable("Vacante");

                entity.Property(e => e.Compania)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Horario)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Posicion)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnType("numeric(15, 0)");

                entity.Property(e => e.Correo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetimeoffset")
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Vacantes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Vacante__IdUsuar__70DDC3D8");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Vacantes)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vacante__IdCateg__3D5E1FD2");
            });

            foreach (var foreingKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreingKey.DeleteBehavior = DeleteBehavior.Cascade;
            }

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

/*
 TÍTULO: Microsoft SQL Server Management Studio
------------------------------

Error de Quitar para Columna 'IdUsuario'.  (Microsoft.SqlServer.Smo)

Para obtener ayuda, haga clic en: https://go.microsoft.com/fwlink?ProdName=Microsoft+SQL+Server&ProdVer=16.100.46041.41+(SMO-master-A)&EvtSrc=Microsoft.SqlServer.Management.Smo.ExceptionTemplates.FailedOperationExceptionText&EvtID=Quitar+Column&LinkId=20476

------------------------------
INFORMACIÓN ADICIONAL:

Excepción al ejecutar una instrucción o un proceso por lotes Transact-SQL. (Microsoft.SqlServer.ConnectionInfo)

------------------------------

The object 'FK__Vacante__IdUsuar__70DDC3D8' is dependent on column 'IdUsuario'.
ALTER TABLE DROP COLUMN IdUsuario failed because one or more objects access this column. (Microsoft SQL Server, Error: 5074)

Para obtener ayuda, haga clic en: http://go.microsoft.com/fwlink?ProdName=Microsoft%20SQL%20Server&ProdVer=12.00.2148&EvtSrc=MSSQLServer&EvtID=5074&LinkId=20476

------------------------------
BOTONES:

Aceptar
------------------------------

 */