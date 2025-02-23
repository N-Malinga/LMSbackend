using LMS.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<BookDTO> AddBookAsync(BookDTO bookDTO);
        Task<int> GetBookCountAsync();
        Task<int> GetAuthorCountAsync();
        Task<bool> DeleteBookByIdAsync(int id);
        Task<bool> HardDeleteBookByIdAsync(int id);
    }
}
