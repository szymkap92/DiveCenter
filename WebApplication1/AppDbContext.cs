using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace DiveCenter
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Konstruktor domyślny, do wykorzystania w specjalnych sytuacjach
        public AppDbContext() { }

        public DbSet<User> Users { get; set; }
    }
}
