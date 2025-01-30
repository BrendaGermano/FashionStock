using FashionStock.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStock.Data
{
    public class BusinessContext : DbContext, IBusinessContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<StockRecord> StockRecords { get; set ; }
        public DbSet<RecordType> RecordTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SQL1002.site4now.net;Database=db_ab23c8_fashion;User Id=db_ab23c8_fashion_admin;Password=Tae.30121995;Trusted_Connection=True;TrustServerCertificate=false;Integrated Security=false;Encrypt=False");
        }
    }
}
