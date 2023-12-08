using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<AssetReport> AssetReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");

        }
    }
}
