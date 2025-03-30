using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Entities;

namespace MovieSearch.Domain;

public interface IRestMovieClient
{
    Task<IEnumerable<MovieApiDto>> GetMoviesByNameAsync(string title);
}