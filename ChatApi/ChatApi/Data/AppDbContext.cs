using ChatApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> messages { get; set; }
    }
}