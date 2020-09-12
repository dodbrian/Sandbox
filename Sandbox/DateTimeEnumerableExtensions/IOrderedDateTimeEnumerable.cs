using System;
using System.Collections.Generic;

namespace Sandbox.DateTimeEnumerableExtensions
{
    public interface IOrderedDateTimeEnumerable : IEnumerable<DateTime>
    {
        bool Forward { get; }
    }
}