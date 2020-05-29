using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.DAL.Models
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
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerNotifications> CustomerNotifications { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<Malfunction> Malfunction { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }
        public virtual DbSet<WorkshopCar> WorkshopCar { get; set; }
        public virtual DbSet<WorkshopFeatures> WorkshopFeatures { get; set; }
        public virtual DbSet<WorkshopMalfunction> WorkshopMalfunction { get; set; }
        public virtual DbSet<WorkshopNotifications> WorkshopNotifications { get; set; }
        public virtual DbSet<WorkshopRate> WorkshopRate { get; set; }
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

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

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

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.Messageld)
                    .HasName("PK_OrderNotifications");

                entity.Property(e => e.Messageld).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ChatNotifications_Order");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CityName).HasDefaultValueSql("('')");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

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

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Token).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<CustomerNotifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.Property(e => e.NotificationId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerNotifications)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerNotifications_Customer");
            });

            modelBuilder.Entity<Features>(entity =>
            {
                entity.Property(e => e.FeaturesId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Malfunction>(entity =>
            {
                entity.Property(e => e.MalfunctionId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.MapLangitude).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.MapLatitude).HasColumnType("decimal(18, 10)");

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

            modelBuilder.Entity<Workshop>(entity =>
            {
                entity.Property(e => e.WorkshopId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.MapLangitude).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.MapLatitude).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Token).HasDefaultValueSql("('')");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Workshop)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Workshop_City");
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
                entity.HasKey(e => e.FeatureWorkeshopId);

                entity.Property(e => e.FeatureWorkeshopId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.WorkshopFeatures)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_WorkshopFeatures_Features");

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

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopNotifications)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_WorkshopNotifications_Workshop");
            });

            modelBuilder.Entity<WorkshopRate>(entity =>
            {
                entity.HasKey(e => e.RateId)
                    .HasName("PK_RateWorkshop");

                entity.Property(e => e.RateId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Rate).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.WorkshopRate)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_RateWorkshop_Customer");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopRate)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_RateWorkshop_Workshop");
            });

            modelBuilder.Entity<WorkshopTechnician>(entity =>
            {
                entity.HasKey(e => e.TechnicianId);

                entity.Property(e => e.TechnicianId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

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

                entity.Property(e => e.FromTime)
                    .HasColumnType("decimal(15, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ToTime)
                    .HasColumnType("decimal(15, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.WorkshopWorkTime)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_WorkshopWorkTime_Workshop");
            });
        }
    }
}
