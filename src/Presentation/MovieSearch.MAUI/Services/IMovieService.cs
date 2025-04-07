using MovieSearch.MAUI.MVVM.Models;
using MovieSearch.MAUI.Types;

namespace MovieSearch.MAUI.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> SearchMoviesAsync(SearchType searchType, string query);
}