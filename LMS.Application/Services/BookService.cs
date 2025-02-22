using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Domain.Models.DTOs;
using LMS.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LMS.Application.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            return await _context.Books
                .Where(books => !books.isDeleted)
                .Select(book => new BookDTO
                {
                    id = book.id,
                    title = book.title,
                    author = book.author,
                    description = book.description,
                    imgLink = book.imgLink,
                })
                .ToListAsync();
        }
    }
}
