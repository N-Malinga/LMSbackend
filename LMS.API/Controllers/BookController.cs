using LMS.Application.Services;
using LMS.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using LMS.Domain.Models.DTOs;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //[HttpPost]
        //public async Task<ActionResult<List<Book>>> AddBooks(Book book)
        //{
        //    _bookService.Books.Add(book);
        //    await _bookService.SaveChangesAsync();

        //    return Ok(await _bookService.Books.ToListAsync());
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("id")]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) {
                return NotFound($"Book with ID {id} not found.");
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook([FromBody] BookDTO bookDTO)
        {
            if(bookDTO == null)
            {
                return BadRequest("Book data is required");
            }

            var createdBook = await _bookService.AddBookAsync(bookDTO);
            return CreatedAtAction(nameof(GetBooks), new { id = createdBook.id }, createdBook);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetBookCount()
        {
            var count = await _bookService.GetBookCountAsync();
            return Ok(count);
        }

        [HttpGet("author-count")]
        public async Task<ActionResult<int>> GetAuthorCount()
        {
            var authorCount = await _bookService.GetAuthorCountAsync();
            return Ok(authorCount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deleted = await _bookService.DeleteBookByIdAsync(id);
            if (!deleted)
            {
                return NotFound($"Book with ID {id} not found or already deleted.");
            }
            return NoContent();
        }

        [HttpDelete("hard-delete/{id}")]
        public async Task<IActionResult> HardDeleteBook(int id)
        {
            var deleted = await _bookService.HardDeleteBookByIdAsync(id);
            if (!deleted)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Book data is required.");
            }

            var updatedBook = await _bookService.UpdateBookAsync(id, bookDto);
            if (updatedBook == null)
            {
                return NotFound($"Book with ID {id} not found or deleted.");
            }

            return Ok(updatedBook);
        }
    }
}
