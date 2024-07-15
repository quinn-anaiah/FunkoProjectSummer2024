using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFunkoApi.Models;

public partial class AnaiahFunkoDatabaseContext : DbContext
{
    public AnaiahFunkoDatabaseContext()
    {
    }

    public AnaiahFunkoDatabaseContext(DbContextOptions<AnaiahFunkoDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Edition> Editions { get; set; }

    public virtual DbSet<ExclusiveStore> ExclusiveStores { get; set; }

    public virtual DbSet<FunkoPop> FunkoPops { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Series> Series { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=anaiah_funko_database;Username=postgres;Password=angell57!!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Edition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("edition_pkey");

            entity.ToTable("edition");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ExclusiveStore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exclusive-stores_pkey");

            entity.ToTable("exclusive_stores");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"exclusive-stores_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<FunkoPop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("funko-pops_pkey");

            entity.ToTable("funko_pops");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"funko-pops_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.BobbleHead).HasColumnName("bobble_head");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Count)
                .HasDefaultValue(1)
                .HasColumnName("count");
            entity.Property(e => e.CurrentAvgPrice).HasColumnName("current_avg_price");
            entity.Property(e => e.DateAcquired).HasColumnName("date_acquired");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.EditionId).HasColumnName("edition_id");
            entity.Property(e => e.ExclusiveStoreId).HasColumnName("exclusive_store_id");
            entity.Property(e => e.Gift).HasColumnName("gift");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(400)
                .HasColumnName("image_url");
            entity.Property(e => e.MaterialsId).HasColumnName("materials_id");
            entity.Property(e => e.MaxPrice).HasColumnName("max_price");
            entity.Property(e => e.ModelNumber).HasColumnName("model_number");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OriginalPrice).HasColumnName("original_price");
            entity.Property(e => e.Owned).HasColumnName("owned");
            entity.Property(e => e.SeriesId).HasColumnName("series_id");

            entity.HasOne(d => d.Category).WithMany(p => p.FunkoPops)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_funko_pops_category_category_id");

            entity.HasOne(d => d.Edition).WithMany(p => p.FunkoPops)
                .HasForeignKey(d => d.EditionId)
                .HasConstraintName("fk_funko_pops_edition_edition_id");

            entity.HasOne(d => d.ExclusiveStore).WithMany(p => p.FunkoPops)
                .HasForeignKey(d => d.ExclusiveStoreId)
                .HasConstraintName("fk_funko_pops_exclusive_stores_exclusive_store_id");

            entity.HasOne(d => d.Materials).WithMany(p => p.FunkoPops)
                .HasForeignKey(d => d.MaterialsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_funko_pops_materials_materials_id");

            entity.HasOne(d => d.Series).WithMany(p => p.FunkoPops)
                .HasForeignKey(d => d.SeriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_funko_pops_series_series_id");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materials_pkey");

            entity.ToTable("materials");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Series>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("series_pkey");

            entity.ToTable("series");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
