using MovieSearch.MAUI.MVVM.Models;
using MovieSearch.MAUI.Types;
using Newtonsoft.Json;

namespace MovieSearch.MAUI.Services;

public sealed class MovieService : IMovieService
{
    private readonly HttpClient _client;

    public MovieService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Movie>> SearchMoviesAsync(SearchType searchType, string query)
    {
        var filter = GetFilter(searchType);
        var request = $"http://localhost:5000/Movies/{filter}/{query}";

        var response = await _client.GetAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<IEnumerable<Movie>>(content) ?? [];
    }

    private char GetFilter(SearchType searchType)
    {
        return searchType switch
        {
            SearchType.Genre => 'g',
            SearchType.Actor => 'a',
            _ => 't'
        };
    }
}