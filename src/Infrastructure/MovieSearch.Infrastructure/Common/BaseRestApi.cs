using MovieSearch.Infrastructure.Options;
using RestSharp;

namespace MovieSearch.Infrastructure.Common;

public sealed class BaseRestApi<T>
    where T : BaseRequest, new()
{
    public BaseRestApi(MovieApiOptions movieApiOptions)
    {
        MovieApiOptions = movieApiOptions;
    } 

    public MovieApiOptions MovieApiOptions { get; set; }
        
    public T CreateRequest(Method method, BaseEndpoint? endpoint = null,
        string? query = null)
    {
        var full = endpoint?.Value + query;
        var result = new T
        {
            Client = new RestClient(MovieApiOptions.BaseUri),
            RequestOptions = new RequestOptions
            {
                FullPath = full,
                Endpoint = endpoint,
                Request = new RestRequest(full)
                {
                    Method = method
                }
            }
        };

        return result;
    }
}