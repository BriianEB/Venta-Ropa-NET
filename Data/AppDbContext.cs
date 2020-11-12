using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VentaRopa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VentaRopa.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductoModel> Productos { get; set; }
        public DbSet<VentaModel> Ventas { get; set; }
    }
}
