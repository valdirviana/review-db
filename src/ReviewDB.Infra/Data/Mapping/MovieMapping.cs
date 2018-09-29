using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewDB.Domain.Entities.MovieAggregate;

namespace ReviewDB.Infra.Data.Mapping
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(u => u.TmdbId);
            builder.Property(u => u.OriginalTitle).HasMaxLength(250).IsRequired();
            builder.Property(u => u.Overview).HasMaxLength(1500);
            builder.Property(u => u.ImdbId).HasMaxLength(12);
            builder.Property(u => u.Popularity);
            builder.Property(u => u.ReleaseDate);
            builder.Property(u => u.Homepage).HasMaxLength(250);
            builder.Property(u => u.Adult);
        }
    }
}
