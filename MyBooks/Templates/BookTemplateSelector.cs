using MyBooks.ViewModels;

namespace MyBooks.Templates;
public class BookTemplateSelector : DataTemplateSelector
{
    public DataTemplate ListTemplate { get; set; }
    public DataTemplate GridTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        // Υποθέτουμε ότι το BindingContext του CollectionView είναι το ViewModel
        var cv = (CollectionView)container;
        var vm = (BooksViewModel)cv.BindingContext;

        // Όταν είμαστε σε grid layout, επέλεξε το grid template
        if (vm.CurrentItemsLayout is GridItemsLayout)
            return GridTemplate;

        // Διαφορετικά, επέλεξε το list template
        return ListTemplate;
    }
}