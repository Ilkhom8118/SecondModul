using _2Variant.DataAccess.Entity;
using _2Variant.Service.DTOs;

namespace _2Variant.Service;

public interface IBookService
{
    Book AddBook(BookBaseDto obj);
    void DeleteBook(BookGetDto obj);
    void UpdateBook(BookGetDto obj);
    List<BookGetDto> GetAllBook();
    List<BookGetDto> GetAllBooksByAuthor(string author);

    BookGetDto GetTopRatedBook();

    List<BookGetDto> GetBooksPublishedAfterYear(int year);

    BookGetDto GetMostPopularBook();

    List<BookGetDto> SearchBooksByTitle(string keyword);

    List<BookGetDto> GetBooksWithinPageRange(int minPages, int maxPages);

    int GetTotalCopiesSoldByAuthor(string author);

    List<BookGetDto> GetBooksSortedByRating();

    List<BookGetDto> GetRecentBooks(int years);
}

//List<BookDto> GetAllBooksByAuthor(string author);

//BookDto GetTopRatedBook();

//List<BookDto> GetBooksPublishedAfterYear(int year);

//BookDto GetMostPopularBook();

//List<BookDto> SearchBooksByTitle(string keyword);

//List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages);

//int GetTotalCopiesSoldByAuthor(string author);

//List<BookDto> GetBooksSortedByRating();

//List<BookDto> GetRecentBooks(int years);