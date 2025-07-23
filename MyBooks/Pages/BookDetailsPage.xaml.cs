using MyBooks.ViewModels;

namespace MyBooks.Pages;

public partial class BookDetailsPage : ContentPage
{
    private readonly BookDetailsViewModel _viewModel;

    public BookDetailsPage()
    {
        InitializeComponent();
        BindingContext = _viewModel = new BookDetailsViewModel();
    }
}