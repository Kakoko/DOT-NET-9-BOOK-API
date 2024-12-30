using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Dystopian" },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Classic" },
                new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic" },
                new Book { Id = 4, Title = "Moby Dick", Author = "Herman Melville", Genre = "Adventure" },
                new Book { Id = 5, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance" }
            );
        }
    }
}
