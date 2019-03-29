using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    internal class Source<T> : IQueryable<T>
    {
        public Source(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; }

        public Expression Expression => Expression.Constant(this);

        public IQueryProvider Provider => new Provider();

        public Type ElementType => typeof(T);

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return TableName;
        }
    }
}