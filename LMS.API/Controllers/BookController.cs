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
    }
}
