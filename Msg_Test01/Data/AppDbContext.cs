using Microsoft.EntityFrameworkCore;
using Msg_Test01.Models;
namespace Msg_Test01.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext):base(dbContext)
        {

        }

        public DbSet<Message> Messages { get; set; } = null!;
    }
}
