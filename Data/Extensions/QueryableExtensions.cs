using System.Linq.Expressions;

namespace Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> source, bool condition = false, Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (condition && predicate != null)
            source = source.Where(predicate);
        return source;
    }
}