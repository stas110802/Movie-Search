using MovieSearch.Domain.Entities;

namespace MovieSearch.Domain.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<IEnumerable<Movie>> GetByTitleAsync(string title, int ratio = 75);
    Task<IEnumerable<Movie>> GetByGenreAsync(string title, int ratio = 75);
    Task<IEnumerable<Movie>> GetByActorAsync(string title, int ratio = 75);
    Task AddAsync(Movie movie);
    Task AddActorToMovieAsync(int movieId, int actorId);
    Task DeleteAsync(int id);
}