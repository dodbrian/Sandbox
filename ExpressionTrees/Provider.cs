using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Provider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            => new Query<TElement>(expression);

        public object Execute(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new System.NotImplementedException();
        }
    }
}