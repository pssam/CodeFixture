using System.Linq;
using CodeFixtureTests.Models;

namespace CodeFixtureTests.Filters
{
    public class UserFilter:FilterBase<User>
    {
        public IQueryable<User> Filter(IQueryable<User> all, UserFilterOptions by)
        {
            Result = all;
            FilterContains(user => user.Name, by.Name);
            return Result;
        }
    }
}