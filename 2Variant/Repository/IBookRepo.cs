using _2Variant.DataAccess.Entity;

namespace _2Variant.Repository;

public interface IBookRepo
{
    Book AddBook(Book obj);
    void DeleteBook(Guid id);
    void UpdateBook(Book obj);
    Book GetById(Guid id);
    List<Book> GetAllBooks();
}