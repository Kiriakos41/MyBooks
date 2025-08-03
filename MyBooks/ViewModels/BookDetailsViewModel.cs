using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBooks.Models;
using System.Net.Http.Json;

namespace MyBooks.ViewModels;

// This attribute enables passing the "bookId" parameter via Shell navigation query
[QueryProperty(nameof(BookId), "bookId")]
public partial class BookDetailsViewModel : ObservableObject
{
    private readonly HttpClient _httpClient = new();

    [ObservableProperty]
    private bool isLiked;

    public string IconGlyph => "\uE87D";

    [ObservableProperty]
    private string iconFont = "mat";

    [ObservableProperty]
    private int bookId;

    [ObservableProperty]
    private Book book = new();

    partial void OnBookIdChanged(int value)
    {
        LoadBook(value);
    }


    [RelayCommand]
    private async Task ToggleLike()
    {
        IsLiked = !IsLiked;

        IconFont = IsLiked ? "matf" : "mat";
    }

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
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
