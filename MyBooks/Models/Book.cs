using System.Text.Json.Serialization;

namespace MyBooks.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Author> Authors { get; set; }

    public List<string> Subjects { get; set; } = new();
    public List<string> Bookshelves { get; set; } = new();

    [JsonPropertyName("download_count")]
    public int DownloadCount { get; set; }

    public string? CoverImage => $"https://www.gutenberg.org/cache/epub/{Id}/pg{Id}.cover.medium.jpg";

    public string AuthorsString => Authors != null && Authors.Count > 0
        ? string.Join(", ", Authors.Select(a => a.Name))
        : "Unknown Author";

    public string SubjectsString => Subjects != null && Subjects.Count > 0
        ? string.Join(", ", Subjects)
        : "No subjects";

    public string BookshelvesString => Bookshelves != null && Bookshelves.Count > 0
        ? string.Join(", ", Bookshelves)
        : "No bookshelves";
}
