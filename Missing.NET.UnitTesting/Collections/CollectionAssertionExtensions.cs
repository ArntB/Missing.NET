using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Missing.NET.UnitTesting.Collections
{
    public static class CollectionAssertionExtensions
    {
        public static void With<T>(this IList<T> list,Func<IList<T>,bool> func)
        {
            Assert.IsTrue(func(list));
        }

        public static void WithCount<T>(this IList<T> list, int count)
        {
            Assert.IsTrue(list.Count == count, "Expected <{0}> elements but has <{1}> elements".With(count, list.Count));
        }
    }
}