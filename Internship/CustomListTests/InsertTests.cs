using System;
using NUnit.Framework;
using CustomList;

namespace CustomListTests
{
    [TestFixture]
    public class InsertTests
    {
        private static void
            Insert_WithValidIndexAndValidItem_SetsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<T>()
        {
            var collection = new CustomList<T>()
            {
                default,
                default
            };
            var expected = default(T);

            collection.Insert(1, default);
            var actual = collection[1];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Insert_WithValidItemAndValidIndex_SetsTheItemAtTheSpecifiedIndexInTheCollection()
        {
            Insert_WithValidIndexAndValidItem_SetsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<string>();
            Insert_WithValidIndexAndValidItem_SetsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<double>();
            Insert_WithValidIndexAndValidItem_SetsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<int>();
            Insert_WithValidIndexAndValidItem_SetsTheItemAtTheSpecifiedIndexInTheCollectionTestHelper<char>();
        }

        private static void
            Insert_WithIndexEqualToTheCountOfTheItemsAndValidItem_SetsTheItemAtTheEndOfTheCollectionTestHelper<T>()
        {
            var collection = new CustomList<T>()
            {
                default,
                default
            };
            var expected = default(T);
            var index = collection.Count;

            collection.Insert(index, default);
            var actual = collection[index];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Insert_WithIndexEqualToTheCountOfTheItemsAndValidItem_SetsTheItemAtTheEndOfTheCollection()
        {
            Insert_WithIndexEqualToTheCountOfTheItemsAndValidItem_SetsTheItemAtTheEndOfTheCollectionTestHelper<
                string>();
            Insert_WithIndexEqualToTheCountOfTheItemsAndValidItem_SetsTheItemAtTheEndOfTheCollectionTestHelper<
                double>();
            Insert_WithIndexEqualToTheCountOfTheItemsAndValidItem_SetsTheItemAtTheEndOfTheCollectionTestHelper<int>();
            Insert_WithIndexEqualToTheCountOfTheItemsAndValidItem_SetsTheItemAtTheEndOfTheCollectionTestHelper<char>();
        }

        private static void
            Insert_WithIndexEqualToTheCountOfTheItemsInAnEmptyCollectionAndValidItem_SetsTheItemAtTheZeroIndexInTheCollectionTestHelper<
                T>()
        {
            var collection = new CustomList<T>();
            var expected = default(T);
            var index = collection.Count;

            collection.Insert(index, default);
            var actual = collection[index];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void
            Insert_WithIndexEqualToTheCountOfTheItemsInAnEmptyCollectionAndValidItem_SetsTheItemAtTheZeroIndexInTheCollection()
        {
            Insert_WithIndexEqualToTheCountOfTheItemsInAnEmptyCollectionAndValidItem_SetsTheItemAtTheZeroIndexInTheCollectionTestHelper
                <string>();
            Insert_WithIndexEqualToTheCountOfTheItemsInAnEmptyCollectionAndValidItem_SetsTheItemAtTheZeroIndexInTheCollectionTestHelper
                <double>();
            Insert_WithIndexEqualToTheCountOfTheItemsInAnEmptyCollectionAndValidItem_SetsTheItemAtTheZeroIndexInTheCollectionTestHelper
                <int>();
            Insert_WithIndexEqualToTheCountOfTheItemsInAnEmptyCollectionAndValidItem_SetsTheItemAtTheZeroIndexInTheCollectionTestHelper
                <char>();
        }

        private static void Insert_WithIndexLessThanZeroAndValidItem_ThrowsArgumentOutOfRangeExceptionTestHelper<T>()
        {
            var collection = new CustomList<T>();
            const int index = -1;

            Assert.Throws<IndexOutOfRangeException>((() => collection.Insert(index, default)));
        }

        [Test]
        public void Insert_WithIndexLessThanZeroAndValidItem_ThrowsArgumentOutOfRangeException()
        {
            Insert_WithIndexLessThanZeroAndValidItem_ThrowsArgumentOutOfRangeExceptionTestHelper<string>();
            Insert_WithIndexLessThanZeroAndValidItem_ThrowsArgumentOutOfRangeExceptionTestHelper<double>();
            Insert_WithIndexLessThanZeroAndValidItem_ThrowsArgumentOutOfRangeExceptionTestHelper<int>();
            Insert_WithIndexLessThanZeroAndValidItem_ThrowsArgumentOutOfRangeExceptionTestHelper<char>();
        }

        private static void
            Insert_WithIndexGreaterThanTheCountOfTheItemsAndValidItem_ThrowsIndexOutOfRangeExceptionTestHelper<T>()
        {
            var collection = new CustomList<T>();
            var index = collection.Count + 1;

            Assert.Throws<IndexOutOfRangeException>((() => collection.Insert(index, default)));
        }

        [Test]
        public void Insert_WithIndexGreaterThanTheCountOfTheItemsAndValidItem_ThrowsIndexOutOfRangeException()
        {
            Insert_WithIndexGreaterThanTheCountOfTheItemsAndValidItem_ThrowsIndexOutOfRangeExceptionTestHelper<
                string>();
            Insert_WithIndexGreaterThanTheCountOfTheItemsAndValidItem_ThrowsIndexOutOfRangeExceptionTestHelper<
                double>();
            Insert_WithIndexGreaterThanTheCountOfTheItemsAndValidItem_ThrowsIndexOutOfRangeExceptionTestHelper<int>();
            Insert_WithIndexGreaterThanTheCountOfTheItemsAndValidItem_ThrowsIndexOutOfRangeExceptionTestHelper<char>();
        }

        private static void
            Insert_WithValidIndexAndValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<T>()
        {
            var collection = new CustomList<T>();
            var expected = collection.Count + 1;

            collection.Insert(collection.Count, default);
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Insert_WithValidIndexAndValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOne()
        {
            Insert_WithValidIndexAndValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<string>();
            Insert_WithValidIndexAndValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<double>();
            Insert_WithValidIndexAndValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<int>();
            Insert_WithValidIndexAndValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<char>();
        }

        private static void
            Insert_WithValidIndexAndValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper<
                T>()
        {
            var collection = new CustomList<T>
            {
                default,
                default,
                default,
                default
            };
            var expected = collection.Capacity * 2;

            collection.Insert(collection.Count, default);
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Insert_WithValidIndexAndValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItems()
        {
            Insert_WithValidIndexAndValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper
                <string>();
            Insert_WithValidIndexAndValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper
                <double>();
            Insert_WithValidIndexAndValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper
                <int>();
            Insert_WithValidIndexAndValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper
                <char>();
        }

        private static void
            Insert_WithValidItemAndValidIndex_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper<
                T>()
        {
            var collection = new CustomList<T>
            {
                default,
                default
            };
            var expected = collection.Capacity;

            collection.Insert(collection.Count, default);
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void
            Insert_WithValidItemAndValidIndex_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItems()
        {
            Insert_WithValidItemAndValidIndex_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper
                <string>();
            Insert_WithValidItemAndValidIndex_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper
                <double>();
            Insert_WithValidItemAndValidIndex_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper
                <int>();
            Insert_WithValidItemAndValidIndex_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper
                <char>();
        }
    }
}