using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Models;

public partial class BookdbContext : DbContext
{
    public BookdbContext()
    {
    }

    public BookdbContext(DbContextOptions<BookdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Konyv> Konyvs { get; set; }

    public virtual DbSet<Nemzetiseg> Nemzetisegs { get; set; }

    public virtual DbSet<Szerzo> Szerzos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=bookdb;user=root;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Konyv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("konyv");

            entity.HasIndex(e => e.SzerzoId, "szerzo_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Cim)
                .HasMaxLength(50)
                .HasColumnName("cim");
            entity.Property(e => e.Kiadev)
                .HasColumnType("int(11)")
                .HasColumnName("kiadev");
            entity.Property(e => e.Oldalszam)
                .HasColumnType("int(11)")
                .HasColumnName("oldalszam");
            entity.Property(e => e.SzerzoId)
                .HasMaxLength(50)
                .HasColumnName("szerzo_id");

            entity.HasOne(d => d.Szerzo).WithMany(p => p.Konyvs)
                .HasForeignKey(d => d.SzerzoId)
                .HasConstraintName("konyv_ibfk_1");
        });

        modelBuilder.Entity<Nemzetiseg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nemzetiseg");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.SzerzoNemz)
                .HasMaxLength(50)
                .HasColumnName("szerzo_nemz");
        });

        modelBuilder.Entity<Szerzo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("szerzo");

            entity.HasIndex(e => e.NemzId, "nemz_id");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Nem)
                .HasMaxLength(20)
                .HasColumnName("nem");
            entity.Property(e => e.NemzId)
                .HasMaxLength(50)
                .HasColumnName("nemz_id");
            entity.Property(e => e.Nev)
                .HasMaxLength(50)
                .HasColumnName("nev");

            entity.HasOne(d => d.Nemz).WithMany(p => p.Szerzos)
                .HasForeignKey(d => d.NemzId)
                .HasConstraintName("szerzo_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
