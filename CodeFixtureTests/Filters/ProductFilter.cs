using System.Linq;
using CodeFixtureTests.Models;

namespace CodeFixtureTests.Filters
{
    public class ProductFilter : FilterBase<Product>
    {
        public IQueryable<Product> Filter(IQueryable<Product> all, ProductFilterOptions by)
        {
            Result = all;
            FilterContains(product => product.Name, by.Name);
            FilterContains(product => product.Description, by.Description);
            return Result;
        }
    }
}