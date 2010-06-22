using System;
using System.Collections.Generic;
using Missing.Collections.Generic;
using NUnit.Framework;

namespace Missing.NET.Test.Collections.Generic
{
    [TestFixture]
    public class IEnumerableExtensionsSpec
    {
        [Test]
        public void It_should_foreach_an_enumerable()
        {
            var array = new []{"jens", "jesper", "jensen"};
            IEnumerable<string> list = array;
            int i = 0;
            list.ForEach(
                (item) => {
                    Assert.AreEqual(array[i++],item);    
                });
            Assert.AreEqual(3,i);
        }

        [Test]
        public void It_should_compare_equal_lists()
        {
            var array1 = new[] { "jens", "jesper", "jensen" };
            var array2 = new[] { "jens", "jesper", "jensen" };
            Assert.IsTrue(array1.ElementsEquals(array2));
        }
        [Test]
        public void lists_with_unequal_count_should_not_be_equal()
        {
            var array1 = new[] { "jens", "jesper", "jensen" };
            var array2 = new[] { "jens", "jesper", "jensen","" };
            Assert.IsFalse(array1.ElementsEquals(array2));
        }

        [Test]
        public void lists_with_unequal_elemnts_should_not_be_equal()
        {
            var array1 = new[] { "jens", "jesper", "jensen" };
            var array2 = new[] { "jens", "jesper", "jensenf" };
            Assert.IsFalse(array1.ElementsEquals(array2));
        }
    }
}
