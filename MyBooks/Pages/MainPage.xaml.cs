using MyBooks.ViewModels;

namespace MyBooks.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(BooksViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

}
