using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CodeFixture
{
    public class SubstituteExpressionCallVisitor : ExpressionVisitor
    {
        private readonly MethodInfo _markerDesctiprion;

        public SubstituteExpressionCallVisitor()
        {
            _markerDesctiprion =
                typeof(ExpressionExtension).GetMethod(nameof(ExpressionExtension.Call)).GetGenericMethodDefinition();
        }

        protected override Expression VisitInvocation(InvocationExpression node)
        {
            if (node.Expression.NodeType == ExpressionType.Call && IsMarker((MethodCallExpression)node.Expression))
            {
                var parameterReplacer = new SubstituteParameterVisitor(node.Arguments.ToArray(),
                    Unwrap((MethodCallExpression)node.Expression));
                var target = parameterReplacer.Replace();
                return Visit(target);
            }
            return base.VisitInvocation(node);
        }

        private LambdaExpression Unwrap(MethodCallExpression node)
        {
            var target = node.Arguments[0];
            return (LambdaExpression)Expression.Lambda(target).Compile().DynamicInvoke();
        }

        private bool IsMarker(MethodCallExpression node)
        {
            return node.Method.IsGenericMethod && node.Method.GetGenericMethodDefinition() == _markerDesctiprion;
        }
    }
}