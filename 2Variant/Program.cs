using _2Variant.Service;
using _2Variant.Service.DTOs;

namespace _2Variant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBookService service = new BookService();
            var obj = new BookGetDto();
            obj.Title = "Salom";
            service.AddBook(obj);


        }
    }
}
