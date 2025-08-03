using MyBooks.ViewModels;

namespace MyBooks.Pages;

public partial class MainPage : ContentPage
{
    private readonly BooksViewModel view;

    public MainPage(BooksViewModel vm)
    {
        InitializeComponent();
        BindingContext = view = vm;
    }
}
