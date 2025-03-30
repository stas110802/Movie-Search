using System.Text.Json.Serialization;

namespace MovieSearch.Domain.Dtos;

public class MovieApiDto
{
    public string Title { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Poster { get; set; } = string.Empty;
    
    [JsonIgnore]
    public string Genre { get; set; } = string.Empty;
    
    [JsonIgnore]
    public string Description { get; set; } = string.Empty;
}