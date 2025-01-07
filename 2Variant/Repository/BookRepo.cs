using _2Variant.DataAccess.Entity;
using System.Text.Json;

namespace _2Variant.Repository;

public class BookRepo : IBookRepo
{
    private string Path;
    private List<Book> books;
    public BookRepo()
    {
        books = new List<Book>();
        Path = "../../../DataAccess/Data/Book.json";
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }


    }
    private void SaveInformation(List<Book> obj)
    {
        var json = JsonSerializer.Serialize(obj);
        File.WriteAllText(Path, json);
    }
    private List<Book> GetByAllBooks()
    {
        var json = File.ReadAllText(Path);
        var file = JsonSerializer.Deserialize<List<Book>>(json);
        return file;
    }
    public Book AddBook(Book obj)
    {
        books.Add(obj);
        SaveInformation(books);
        return obj;
    }

    public void DeleteBook(Guid id)
    {
        var guId = GetById(id);
        books.Remove(guId);
        SaveInformation(books);
    }

    public List<Book> GetAllBooks()
    {
        return GetByAllBooks();
    }

    public Book GetById(Guid id)
    {
        foreach (var book in books)
        {
            if (book.Id == id)
            {
                return book;
            }
        }
        throw new Exception("Not Find");
    }

    public void UpdateBook(Book obj)
    {
        var id = GetById(obj.Id);
        books[books.IndexOf(id)] = obj;
        SaveInformation(books);
    }
}
