using Microsoft.EntityFrameworkCore;
using MovieSearch.Domain.Entities;
using MovieSearch.Persistence.Configurations;

namespace MovieSearch.Persistence.Data;

public class MovieSearchDbContext(DbContextOptions<MovieSearchDbContext> options) 
    : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActorConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
       
        base.OnModelCreating(modelBuilder);
    }
}