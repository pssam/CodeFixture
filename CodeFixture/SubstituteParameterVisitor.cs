using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CodeFixture
{
    public class SubstituteParameterVisitor : ExpressionVisitor
    {
        private readonly LambdaExpression _expressionToVisit;
        private readonly Dictionary<ParameterExpression, Expression> _substitutionByParameter;

        public SubstituteParameterVisitor(Expression[] parameterSubstitutions, LambdaExpression expressionToVisit)
        {
            _expressionToVisit = expressionToVisit;
            _substitutionByParameter = expressionToVisit.Parameters
                                                        .Select(
                                                            (parameter, index) =>
                                                                new { Parameter = parameter, Index = index })
                                                        .ToDictionary(pair => pair.Parameter,
                                                            pair => parameterSubstitutions[pair.Index]);
        }

        public Expression Replace()
        {
            return Visit(_expressionToVisit.Body);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Expression substitution;
            if (_substitutionByParameter.TryGetValue(node, out substitution))
            {
                return Visit(substitution);
            }
            return base.VisitParameter(node);
        }
    }
}