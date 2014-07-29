using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Retail.Web.Models {
    public class RetailDbContext : DbContext {

        public RetailDbContext(string connStr)
            : base(connStr) {

        }

        public RetailDbContext()
            : this(@"Data Source=BSTOCKUS-PC\SQLEXPRESS;Initial Catalog=RetailDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False") {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleItem> SaleItems { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

    }
}