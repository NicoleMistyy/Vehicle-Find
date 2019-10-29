using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleFind.Entities.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Models> Models { get; set; }
        public DbSet<Specifications> Specifications { get; set; }

        private string DatabasePath { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
