using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Query<T> : IQueryable<T>
    {
        private readonly Expression _expression;

        public Query(Expression expression)
        {
            _expression = expression;
        }

        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => _expression;

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