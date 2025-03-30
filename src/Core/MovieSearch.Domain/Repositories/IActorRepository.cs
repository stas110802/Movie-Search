using MovieSearch.Domain.Entities;

namespace MovieSearch.Domain.Repositories;

public interface IActorRepository
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task AddAsync(Actor actor);
    Task DeleteAsync(int id);
}