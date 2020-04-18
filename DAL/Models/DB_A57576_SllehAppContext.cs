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
        }
    }
}
