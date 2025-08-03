using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyBooks.Navigation;
using MyBooks.Pages;
using MyBooks.ViewModels;

namespace MyBooks;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("mat.ttf", "mat");
                fonts.AddFont("mat_fill.ttf", "matf");
            });

        builder.Services.AddTransientWithShellRoute<MainPage, BooksViewModel>(nameof(MainPage));
        builder.Services.AddTransientWithShellRoute<SettingsPage, SettingsPageViewModel>(nameof(SettingsPage));
        builder.Services.AddTransientWithShellRoute<BookDetailsPage, BookDetailsViewModel>(nameof(BookDetailsPage));
        builder.Services.AddTransient<INavigationService, NavigationService>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
