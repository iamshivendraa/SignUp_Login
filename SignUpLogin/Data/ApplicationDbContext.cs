using Microsoft.EntityFrameworkCore;
using SignUpLogin.Models;

namespace SignUpLogin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SignUpModel> Accounts {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SignUpModel>().HasQueryFilter(e => !e.IsDeleted);
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
