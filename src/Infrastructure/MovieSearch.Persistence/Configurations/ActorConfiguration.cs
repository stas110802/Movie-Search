using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSearch.Domain.Entities;

namespace MovieSearch.Persistence.Configurations;

public sealed class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(c => c.Id);
        builder
            .HasMany(c => c.Movies)
            .WithMany(s => s.Actors);
    }
}