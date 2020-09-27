using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionTrees
{
    internal static class Utils
    {
        public static MemberInfo InfoOf<T>(Expression<Func<T>> f)
        {
            return InfoOfCore(f);
        }

        public static MemberInfo InfoOf(Expression<Action> f)
        {
            return InfoOfCore(f);
        }

        private static MemberInfo InfoOfCore(LambdaExpression e)
        {
            return e.Body.NodeType switch
            {
                ExpressionType.New => ((NewExpression) e.Body).Constructor,
                ExpressionType.Call => ((MethodCallExpression) e.Body).Method,
                ExpressionType.MemberAccess => ((MemberExpression) e.Body).Member,
                _ => throw new NotSupportedException()
            };
        }
    }
}