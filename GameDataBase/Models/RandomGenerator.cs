using System;
using System.Linq;
using System.Linq.Expressions;

namespace GameDataBase.Models
{
    public static class RandomGenerator
    {
        public static T RandomElement<T>(this IQueryable<T> q, Expression<Func<T, bool>> e)
        {
            var r = new Random();
            q = q.Where(e);
            return q.Skip(r.Next(q.Count())).FirstOrDefault();
        }
    }
}