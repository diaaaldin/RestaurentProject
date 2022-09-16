using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestaurentProject.Models;

#nullable disable

namespace RestaurentProject.Data
{
    public partial class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
        {
        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerMenu> CustomerMenus { get; set; }
        public virtual DbSet<ExportDatum> ExportData { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurentMenu> RestaurentMenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
       //         optionsBuilder.UseSqlServer("Server=DESKTOP-K722RLO\\SQLEXPRESS;Database=RestaurantDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<CustomerMenu>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.RestaurentMenuId });

                entity.HasIndex(e => e.RestaurentMenuId, "IX_CustomerMenus_RestaurentMenuId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerMenus)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.RestaurentMenu)
                    .WithMany(p => p.CustomerMenus)
                    .HasForeignKey(d => d.RestaurentMenuId);
            });

            modelBuilder.Entity<ExportDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Export Data");

                entity.Property(e => e.PriceInNis).HasColumnName("PriceInNIS");

                entity.Property(e => e.PriceInUsd).HasColumnName("PriceInUSD");

                entity.Property(e => e.RestaurentName).HasColumnName("Restaurent Name");
            });

            modelBuilder.Entity<RestaurentMenu>(entity =>
            {
                entity.HasIndex(e => e.RestaurantId, "IX_RestaurentMenus_RestaurantId");

                entity.Property(e => e.PriceInNis).HasColumnName("PriceInNIS");

                entity.Property(e => e.PriceInUsd).HasColumnName("PriceInUSD");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurentMenus)
                    .HasForeignKey(d => d.RestaurantId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
