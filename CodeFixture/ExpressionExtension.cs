using System;
using System.Linq.Expressions;

namespace CodeFixture
{
    public static class ExpressionExtension
    {
        public static TFunc Call<TFunc>(this Expression<TFunc> expression)
        {
            throw new InvalidOperationException(
                "This method should never be called. It is a marker for constructing filter expressions.");
        }

        public static Expression<TFunc> SubstituteMarker<TFunc>(this Expression<TFunc> expression)
        {
            var visitor = new SubstituteExpressionCallVisitor();
            return (Expression<TFunc>)visitor.Visit(expression);
        }
    }
}