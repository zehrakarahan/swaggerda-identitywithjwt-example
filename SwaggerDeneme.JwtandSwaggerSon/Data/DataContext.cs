using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwaggerDeneme.JwtandSwaggerSon.IdentityAuth;
using SwaggerDeneme.JwtandSwaggerSon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.JwtandSwaggerSon.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Userr { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Invoices> Invoices { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
