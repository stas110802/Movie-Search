using MovieSearch.Domain;
using MovieSearch.Domain.Dtos;
using MovieSearch.Infrastructure.Common;
using MovieSearch.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MovieSearch.Infrastructure.Clients;

public class OmDbClient : IRestMovieClient
{
    private readonly BaseRestApi<BaseRequest> _restApi;
    private readonly MovieApiOptions _options;
    private readonly string[] _randomGenres;

    public OmDbClient(IOptions<MovieApiOptions> options)
    {
        _options = options.Value;
        _restApi = new BaseRestApi<BaseRequest>(_options);

        _randomGenres =
        [
            "Comedy, Fantasy",
            "Drama, Fantasy",
            "Horror, Fantasy, Triller",
            "Comedy, Action",
            "Romance, Drama",
            "Triller, Mystery"
        ];
    }

    public async Task<IEnumerable<MovieApiDto>> GetMoviesByNameAsync(string title)
    {
        var result = new List<MovieApiDto>();
        var query = $"?apikey={_options.PublicKey}&s={title}";

        var response = await _restApi
            .CreateRequest(Method.Get, null, query)
            .ExecuteAsync();

        var searchMovies = JsonConvert.DeserializeObject<JToken>(response)?["Search"];
        foreach (var movie in searchMovies)
        {
            var info = JsonConvert.DeserializeObject<MovieApiDto>(movie.ToString());
            info.Description =
                "The Imperial Forces, under orders from cruel Darth Vader, hold Princess Leia hostage in their efforts to quell the rebellion against" +
                " the Galactic Empire. Luke Skywalker and Han Solo, captain of the Millennium Falcon, work together with the companionable droid" +
                " duo R2-D2 and C-3PO to rescue the beautiful princess, help the Rebel Alliance and restore freedom and justice to the Galaxy.";
            info.Genre = GetRandomGenre();
            if (info.Poster == "N/A")
                info.Poster = "https://i.pinimg.com/736x/f1/aa/67/f1aa675a902fcb7773a8ed64066a63fa.jpg";
            result.Add(info);
        }

        return result;
    }

    private string GetRandomGenre()
    {
        var random = new Random();
        var item = _randomGenres[random.Next(_randomGenres.Length)];

        return item;
    }
}