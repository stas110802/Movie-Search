namespace MovieSearch.Domain.Dtos;

public class MovieReadDto
{
    public MovieReadDto(string title, string genre, string description, string shortDescription, string posterUri, List<ActorReadDto> actors)
    {
        Title = title;
        Genre = genre;
        Description = description;
        ShortDescription = shortDescription;
        PosterUri = posterUri;
        Actors = actors;
    }

    public string Title { get; set; } 
    public string Genre { get; set; }
    public string Description { get; set; } 
    public string ShortDescription { get; set; } 
    public string PosterUri { get; set; }
    public List<ActorReadDto> Actors { get; set; }
}