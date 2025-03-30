using MovieSearch.MAUI.MVVM.ViewModels;

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

        var serviceProvider = services.BuildServiceProvider();
        MainPage = new NavigationPage(new MainPage(serviceProvider.GetService<MainPageViewModel>()));
    }
}