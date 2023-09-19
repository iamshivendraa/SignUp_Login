using Microsoft.EntityFrameworkCore;
using SignUpLogin.Models;

namespace SignUpLogin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SignUpModel> Accounts {  get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
