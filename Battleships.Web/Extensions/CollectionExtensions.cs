using System.Collections.Generic;
using System.Linq;

namespace Battleships.Web.Extensions
{
    public static class CollectionExtensions
    {
        public static string Join(this IEnumerable<string> source, char delimiter)
        {
            return string.Join(delimiter, source);
        }

        public static IEnumerable<int> To(this int from, int to)
        {
            return Enumerable.Range(from, to - from + 1);
        }
    }
}