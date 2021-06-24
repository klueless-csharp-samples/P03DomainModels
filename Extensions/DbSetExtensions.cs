namespace P03DomainModels.Extensions
{
  using System;
  using System.Linq;
  using System.Linq.Expressions;
  using Microsoft.EntityFrameworkCore;

  public static class DbSetExtensions
  {
    public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
    {
        var exists = predicate != null ? dbSet.Any(predicate.Compile()) : dbSet.Any();
        // var exists = dbSet.Any();
        return !exists ? dbSet.Add(entity).Entity : null;
    }
  }
}
