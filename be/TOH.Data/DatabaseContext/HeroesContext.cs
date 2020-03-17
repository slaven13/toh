using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TOH.Data.Entities;
using TOH.Data.Entities.Mappings;

namespace TOH.Data.DatabaseContext
{
    public class HeroesContext : DbContext
    {
        public HeroesContext(DbContextOptions<HeroesContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    new HeroesConfiguration(modelBuilder.Entity<Hero>());
        //}
        public DbSet<Hero> Heroes { get; set; }
    }
}