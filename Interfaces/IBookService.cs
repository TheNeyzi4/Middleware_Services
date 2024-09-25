using Middleware_Services.Models;

namespace Middleware_Services.Interfaces
{
    // Интерфейс IBookService
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookById(int id);
        public void AddBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int id);
    }
}
