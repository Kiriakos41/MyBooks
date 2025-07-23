using MyBooks.ViewModels;

namespace MyBooks;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new BooksViewModel();
    }

}
