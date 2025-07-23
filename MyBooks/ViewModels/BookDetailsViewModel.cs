using CommunityToolkit.Mvvm.ComponentModel;
using MyBooks.Models;
using System.Net.Http.Json;

namespace MyBooks.ViewModels;

// This attribute enables passing the "bookId" parameter via Shell navigation query
[QueryProperty(nameof(BookId), "bookId")]
public partial class BookDetailsViewModel : ObservableObject
{
    private readonly HttpClient _httpClient = new();

    // The ID of the book to load
    [ObservableProperty]
    private int bookId;

    // The book details loaded from the API
    [ObservableProperty]
    private Book book = new();

    // Called automatically when BookId changes; triggers loading of book details
    partial void OnBookIdChanged(int value)
    {
        LoadBook(value);
    }

    // Loads book details asynchronously from the API by book ID
    private async void LoadBook(int id)
    {
        try
        {
            var url = $"https://gutendex.com/books/{id}";
            Book = await _httpClient.GetFromJsonAsync<Book>(url);
            OnPropertyChanged(nameof(Book));
        }
        catch (Exception ex)
        {
            // Show an error alert if loading fails
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
