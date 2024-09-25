using Microsoft.AspNetCore.Mvc;
using Middleware_Services.Interfaces;
using Middleware_Services.Models;

namespace Middleware_Services.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService? _bookService;

        public BooksController(IBookService? bookService)
        {
            _bookService = bookService;
        }

        // Get запит где отримуються всі книги, а потім метод віддає книги в json'і
        [HttpGet]
        public JsonResult Get()
        {
            var request = HttpContext.Request;
            var books = _bookService?.GetAllBooks();
            return Json(books);
        }

        // Запит на отримання книги по айді
        [HttpGet("search/{id}")]
        public JsonResult GetBookById(int id)
        {
            var book = _bookService?.GetBookById(id);
            if (book != null)
            {
                return Json(book);
            }
            return Json(new { message = "Book not found" });
        }

        // Запит на добавлення книги
        [HttpPost]
        public JsonResult AddBook(Book book)
        {
            _bookService?.AddBook(book);
            return Json(new { message = $"Book added: {book.Title}" });
        }

        // Запит на видалення книги по айді
        [HttpDelete("{id}")]
        public JsonResult DeleteBook(int id)
        {
            var book = _bookService?.GetBookById(id);
            if (book != null)
            {
                _bookService?.DeleteBook(id);
                return Json(new { message = $"Book deleted: {book.Title}" });
            }
            return Json(new { message = "Book not found!" });
        }

        // Запит на обновлення книги
        [HttpPut("{id}")]
        public JsonResult UpdateBook(int id, [FromBody] Book book)
        {
            var existingBook = _bookService?.GetBookById(id);
            if (existingBook != null)
            {
                book.Id = id;
                _bookService?.UpdateBook(book);
                return Json(new { message = $"Book updated: {book.Title}" });
            }
            return Json(new { message = "Book not found" });
        }
    }
}
