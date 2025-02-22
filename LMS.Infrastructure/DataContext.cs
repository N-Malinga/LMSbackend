using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMS.Domain.Models;

namespace LMS.Infrastructure
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString;

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var _connectionString = "C:\\sqlite.db";
            optionsBuilder.UseSqlite(_connectionString);
        }

        public DbSet<Book> Books { get; set; }
    }
}
