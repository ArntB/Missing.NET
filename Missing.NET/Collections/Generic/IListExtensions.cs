using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ES.DotNetExtensions.Collections.Generic
{
    public static class IListExtensions
    {
        public static void ForEach<T>(this IList<T> self, Action<T> action)
        {
            foreach (var element in self)
            {
                action.Invoke(element);
            }
        }
    }
}
