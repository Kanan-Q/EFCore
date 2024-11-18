using Microsoft.EntityFrameworkCore;
using NewEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NewEFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Baskets> baskets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IOJO115;Database=NewDB;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
