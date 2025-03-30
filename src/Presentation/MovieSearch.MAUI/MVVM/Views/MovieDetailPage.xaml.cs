using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSearch.MAUI.MVVM.ViewModels;

namespace MovieSearch.MAUI.MVVM.Views;

public partial class MovieDetailPage : ContentPage
{
    public MovieDetailPage(MoviePageDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}