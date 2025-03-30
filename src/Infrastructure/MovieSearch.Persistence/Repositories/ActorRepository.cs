using Microsoft.EntityFrameworkCore;
using MovieSearch.Domain.Entities;
using MovieSearch.Domain.Repositories;
using MovieSearch.Persistence.Data;

namespace MovieSearch.Persistence.Repositories;

public sealed class ActorRepository : IActorRepository
{
    private readonly MovieSearchDbContext _dbContext;

    public ActorRepository(MovieSearchDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Actor>> GetAllAsync()
    {
        return await _dbContext
            .Actors
            .Include(m => m.Movies)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Actor actor)
    {
        await _dbContext.Actors.AddAsync(actor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var actor = await _dbContext.Actors.FindAsync(id);
        if (actor != null)
        {
            _dbContext.Actors.Remove(actor);
            await _dbContext.SaveChangesAsync();
        }
    }
}