using Microsoft.EntityFrameworkCore;
using MovieSearch.Domain.Entities;
using MovieSearch.Persistence.Data;

namespace MovieSearch.Persistence.Test;

public class DbContextTests : IDisposable
{
    private MovieSearchDbContext _context;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<MovieSearchDbContext>()
            .UseInMemoryDatabase("test-db")
            .Options;

        _context = new MovieSearchDbContext(options);
    }

    [Test]
    public async Task AddItemsInDbSetsTest()
    {
        var movie = new Movie
        {
            Title = "Star Wars: The Force Awakens",
            Description = "Star Wars: The Force Awakens do some stuff and more...",
            Genre = "Action",
            Poster = "N/A",
            Type = "movie",
            Year = "2011"
        };
        await _context.Movies.AddAsync(movie);

        var result = await _context.SaveChangesAsync();
        if (result > 0 == false)
            Assert.Fail();

        var movies = await _context.Movies.ToListAsync();
        if (movies.Count > 0 == false)
            Assert.Fail();

        var actor = new Actor
        {
            Name = "Boris Britva",
        };

        actor.Movies.Add(movies[0]);
        await _context.Actors.AddAsync(actor);

        var result2 = await _context.SaveChangesAsync();
        if (result2 > 0 == false)
            Assert.Fail();

        var actors = await _context.Actors.ToListAsync();
        if (actors.Count > 0 == false)
            Assert.Fail();

        if (actors[0].Movies[0].Id != movies[0].Id)
            Assert.Fail();

        Assert.Pass();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}