using System;
using System.Collections.Generic;

namespace Sandbox
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> items, int chunkLength)
        {
            if (chunkLength < 1) throw new ArgumentOutOfRangeException(nameof(chunkLength));

            var enumerator = items.GetEnumerator();

            while (enumerator.MoveNext())
            {
                yield return SubChunk(enumerator, chunkLength);
            }
        }

        private static IEnumerable<T> SubChunk<T>(IEnumerator<T> enumerator, int chunkLength)
        {
            yield return enumerator.Current;

            while (chunkLength-- > 1 && enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}
