using Microsoft.EntityFrameworkCore;
using JwtAuthMvcApp.Models;
namespace JwtAuthMvcApp.DAO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
