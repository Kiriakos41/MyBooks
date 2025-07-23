using MyBooks.ViewModels;

namespace MyBooks.Pages;

public partial class BookDetailsPage : ContentPage
{
    public BookDetailsPage(BookDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}