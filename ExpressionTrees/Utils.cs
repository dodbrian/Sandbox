using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionTrees
{
    static class Utils
    {
        public static MemberInfo InfoOf<T>(Expression<Func<T>> f) => InfoOfCore(f);

        public static MemberInfo InfoOf(Expression<Action> f) => InfoOfCore(f);

        private static MemberInfo InfoOfCore(LambdaExpression e)
        {
            switch (e.Body.NodeType)
            {
                case ExpressionType.New:
                    return ((NewExpression)e.Body).Constructor;
                case ExpressionType.Call:
                    return ((MethodCallExpression)e.Body).Method;
                case ExpressionType.MemberAccess:
                    return ((MemberExpression)e.Body).Member;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}