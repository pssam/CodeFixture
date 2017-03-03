using System;
using System.Linq;
using System.Linq.Expressions;
using CodeFixture;

namespace CodeFixtureTests.Filters
{
    public class FilterBase<TEntity>
    {
        protected IQueryable<TEntity> Result { get; set; }

        protected void FilterContains(Expression<Func<TEntity, string>> by, string text)
        {
            if (text != null)
            {
                Expression<Func<TEntity, bool>> filter = entity => by.Call()(entity).Contains(text);
                Result = Result.Where(filter.SubstituteMarker());
            }
        }
    }
}