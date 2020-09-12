using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.DateTimeEnumerableExtensions
{
    public static class DateTimeEnumerable
    {
        public static IOrderedDateTimeEnumerable OrderedRange(DateTime start, DateTime end, bool forward)
        {
            return new OrderedDateTimeEnumerable(Range(start, end, forward), forward);
        }

        public static IEnumerable<DateTime> WithLastOn(this IOrderedDateTimeEnumerable dates, DateTime lastDate)
        {
            lastDate = lastDate.Date;

            bool inRange(DateTime current) => dates.Forward
                ? current <= lastDate
                : current >= lastDate;

            return dates.TakeWhile(date => inRange(date));
        }

        public static IOrderedDateTimeEnumerable FutureFrom(DateTime start)
        {
            return OrderedRange(start, DateTime.MaxValue, forward: true);
        }

        public static IOrderedDateTimeEnumerable PastFrom(DateTime start)
        {
            return OrderedRange(start, DateTime.MinValue, forward: false);
        }

        private static IEnumerable<DateTime> Range(DateTime start, DateTime end, bool forward)
        {
            start = start.Date;
            end = end.Date;

            var current = start;

            bool inRange(DateTime current) => forward
                ? start <= current && current < end
                : end < current && current <= start;

            while (inRange(current))
            {
                yield return current;
                current = current.AddDays(forward ? 1 : -1);
            }
        }
    }
}