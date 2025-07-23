namespace MyBooks.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Author> Authors { get; set; }

    // Υπολογιζόμενη ιδιότητα για το εξώφυλλο
    public string? CoverImage => $"https://www.gutenberg.org/cache/epub/{Id}/pg{Id}.cover.medium.jpg";
}
