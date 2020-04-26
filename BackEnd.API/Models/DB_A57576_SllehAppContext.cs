﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.API.Models
{
    public partial class DB_A57576_SllehAppContext : DbContext
    {
        public DB_A57576_SllehAppContext()
        {
        }

        public DB_A57576_SllehAppContext(DbContextOptions<DB_A57576_SllehAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminUsers> AdminUsers { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerNotifications> CustomerNotifications { get; set; }
        public virtual DbSet<Malfunction> Malfunction { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<RateWorkshop> RateWorkshop { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }
        public virtual DbSet<WorkshopCar> WorkshopCar { get; set; }
        public virtual DbSet<WorkshopFeatures> WorkshopFeatures { get; set; }
        public virtual DbSet<WorkshopMalfunction> WorkshopMalfunction { get; set; }
        public virtual DbSet<WorkshopNotifications> WorkshopNotifications { get; set; }
        public virtual DbSet<WorkshopTechnician> WorkshopTechnician { get; set; }
        public virtual DbSet<WorkshopWorkTime> WorkshopWorkTime { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SQL5050.site4now.net;Database=DB_A57576_SllehApp;User Id=DB_A57576_SllehApp_admin;Password=zaid2slleh;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AdminUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_city_country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CountryName).HasDefaultValueSql("('')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerNotifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.Property(e => e.NotificationId).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerNotifications)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerNotifications_Customer");
            });

            modelBuilder.Entity<Malfunction>(entity =>
            {
                entity.Property(e => e.MalfunctionId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.MapLangitude).HasMaxLength(50);

                entity.Property(e => e.MapLatitude).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_Order_Workshop");
            });

            modelBuilder.Entity<RateWorkshop>(entity =>
            {
                entity.HasKey(e => e.RateId);

                entity.Property(e => e.RateId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RateWorkshop)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_RateWorkshop_Customer");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.RateWorkshop)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_RateWorkshop_Workshop");
            });

            modelBuilder.Entity<Workshop>(entity =>
            {
                entity.Property(e => e.WorkshopId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.MapLangitude).HasMaxLength(50);

                entity.Property(e => e.MapLatitude).HasMaxLength(50);

                entity.Property(e => e.OwnerName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkshopCar>(entity =>
            {
                entity.Property(e => e.WorkshopCarId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.WorkshopCar)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_WorkshopCar_Car");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopCar)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_WorkshopCar_Workshop");
            });

            modelBuilder.Entity<WorkshopFeatures>(entity =>
            {
                entity.HasKey(e => e.FeatureId);

                entity.Property(e => e.FeatureId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopFeatures)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_WorkshopFeatures_Workshop");
            });

            modelBuilder.Entity<WorkshopMalfunction>(entity =>
            {
                entity.Property(e => e.WorkshopMalfunctionId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Malfunction)
                    .WithMany(p => p.WorkshopMalfunction)
                    .HasForeignKey(d => d.MalfunctionId)
                    .HasConstraintName("FK_WorkshopMalfunction_Malfunction");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopMalfunction)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_WorkshopMalfunction_Workshop");
            });

            modelBuilder.Entity<WorkshopNotifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.Property(e => e.NotificationId).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopNotifications)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_WorkshopNotifications_Workshop");
            });

            modelBuilder.Entity<WorkshopTechnician>(entity =>
            {
                entity.HasKey(e => e.TechnicianId);

                entity.Property(e => e.TechnicianId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopTechnician)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_WorkshopTechnician_Workshop");
            });

            modelBuilder.Entity<WorkshopWorkTime>(entity =>
            {
                entity.HasKey(e => e.WorkTimeId);

                entity.Property(e => e.WorkTimeId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.FromTime).HasColumnType("datetime");

                entity.Property(e => e.ToTime).HasColumnType("datetime");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopWorkTime)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_WorkshopWorkTime_Workshop");
            });
        }
    }
}