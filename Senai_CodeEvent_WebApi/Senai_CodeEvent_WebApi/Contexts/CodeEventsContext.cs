using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai_CodeEvent_WebApi.Domains
{
    public partial class CodeEventsContext : DbContext
    {
        public CodeEventsContext()
        {
        }

        public CodeEventsContext(DbContextOptions<CodeEventsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosEventos> UsuariosEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=xzzzzzzzzzzzzzz\\NOME; initial catalog = SENAI_CODEEVENTS; integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.ToTable("CATEGORIAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.ToTable("EVENTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Capacidade).HasColumnName("CAPACIDADE");

                entity.Property(e => e.Categorias).HasColumnName("CATEGORIAS");

                entity.Property(e => e.DataEvento)
                    .HasColumnName("DATA_EVENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem)
                    .HasColumnName("IMAGEM")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Restricao).HasColumnName("RESTRICAO");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoriasNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.Categorias)
                    .HasConstraintName("FK__EVENTOS__CATEGOR__571DF1D5");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF7240B5E94F3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuariosEventos>(entity =>
            {
                entity.ToTable("USUARIOS_EVENTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEvento).HasColumnName("ID_EVENTO");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.UsuariosEventos)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__USUARIOS___ID_EV__5AEE82B9");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UsuariosEventos)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__USUARIOS___ID_US__59FA5E80");
            });
        }
    }
}
