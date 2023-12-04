using Microsoft.EntityFrameworkCore;
namespace Test.API
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public UserContext(DbContextOptions<UserContext> options)
        : base(options)
        {
           
        }
    }
}
