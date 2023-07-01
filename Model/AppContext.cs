using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Model
{
    class AppContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O6O2RKO;Database=Pharmacy_db;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
