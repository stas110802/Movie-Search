using Microsoft.EntityFrameworkCore;
using MovieSearch.Domain.Entities;
using MovieSearch.Domain.Repositories;
using MovieSearch.Persistence.Data;
using MovieSearch.Persistence.Repositories;

namespace MovieSearch.Persistence.Test;

public class RepositoryTests : IDisposable
{
    private MovieSearchDbContext _dbContext;
    private IActorRepository _actorRepository;
    private IMovieRepository _movieRepository;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<MovieSearchDbContext>()
            .UseInMemoryDatabase("test-db")
            .Options;

        _dbContext = new MovieSearchDbContext(options);
        _actorRepository = new ActorRepository(_dbContext);
        _movieRepository = new MovieRepository(_dbContext);
    }

    [Test]
    public async Task RepositoriesTests()
    {
        var newMovie = new Movie
        {
            Title = "Star Wars: The Force Awakens",
            Description = "Star Wars: The Force Awakens do some stuff and more...",
            Genre = "Action",
            Poster = "N/A",
            Type = "movie",
            Year = "2011"
        };
        var newActor = new Actor
        {
            Name = "Boris Britva"
        };
        
        await _actorRepository.AddAsync(newActor);
        await _movieRepository.AddAsync(newMovie);
        
        var actors = await _actorRepository.GetAllAsync();
        if(actors.Any() == false)
            Assert.Fail();
        
        var searchMovies = await _movieRepository.GetByTitleAsync("Star Wars: The Force");
        if(searchMovies.Any() == false)
            Assert.Fail();
        
        Assert.Pass();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}