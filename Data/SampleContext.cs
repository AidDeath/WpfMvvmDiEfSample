using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfMvvmDiEfSample.Models;

namespace WpfMvvmDiEfSample.Data
{
    public class SampleContext : DbContext
    {
        public SampleContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = test.db");
        }


        public DbSet<Band> Bands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(new Band[] { 
                new Band { Id = 1, Name = "As I Lay Dying", Genre = "Metal"},
                new Band { Id = 2, Name = "Metallica", Genre = "Alternative"},
                new Band { Id = 3, Name = "Hobostank", Genre = "NewWave"}
            });
        }


    }
}
