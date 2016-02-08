using Kevull.Invoices.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kevull.Invoices.Persistence.Configuration;
using Microsoft.Data.Sqlite;

namespace Kevull.Invoices.Persistence {
    public class Context : DbContext {
        public DbSet<Customer> Customers { get; set; }

        //public Context(DbContextOptions options) : base(options) {
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var builder = new SqliteConnectionStringBuilder { DataSource = "Data.db" };
            optionsBuilder.UseSqlite(builder.ToString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            new CustomerConfiguration(modelBuilder.Entity<Customer>());
        }

    }
}
