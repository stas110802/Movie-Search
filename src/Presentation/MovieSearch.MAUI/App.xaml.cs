﻿using MovieSearch.MAUI.MVVM.ViewModels;
using MovieSearch.MAUI.Services;

namespace MovieSearch.MAUI;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App()
    {
        InitializeComponent();
        var services = new ServiceCollection();
        services.AddHttpClient();
        services.AddTransient<MainPageViewModel>();
        services.AddTransient<MoviePageDetailViewModel>();
        services.AddScoped<IMovieService, MovieService>();

        var serviceProvider = services.BuildServiceProvider();
        MainPage = new NavigationPage(new MainPage(serviceProvider.GetService<MainPageViewModel>()));
    }
}