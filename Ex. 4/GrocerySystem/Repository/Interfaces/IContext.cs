using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IContext
    {
        public DbSet<User> users { get; set;  }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Merchandise> merchs { get; set; }
        public DbSet<SupplierMerchandise> supplierMerchandises { get; set; }
        void save();
    }
}
