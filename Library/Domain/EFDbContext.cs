using System.Data.Entity;
using Domain.Entities;

namespace Domain
{
    public class EFDbContext:DbContext
    {
        public EFDbContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<User> Users { get; set;}
        public DbSet<Order> Orders { get; set;}
        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set;}
    }
}
