using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Domain.Models.DTOs;
using LMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using LMS.Domain.Models;

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

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Where (book => book.id == id && !book.isDeleted)
                .Select(book => new BookDTO
                {
                    id = book.id,
                    title = book.title,
                    author = book.author,
                    description = book.description,
                    imgLink = book.imgLink,
                })
                .FirstOrDefaultAsync();

            return book;
        }

        public async Task<BookDTO> AddBookAsync(BookDTO bookDTO)
        {
            var book = new Book
            {
                title = bookDTO.title,
                author = bookDTO.author,
                description = bookDTO.description,
                imgLink = bookDTO.imgLink,
                isDeleted = false
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return new BookDTO
            {
                id = book.id,
                title = book.title,
                author = book.author,
                description = book.description,
                imgLink = book.imgLink
            };
        }

        public async Task<int> GetBookCountAsync()
        {
            return await _context.Books.CountAsync(book => !book.isDeleted);
        }

        public async Task<int> GetAuthorCountAsync()
        {
            return await _context.Books
                .Where(book => !book.isDeleted)
                .Select(book => book.author)
                .Distinct()
                .CountAsync();
        }

        public async Task<bool> DeleteBookByIdAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.id == id);
            if (book == null || book.isDeleted)
            {
                return false; // Book not found or already deleted
            }

            book.isDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HardDeleteBookByIdAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.id == id);
            if (book == null)
            {
                return false; // Book not found
            }

            _context.Books.Remove(book); // Hard delete
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
