using _2Variant.DataAccess.Entity;
using _2Variant.Repository;
using _2Variant.Service.DTOs;

namespace _2Variant.Service;

public class BookService : IBookService
{
    private readonly IBookRepo books;
    public BookService()
    {
        books = new BookRepo();
    }
    private Book ConvertToEntity(BookBaseDto obj)
    {
        return new Book()
        {
            Title = obj.Title,
            Pages = obj.Pages,
            Rating = obj.Rating,
            Author = obj.Author,
            PublishedDate = DateTime.Now,
            NumberOfCopiesSold = obj.NumberOfCopiesSold,
        };
    }
    private BookGetDto ConvertToDto(Book obj)
    {
        return new BookGetDto()
        {
            Id = obj.Id,
            Title = obj.Title,
            Pages = obj.Pages,
            Rating = obj.Rating,
            Author = obj.Author,
            PublishedDate = DateTime.Now,
            NumberOfCopiesSold = obj.NumberOfCopiesSold,
        };
    }
    public Book AddBook(BookBaseDto obj)
    {

        var convert = ConvertToEntity(obj);
        convert.Id = Guid.NewGuid();
        books.AddBook(convert);
        return convert;
    }

    public void DeleteBook(BookGetDto obj)
    {
        books.DeleteBook(obj.Id);
    }

    public List<BookGetDto> GetAllBook()
    {
        var list = new List<BookGetDto>();
        var bookGetDto = books.GetAllBooks();
        foreach (var book in bookGetDto)
        {
            var convert = ConvertToDto(book);
            list.Add(convert);
        }
        return list;
    }

    public List<BookGetDto> GetAllBooksByAuthor(string author)
    {
        var list = new List<BookGetDto>();
        var byAuthor = books.GetAllBooks();
        foreach (var book in byAuthor)
        {
            if (book.Author == author)
            {
                var convert = ConvertToDto(book);
                list.Add(convert);
            }
        }
        return list;
    }

    public List<BookGetDto> GetBooksPublishedAfterYear(int year)
    {
        var list = new List<BookGetDto>();
        var afterYear = books.GetAllBooks();
        foreach (var book in afterYear)
        {
            if (book.PublishedDate.Year > year)
            {
                var convert = ConvertToDto(book);
                list.Add(convert);
            }
        }
        return list;
    }

    public List<BookGetDto> GetBooksSortedByRating()
    {
        var list = new List<BookGetDto>();
        var sort = books.GetAllBooks();
        sort.Sort((book1, book2) => book2.Rating.CompareTo(book1.Rating));
        foreach (var book in sort)
        {
            var convert = ConvertToDto(book);
            list.Add(convert);
        }
        return list;
    }

    public List<BookGetDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
        var list = new List<BookGetDto>();
        var range = books.GetAllBooks();
        foreach (var book in range)
        {
            if (book.Pages >= minPages && book.Pages <= maxPages)
            {
                var convert = ConvertToDto(book);
                list.Add(convert);
            }
        }
        return list;
    }

    public BookGetDto GetMostPopularBook()
    {
        var popular = GetAllBook();
        var bookGetDto = new BookGetDto();
        foreach (var book in popular)
        {
            if (book.NumberOfCopiesSold > bookGetDto.NumberOfCopiesSold)
            {
                bookGetDto.NumberOfCopiesSold = book.NumberOfCopiesSold;
            }
        }
        return bookGetDto;
    }

    public List<BookGetDto> GetRecentBooks(int years)
    {
        var list = new List<BookGetDto>();
        var recentBook = books.GetAllBooks();
        foreach (var book in recentBook)
        {
            if (book.PublishedDate.Year > years)
            {
                var convert = ConvertToDto(book);
                list.Add(convert);
            }
        }
        return list;
    }

    public BookGetDto GetTopRatedBook()
    {
        var bookGetDto = new BookGetDto();
        var top = books.GetAllBooks();
        foreach (var book in top)
        {
            if (book.Rating > bookGetDto.Rating)
            {
                bookGetDto.Rating = book.Rating;

            }
        }
        return bookGetDto;
    }

    public int GetTotalCopiesSoldByAuthor(string author)
    {
        var soldByAuthor = books.GetAllBooks();
        var total = 0;
        foreach (var book in soldByAuthor)
        {
            if (book.Author == author)
            {
                total += book.NumberOfCopiesSold;
            }
        }
        return total;
    }

    public List<BookGetDto> SearchBooksByTitle(string keyword)
    {
        var list = new List<BookGetDto>();
        var search = books.GetAllBooks();
        foreach (var book in search)
        {
            if (book.Title.StartsWith(keyword))
            {
                var convert = ConvertToDto(book);
                list.Add(convert);
            }
        }
        return list;
    }

    public void UpdateBook(BookGetDto obj)
    {
        var convert = ConvertToEntity(obj);
        books.UpdateBook(convert);
    }
}
