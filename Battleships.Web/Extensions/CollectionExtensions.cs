using System.Collections.Generic;

namespace Battleships.Web.Extensions
{
    public static class CollectionExtensions
    {
        public static string Join (this IEnumerable<string> source, char delimiter)
        {
            return string.Join(delimiter, source);
        }
    }
}