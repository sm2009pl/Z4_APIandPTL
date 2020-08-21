using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Z4_API
{
    public class FootballContext : DbContext
    {
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Coaches> Coaches { get; set; }
        public DbSet<Seasons> Seasons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FootbalDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}