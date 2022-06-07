using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=HP-NOTE\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True");
        }
    }
}
