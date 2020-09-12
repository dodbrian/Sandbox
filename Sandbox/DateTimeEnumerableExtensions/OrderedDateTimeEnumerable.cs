using System;
using System.Collections;
using System.Collections.Generic;

namespace Sandbox.DateTimeEnumerableExtensions
{
    public class OrderedDateTimeEnumerable : IOrderedDateTimeEnumerable
    {
        private readonly IEnumerable<DateTime> _enumerable;

        public bool Forward { get; }

        public OrderedDateTimeEnumerable(IEnumerable<DateTime> enumerable, bool forward)
        {
            _enumerable = enumerable;
            Forward = forward;
        }

        public IEnumerator<DateTime> GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }
    }
}