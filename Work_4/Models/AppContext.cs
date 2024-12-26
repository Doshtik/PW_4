using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Work_4.Models;

public partial class AppContext : DbContext
{
    public AppContext() { }

    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    public virtual DbSet<FromProductsToPartner> FromProductsToPartners { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TypesOfPartner> TypesOfPartners { get; set; }

    public virtual DbSet<TypesOfProduct> TypesOfProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DBforPW_2;Username=postgres;Password=1111");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FromProductsToPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("FromProductsToPartners_pkey");

            entity.HasOne(d => d.IdOfPartnerNavigation).WithMany(p => p.FromProductsToPartners)
                .HasForeignKey(d => d.IdOfPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partner");

            entity.HasOne(d => d.IdOfProductNavigation).WithMany(p => p.FromProductsToPartners)
                .HasForeignKey(d => d.IdOfProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Partners_pkey");

            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.FullnameOfDirector).HasMaxLength(125);
            entity.Property(e => e.LegalAdress).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(12);
            entity.Property(e => e.Rating).HasDefaultValue((short)1);
            entity.Property(e => e.Tin)
                .HasMaxLength(12)
                .HasColumnName("TIN");

            entity.HasOne(d => d.IdOfPartnerNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdOfPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partner_type");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Products_pkey");

            entity.Property(e => e.Article).HasMaxLength(12);
            entity.Property(e => e.MinCostForPartner).HasColumnType("money");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.IdOfProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdOfProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_type");
        });

        modelBuilder.Entity<TypesOfPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypesOfPartner_pkey");

            entity.ToTable("TypesOfPartner");

            entity.Property(e => e.TypeOfPartner).HasMaxLength(50);
        });

        modelBuilder.Entity<TypesOfProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypesOfProduct_pkey");

            entity.ToTable("TypesOfProduct");

            entity.Property(e => e.TypeOfProduct).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
