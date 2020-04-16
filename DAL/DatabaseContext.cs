using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class SllehApp : IdentityDbContext
    {
        public SllehApp(DbContextOptions<SllehApp> options) : base(options)
        {

        }
      //  public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
