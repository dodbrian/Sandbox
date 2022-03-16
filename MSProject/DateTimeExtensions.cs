using System;

namespace MSProject
{
    public static class DateTimeExtensions
    {
        public static DateTime UnspecifiedKind(this DateTime dateTime) =>
            DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
    }
}