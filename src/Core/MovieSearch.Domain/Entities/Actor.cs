namespace MovieSearch.Domain.Entities;

public sealed class Actor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Movie> Movies { get; set; } = [];
}