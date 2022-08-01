using System.Collections.Generic;
using System.Linq;

namespace AzmonNew.Common
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pagesize, out int rowCount)
        {
            rowCount = source.Count();
            return source.Skip((page - 1) * pagesize).Take(pagesize);
        }
    }
}
 