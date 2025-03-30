using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MovieSearch.MAUI.MVVM.Models;
using MovieSearch.MAUI.Types;
using Newtonsoft.Json;

namespace MovieSearch.MAUI.MVVM.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private readonly HttpClient _client;
    private string _searchQuery;
    private SearchType _selectedAttribute;
    private ObservableCollection<Movie> _movies;

    public MainPageViewModel(HttpClient client)
    {
        SelectedAttribute = SearchType.Title;
        _client = client;
        Movies = new ObservableCollection<Movie>();

        async void Execute() => await SearchMovies();
        SearchCommand = new Command(Execute);
    }

    public SearchType SelectedAttribute
    {
        get => _selectedAttribute;
        set
        {
            _selectedAttribute = value;
            OnPropertyChanged();
        }
    }

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Movie> Movies
    {
        get => _movies;
        set
        {
            _movies = value;
            OnPropertyChanged();
        }
    }

    public ICommand SearchCommand { get; }

    private async Task SearchMovies()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            Movies.Clear();

            return;
        }

        var filter = GetFilter();
        var request = $"http://localhost:5000/Movies/{filter}/{SearchQuery}";

        try
        {
            var response = await _client.GetAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(content);

            if (movies == null)
            {
                return;
            }

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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private char GetFilter()
    {
        if (SelectedAttribute == SearchType.Genre)
            return 'g';
        if (SelectedAttribute == SearchType.Actor)
            return 'a';

        return 't';
    }
}