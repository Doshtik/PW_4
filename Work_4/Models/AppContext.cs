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

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DBforPW_2;Username=postgres;Password=1111");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FromProductsToPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("FromProductsToPartners_pkey");

            entity.HasIndex(e => e.IdOfPartner, "IX_FromProductsToPartners_IdOfPartner");

            entity.HasIndex(e => e.IdOfProduct, "IX_FromProductsToPartners_IdOfProduct");

            entity.HasOne(d => d.Partner).WithMany(p => p.FromProductsToPartners)
                .HasForeignKey(d => d.IdOfPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partner");

            entity.HasOne(d => d.Product).WithMany(p => p.FromProductsToPartners)
                .HasForeignKey(d => d.IdOfProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Partners_pkey");

            entity.HasIndex(e => e.IdOfPartner, "IX_Partners_IdOfPartner");

            entity.Property(e => e.Rating).HasDefaultValue((short)1);
            entity.Property(e => e.Tin).HasColumnName("TIN");

            entity.HasOne(d => d.IdOfPartnerNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdOfPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partner_type");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Products_pkey");

            entity.HasIndex(e => e.IdOfProduct, "IX_Products_IdOfProduct");

            entity.Property(e => e.MinCostForPartner).HasColumnType("money");

            entity.HasOne(d => d.IdOfProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdOfProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_type");
        });

        modelBuilder.Entity<TypesOfPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypesOfPartner_pkey");

            entity.ToTable("TypesOfPartner");
        });

        modelBuilder.Entity<TypesOfProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypesOfProduct_pkey");

            entity.ToTable("TypesOfProduct");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
