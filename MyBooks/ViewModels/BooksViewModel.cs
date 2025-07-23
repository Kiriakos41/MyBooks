using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBooks.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace MyBooks.ViewModels;

public partial class BooksViewModel : ObservableObject
{
    private readonly HttpClient _httpClient = new();

    [ObservableProperty] ObservableCollection<Book> books = [];

    [ObservableProperty] bool isLoading;

    [ObservableProperty] string searchQuery;

    [ObservableProperty] ItemsLayout currentItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);

    [ObservableProperty] string layoutIcon = "grid_icon.png"; // Show list icon initially

    // Toggles between list and grid layout
    [RelayCommand]
    void ToggleLayout()
    {
        if (CurrentItemsLayout is LinearItemsLayout)
        {
            // Switch to grid layout
            CurrentItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical)
            {
                HorizontalItemSpacing = 10,
                VerticalItemSpacing = 10
            };

            LayoutIcon = "list_icon.png"; // Update icon to show grid
        }
        else
        {
            // Switch to vertical list
            CurrentItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 10
            };

            LayoutIcon = "grid_icon.png"; // Back to list icon
        }
    }

    // Loads books based on the search query
    [RelayCommand]
    async Task LoadBooksAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
            return;

        IsLoading = true;

        try
        {
            var url = $"https://gutendex.com/books/?search={Uri.EscapeDataString(SearchQuery)}";
            var response = await _httpClient.GetFromJsonAsync<GutendexResponse>(url);

            Books.Clear();
            var results = response?.Results ?? new List<Book>();

            foreach (var book in results)
                Books.Add(book);
        }
        catch (Exception ex)
        {
            // Show error to the user
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    async Task GoToDetails(Book book)
    {
        if (book == null)
            return;

        await Shell.Current.GoToAsync($"BookDetailsPage?bookId={book.Id}");

    }

}
