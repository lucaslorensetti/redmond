using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Redmond.Infrastructure.Helpers
{
    public static class EntityFrameworkHelper
    {
        public static async Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source)
        {
            return await EntityFrameworkQueryableExtensions.ToListAsync(source);
        }

        public static async Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate = null)
        {
            return predicate != null
                ? await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(source, predicate)
                : await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(source);
        }

        public static async Task<bool> AnyAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return await EntityFrameworkQueryableExtensions.AnyAsync(source, predicate);
        }
    }
}
