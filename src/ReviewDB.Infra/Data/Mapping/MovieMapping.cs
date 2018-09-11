using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewDB.Domain.Entities.MovieAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewDB.Infra.Data.Mapping
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(u => u.Title).HasMaxLength(250);
        }
    }
}
