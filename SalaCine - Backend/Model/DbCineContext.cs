using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalaCine___Backend.Model;

public partial class DbCineContext : DbContext
{
    public DbCineContext()
    {
    }

    public DbCineContext(DbContextOptions<DbCineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaSalacine> PeliculaSalacines { get; set; }

    public virtual DbSet<SalaCine> SalaCines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id_Pelicula).HasName("PK__pelicula__B5017F4DCA88243D");

            entity.ToTable("pelicula");

            entity.Property(e => e.Id_Pelicula)
                .ValueGeneratedNever()
                .HasColumnName("id_pelicula");
            entity.Property(e => e.Duracion)
                .HasPrecision(5)
                .HasColumnName("duracion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PeliculaSalacine>(entity =>
        {
            entity.HasKey(e => e.IdPeliculaSala).HasName("PK__pelicula__39BC477F9E1953FE");

            entity.ToTable("pelicula_salacine");

            entity.Property(e => e.IdPeliculaSala)
                .ValueGeneratedNever()
                .HasColumnName("id_pelicula_sala");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.IdSalaCine).HasColumnName("id_sala_cine");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.IdPelicula)
                .HasConstraintName("FK__pelicula___id_pe__3C69FB99");

            entity.HasOne(d => d.IdSalaCineNavigation).WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.IdSalaCine)
                .HasConstraintName("FK__pelicula___id_sa__3B75D760");
        });

        modelBuilder.Entity<SalaCine>(entity =>
        {
            entity.HasKey(e => e.IdSala).HasName("PK__sala_cin__D18B015B367D9533");

            entity.ToTable("sala_cine");

            entity.Property(e => e.IdSala)
                .ValueGeneratedNever()
                .HasColumnName("id_sala");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
