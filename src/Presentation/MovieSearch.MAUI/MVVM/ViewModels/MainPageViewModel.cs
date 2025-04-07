using System.Collections.ObjectModel;
using System.Windows.Input;
using MovieSearch.MAUI.MVVM.Models;
using MovieSearch.MAUI.Services;
using MovieSearch.MAUI.Types;

namespace MovieSearch.MAUI.MVVM.ViewModels;

public class MainPageViewModel : NotifyPropertyChangedBase
{
    private readonly IMovieService _movieService;
    private string? _searchQuery;
    private SearchType _selectedAttribute;
    private ObservableCollection<Movie> _movies;

    public MainPageViewModel(IMovieService service)
    {
        _movieService = service;
        _selectedAttribute = SearchType.Title;
        _movies = new ObservableCollection<Movie>();

        async void Execute() => await SearchMovies();
        SearchCommand = new Command(Execute);
    }

    public SearchType SelectedAttribute
    {
        get => _selectedAttribute;
        set => SetField(ref _selectedAttribute, value);
    }

    public string? SearchQuery
    {
        get => _searchQuery;
        set => SetField(ref _searchQuery, value);
    }

    public ObservableCollection<Movie> Movies
    {
        get => _movies;
        set => SetField(ref _movies, value);
    }

    public ICommand SearchCommand { get; }

    private async Task SearchMovies()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            Movies.Clear();

            return;
        }

        try
        {
            var movies = await _movieService.SearchMoviesAsync(SelectedAttribute, SearchQuery);
            Movies.Clear();
            foreach (var movie in movies)
            {
                Movies.Add(movie);
            }
        }
        catch (Exception error)
        {
            await Application.Current.MainPage.DisplayAlert($"Error",
                $"Can not get movies from API...\n{error.Message}", "Ok");
        }
    }
}