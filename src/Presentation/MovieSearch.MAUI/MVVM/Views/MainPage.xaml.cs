using MovieSearch.MAUI.MVVM.Models;
using MovieSearch.MAUI.MVVM.ViewModels;
using MovieSearch.MAUI.MVVM.Views;

namespace MovieSearch.MAUI;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;
    
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    
    private async void OnMovieTapped(object sender, SelectionChangedEventArgs  e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Movie selectedMovie)
        {
            var detailViewModel = new MoviePageDetailViewModel(selectedMovie);
            await Navigation.PushAsync(new MovieDetailPage(detailViewModel));
        }
        ((CollectionView)sender).SelectedItem = null;
    }
}