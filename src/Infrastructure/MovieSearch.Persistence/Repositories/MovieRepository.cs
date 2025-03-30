using Microsoft.EntityFrameworkCore;
using MovieSearch.Domain.Entities;
using MovieSearch.Domain.Repositories;
using MovieSearch.Persistence.Data;
using FuzzySharp;

namespace MovieSearch.Persistence.Repositories;

public sealed class MovieRepository : IMovieRepository
{
    private readonly MovieSearchDbContext _dbContext;

    public MovieRepository(MovieSearchDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _dbContext
            .Movies
            .Include(a => a.Actors)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetByTitleAsync(string title, int ratio = 75)
    {
        var allMovies = await GetAllAsync();
        var matches = allMovies
            .Where(m => Fuzz.Ratio(m.Title, title) > ratio)
            .ToList();

        return matches;
    }

    public async Task<IEnumerable<Movie>> GetByGenreAsync(string genre, int ratio = 75)
    {
        var allMovies = await GetAllAsync();
        var matches = allMovies
            .Where(m => Fuzz.Ratio(m.Genre, genre) > ratio)
            .ToList();

        return matches;
    }

    public async Task<IEnumerable<Movie>> GetByActorAsync(string actor, int ratio = 75)
    {
        var allMovies = await GetAllAsync();
        var result = new List<Movie>();

        foreach (var movie in allMovies)
        {
            var matches = movie
                .Actors
                .Where(m => Fuzz.Ratio(m.Name, actor) > ratio)
                .ToList();
            if (matches.Count != 0)
            {
                result.Add(movie);
            }
        }

        return result;
    }

    public async Task AddAsync(Movie movie)
    {
        await _dbContext.Movies.AddAsync(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddActorToMovieAsync(int movieId, int actorId)
    {
        var movie = await _dbContext
            .Movies
            .Include(f => f.Actors)
            .FirstOrDefaultAsync(f => f.Id == movieId);
        if (movie == null)
        {
            throw new Exception($"Movie id - {movieId}, not found");
        }

        var actor = await _dbContext.Actors.FindAsync(actorId);
        if (actor == null)
        {
            throw new Exception($"Actor id - {actorId}, not found");
        }

        if (movie.Actors.Any(a => a.Id == actorId))
        {
            throw new Exception("This actor is already associated with the movie.");
        }

        movie.Actors.Add(actor);
        await _dbContext.SaveChangesAsync();
    }


    public async Task DeleteAsync(int id)
    {
        var movie = await _dbContext.Movies.FindAsync(id);
        if (movie != null)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}