using MovieSearch.Domain.Entities;

namespace MovieSearch.Domain.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<IEnumerable<Movie>> GetByTitleAsync(string title);
    Task<IEnumerable<Movie>> GetByGenreAsync(string title);
    Task<IEnumerable<Movie>> GetByActorAsync(string title);
    Task AddAsync(Movie movie);
    Task AddActorToMovieAsync(int movieId, int actorId);
    Task DeleteAsync(int id);
}