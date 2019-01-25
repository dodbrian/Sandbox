using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Source<T> : IQueryable<T>
    {
        private readonly string _tableName;

        public Source(string tableName)
        {
            _tableName = tableName;
        }

        public string TableName
        {
            get { return _tableName; }
        }

        public override string ToString() => TableName;

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
    }
}