using MyBooks.ViewModels;

namespace MyBooks.Templates;
public class BookTemplateSelector : DataTemplateSelector
{
    public DataTemplate ListTemplate { get; set; }
    public DataTemplate GridTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var cv = (CollectionView)container;
        var vm = (BooksViewModel)cv.BindingContext;

        if (vm.CurrentItemsLayout is GridItemsLayout)
            return GridTemplate;

        return ListTemplate;
    }
}