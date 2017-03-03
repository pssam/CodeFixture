using System.Linq;
using CodeFixtureTests.Filters;
using CodeFixtureTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFixtureTests
{
    [TestClass]
    public class ProductFilterTest
    {
        [TestMethod]
        public void TestFilter_ByName()
        {
            var products = new[] {new Product {Name = "test1"}, new Product {Name = "test2"}, }.AsQueryable();
            var filter = new ProductFilter();
            var filteredUsers = filter.Filter(products, new ProductFilterOptions {Name = "2"}).ToArray();
            Assert.AreEqual(1, filteredUsers.Length);
            Assert.AreEqual("test2", filteredUsers.Single().Name);
        }

        [TestMethod]
        public void TestFilter_ByDescription()
        {
            var products =
                new[] {new Product {Description = "test1"}, new Product {Description = "test2"},}.AsQueryable();
            var filter = new ProductFilter();
            var filteredUsers = filter.Filter(products, new ProductFilterOptions {Description = "2"}).ToArray();
            Assert.AreEqual(1, filteredUsers.Length);
            Assert.AreEqual("test2", filteredUsers.Single().Description);
        }
    }
}