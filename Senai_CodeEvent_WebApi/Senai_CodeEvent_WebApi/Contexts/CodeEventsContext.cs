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
        public virtual DbSet<Interessados> Interessados { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=47511187811; initial catalog = SENAI_CODEEVENTS;user id = sa; pwd = S#nai@132");
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

                entity.Property(e => e.Categoria).HasColumnName("CATEGORIA");

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

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.Categoria)
                    .HasConstraintName("FK__EVENTOS__CATEGOR__1332DBDC");
            });

            modelBuilder.Entity<Interessados>(entity =>
            {
                entity.ToTable("INTERESSADOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdEvento).HasColumnName("ID_EVENTO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Interessados)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INTERESSA__ID_EV__160F4887");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724D528341D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
