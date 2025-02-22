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
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var _connectionString = "Data Source = sqlite.db";
                optionsBuilder.UseSqlite(_connectionString);
            }
        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
