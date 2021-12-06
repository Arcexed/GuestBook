using GuestBook.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.Migrations
{
    public class GuestBookDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public GuestBookDbContext(DbContextOptions<GuestBookDbContext> options) : base(options)
        {
            
        }
    }
}