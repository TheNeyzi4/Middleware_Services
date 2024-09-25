using Middleware_Services.Interfaces;
using Middleware_Services.Models;

namespace Middleware_Services.Services
{
    public class BookService : IBookService
    {
        // Створення типу "бази даних"
        public static List<Book> Books = new List<Book>()
        {
            new Book { Id = 1, Title = "JavaScript", Author = "Haizenberg", Year = 2000 },
            new Book { Id = 2, Title = "C#", Author = "Packt", Year = 2012 },
            new Book { Id = 3, Title = "Python", Author = "Zmeyikin", Year = 2000 },
        };

        // Добавлення книги
        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        // Видалення книги
        public void DeleteBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book is not null)
            {
                Books.Remove(book);
            }
        }

        // Отримання книги
        public IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }

        // Отримання книги по Id
        public Book GetBookById(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        // Обновлення книги
        public void UpdateBook(Book book)
        {
            var currentBook = Books.FirstOrDefault(b => b.Id == book.Id);
            if (currentBook is not null)
            {
                currentBook.Title = book.Title;
                currentBook.Author = book.Author;
                currentBook.Year = book.Year;
            }
        }
    }
}
