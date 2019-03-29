using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    internal class Query<T> : IQueryable<T>
    {
        public Query(Expression expression)
        {
            Expression = expression;
        }

        public Type ElementType => throw new NotImplementedException();

        public Expression Expression { get; }

        public IQueryProvider Provider => new Provider();

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}