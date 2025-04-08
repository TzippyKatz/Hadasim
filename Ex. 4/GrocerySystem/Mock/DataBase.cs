using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock
{
    public class DataBase : DbContext, IContext
    {
        public DbSet<Merchandise> merchs { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<SupplierMerchandise> supplierMerchandises { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<User> users { get; set; }


        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=COMPUTER-TZIPPY;database=grocery_system;trusted_connection=true");
            //optionsBuilder.UseSqlServer("server=sql;database=Nutrition_monitoring;trusted_connection=true");
        }

        public void save()
        {
            SaveChanges();
        }
    }
}
