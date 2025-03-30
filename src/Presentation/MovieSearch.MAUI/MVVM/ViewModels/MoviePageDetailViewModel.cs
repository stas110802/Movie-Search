using MovieSearch.MAUI.MVVM.Models;

namespace MovieSearch.MAUI.MVVM.ViewModels;

public class MoviePageDetailViewModel
{
    public Movie Movie { get; set; }

    public MoviePageDetailViewModel(Movie movie)
    {
        Movie = movie;
    }
}