using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Missing.Reflection;

namespace Missing.NET.UnitTesting.Collections
{
    public static class CollectionAssertionExtensions
    {
        public static void With<T>(this IList<T> list,Func<IList<T>,bool> func)
        {
            Assert.IsTrue(func(list));
        }

        public static void WithCount<T>(this IEnumerable<T> enumerable, int count)
        {
            CountShouldBe(enumerable, count);
        }

        public static void CountShouldBe<T>(this IEnumerable<T> enumerable, int count)
        {
            Assert.IsTrue(enumerable.Count() == count, "Expected <{0}> elements but has <{1}> elements".With(count, enumerable.Count()));
        }

        public static void ElementsShouldBeEqualTo<T>(this IList<T> self, IList<T> other)
        {
            if (self.Count != other.Count)
                throw new Exception("Expected:<{0}>. Actual:<{1}>"
                    .With(self.Count,other.Count));
            for (int i = 0; i < self.Count; i++)
            {
                if(!self[i].Equals(other[i]))
                    throw GetNotEqualException(self[i], other[i],i);
            }
        }

        private static Exception GetNotEqualException<T>(T expected, T actual, int index)
        {
            return new Exception(
                "Elements Should be equal. Element at possition {2} not equal:\r\nExpected: {0}\r\n Actual: {1}"
                    .With(expected,actual,index));
        }
    }
}