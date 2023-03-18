using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BooksAPI.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }
        public DbSet<Books> Books { get; set; }
    }
}
