using Microsoft.EntityFrameworkCore;
using myFirstAsp.Net.Models;
namespace myFirstAsp.Net.Data
{
    public class UsersContext:DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<Userss> Userss { get; set; }
    }
}
