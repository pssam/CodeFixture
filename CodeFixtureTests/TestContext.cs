using System.Data.Entity;
using CodeFixtureTests.Models;

namespace CodeFixtureTests
{
    public class TestContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}