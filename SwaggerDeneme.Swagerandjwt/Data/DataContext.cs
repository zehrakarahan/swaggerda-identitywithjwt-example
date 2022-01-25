using Microsoft.EntityFrameworkCore;
using SwaggerDeneme.Swagerandjwt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.Swagerandjwt.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Userr { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Invoices> Invoices { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
