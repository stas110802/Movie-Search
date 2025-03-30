using MovieSearch.Infrastructure.Common;
using RestSharp;

namespace MovieSearch.Infrastructure.Options;

public class RequestOptions
{
    public required RestRequest Request { get; set; }
    public BaseEndpoint? Endpoint { get; set; }
    public string? FullPath { get; set; }
}