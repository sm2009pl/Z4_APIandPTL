using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;


namespace Z4_API
{
    class Context : DbContext
    {
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Coaches> Coaches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FootballDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Teams>()
                .Property(x => x.id)
                .IsRequired();
            modelBuilder.Entity<Teams>()
                .Property(x => x.school)
                .HasMaxLength(90)
                .IsRequired();
            modelBuilder.Entity<Teams>()
                .Property(x => x.mascot)
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(x => x.abbreviation);
            modelBuilder.Entity<Teams>()
                .Property(x => x.alt_name1);
            modelBuilder.Entity<Teams>()
                .Property(x => x.alt_name2);
            modelBuilder.Entity<Teams>()
                .Property(x => x.alt_name3);
            modelBuilder.Entity<Teams>()
                .Property(x => x.conference);
            modelBuilder.Entity<Teams>()
                .Property(x => x.division);
            modelBuilder.Entity<Teams>()
                .Property(x => x.color);
            modelBuilder.Entity<Teams>()
                .Property(x => x.alt_color);
            modelBuilder.Entity<Teams>()
                .Property(x => x.logos);


            modelBuilder.Entity<Coaches>()
                .Property(x => x.first_name)
                .IsRequired();
            modelBuilder.Entity<Coaches>()
                .Property(x => x.last_name)
                .IsRequired();

        }
    }
}