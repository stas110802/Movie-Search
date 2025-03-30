namespace MovieSearch.MAUI.MVVM.Models;

public class Movie
{
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Poster { get; set; } = string.Empty;
    public List<Actor> Actors { get; set; } = [];

    public const int MaxDescriptionLength = 150;

    public string ShortDescription =>
        Description.Length > MaxDescriptionLength ? $"{Description[..MaxDescriptionLength]}..." : Description;
}