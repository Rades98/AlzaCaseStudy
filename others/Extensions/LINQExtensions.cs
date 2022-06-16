namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LINQExtensions
    {
        /// <summary>
        /// LINQ equivalent to "?" operator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements">Enumerable on which should be this method applied</param>
        /// <param name="condition">Condition to determine if first or second func</param>
        /// <param name="thenPath">If condition is true</param>
        /// <param name="elsePath">If condition is false</param>
        /// <returns></returns>
        public static IEnumerable<T> IfThenElse<T>(
        this IEnumerable<T> elements,
        Func<bool> condition,
        Func<IEnumerable<T>, IEnumerable<T>> thenPath,
        Func<IEnumerable<T>, IEnumerable<T>> elsePath)
        {
            return condition()
                ? thenPath(elements)
                : elsePath(elements);
        }

        public static IQueryable<T> IfThenElse<T>(
        this IQueryable<T> elements,
        Func<bool> condition,
        Func<IQueryable<T>, IQueryable<T>> thenPath,
        Func<IQueryable<T>, IQueryable<T>> elsePath)
        {
            return condition()
                ? thenPath(elements)
                : elsePath(elements);
        }
    }
}