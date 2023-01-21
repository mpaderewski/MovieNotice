using Microsoft.EntityFrameworkCore;
using MovieNotice.API.Settings;

namespace MovieNotice.API.Entities
{
    public class MovieNoticeDbContext : DbContext
    {
        private readonly ConnectionStringsSettings _connectionStrings;

        public DbSet<User> Users { get; set; }

        public MovieNoticeDbContext(ConnectionStringsSettings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(r => r.Email)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStrings.SqlServer);
        }
    }
}
