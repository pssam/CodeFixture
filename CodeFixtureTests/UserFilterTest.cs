using System.Linq;
using CodeFixtureTests.Filters;
using CodeFixtureTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFixtureTests
{
    [TestClass]
    public class UserFilterTest
    {
        [TestMethod]
        public void TestFilter_ByName()
        {
            var users = new[] {new User {Name = "test1"}, new User {Name = "test2"}, new User {Name = "test3"},}.AsQueryable();
            var filter = new UserFilter();
            var filteredUsers = filter.Filter(users, new UserFilterOptions {Name = "2"}).ToArray();
            Assert.AreEqual(1, filteredUsers.Length);
            Assert.AreEqual("test2", filteredUsers.Single().Name);
        }
    }
}