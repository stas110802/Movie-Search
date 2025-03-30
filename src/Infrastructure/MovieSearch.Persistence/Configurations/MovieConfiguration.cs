using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSearch.Domain.Entities;

namespace MovieSearch.Persistence.Configurations;

public sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(c => c.Id);
        builder
            .HasMany(c => c.Actors)
            .WithMany(s => s.Movies);
    }
}