using System;
using CustomList;
using NUnit.Framework;

namespace CustomListTests
{
    [TestFixture]
    public class GetIndexerTests
    {
        private static void GetIndexer_WithValidIndex_ReturnsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<T>()
        {
            var collection = new CustomList<T>
            {
                default
            };
            T expected = default;

            var actual = collection[^1];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndexer_WithValidIndex_ReturnsTheItemAtTheSpecifiedIndexInTheCollection()
        {
            GetIndexer_WithValidIndex_ReturnsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<string>();
            GetIndexer_WithValidIndex_ReturnsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<double>();
            GetIndexer_WithValidIndex_ReturnsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<int>();
            GetIndexer_WithValidIndex_ReturnsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<char>();
        }

        private static void GetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeExceptionTestHelper<T>()
        {
            var collection = new CustomList<T>();

            Assert.Throws<IndexOutOfRangeException>((() =>
            {
                var index = collection[-1];
            }));
        }

        [Test]
        public void GetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeException()
        {
            GetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeExceptionTestHelper<string>();
            GetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeExceptionTestHelper<double>();
            GetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeExceptionTestHelper<int>();
            GetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeExceptionTestHelper<char>();
        }

        private static void
            GetIndexer_WithIndexGreaterThanTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<T>()
        {
            var collection = new CustomList<T>();
            var index = collection.Count + 1;

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var ind = collection[index];
            });
        }

        [Test]
        public void GetIndexer_WithIndexGreaterThanTheCountOfTheItems_ThrowsIndexOutOfRangeException()
        {
            GetIndexer_WithIndexGreaterThanTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<string>();
            GetIndexer_WithIndexGreaterThanTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<double>();
            GetIndexer_WithIndexGreaterThanTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<int>();
            GetIndexer_WithIndexGreaterThanTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<char>();
        }

        private static void GetIndexer_WithIndexEqualToTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<T>()
        {
            var collection = new CustomList<T>();
            var i = collection.Count;

            Assert.Throws<IndexOutOfRangeException>((() =>
            {
                var index = collection[i];
            }));
        }

        [Test]
        public void GetIndexer_WithIndexEqualToTheCountOfTheItems_ThrowsIndexOutOfRangeException()
        {
            GetIndexer_WithIndexEqualToTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<string>();
            GetIndexer_WithIndexEqualToTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<double>();
            GetIndexer_WithIndexEqualToTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<int>();
            GetIndexer_WithIndexEqualToTheCountOfTheItems_ThrowsIndexOutOfRangeExceptionTestHelper<char>();
        }

        private static void GetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<T>()
        {
            var collection = new CustomList<T>()
            {
                default
            };
            var expected = collection.Count;

            var item = collection[^1];
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollection()
        {
            GetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<string>();
            GetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<double>();
            GetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<int>();
            GetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<char>();
        }

        private static void GetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<T>()
        {
            var collection = new CustomList<T>()
            {
                default
            };
            var expected = collection.Capacity;

            var item = collection[^1];
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollection()
        {
            GetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<string>();
            GetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<double>();
            GetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<int>();
            GetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<char>();
        }
    }
}