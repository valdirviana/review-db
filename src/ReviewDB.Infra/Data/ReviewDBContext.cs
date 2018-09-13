using Microsoft.EntityFrameworkCore;
using ReviewDB.Domain.Entities.MovieAggregate;
using ReviewDB.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewDB.Infra.Data
{
    public class ReviewDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public ReviewDBContext(DbContextOptions<ReviewDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MovieMapping());
        }
    }
}
