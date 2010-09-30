using System;
using System.Collections.Generic;
using System.Linq;

namespace Missing.Collections.Generic
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var element in self)
            {
                action.Invoke(element);
            }
        }

        public static string ForEach<T>(this IEnumerable<T> self, Func<T, string> action)
        {
            return self.Aggregate(string.Empty, (current, element) => current + action.Invoke(element));
        }
    }



    public static class IListExtensions
    {
        public static bool ElementsEquals<T>(this IList<T> self, IList<T> other)
        {
            if (self.Count != other.Count) return false;
            foreach (var element in self)
                if (!other.Contains(element))
                    return false;
            return true;
        }
    }

    public static class IDictionaryExtensions
    {
        public static bool ElementsEquals<TKey, T>(this IDictionary<TKey, IList<T>> self, IDictionary<TKey, IList<T>> other)
        {
            if (self.Count != other.Count) return false;
            foreach (var pair in self)
            {
                IList<T> value;
                if (!other.TryGetValue(pair.Key, out value))
                {
                    return false;
                }
                if (!pair.Value.ElementsEquals(value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}