using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AgencyContext : DbContext
    {
        public AgencyContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<Section1> Section1s { get; set; }
        public DbSet<Section2> Section2s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Section1>().HasData(
                new Section1 {Id=1, Header = "Basliq", Subheader = "Sub Header", PhotoUrl = "test.jpg" });

            modelBuilder.Entity<Section2>().HasData(
             new Section2 { Id=1,Header = "Basliq", Description = "Test Desc", Icon= "icon.jpg" });
        }
    }
}
