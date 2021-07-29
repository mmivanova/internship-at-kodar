using System;
using CustomList;
using NUnit.Framework;

namespace CustomListTests
{
    [TestFixture]
    public class SetIndexerTests
    {
        private static void SetIndexer_WithValidIndex_SetsTheItemAtTheSpecifiedPositionTestHelper<T>()
        {
            // Arrange
            var collection = new CustomList<T>
            {
                default(T),
            };
            var index = collection.Count - 1;
            var expected = default(T);

            // Act
            collection[index] = default;
            var actual = collection[index];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetIndexer_WithValidIndex_SetsTheItemAtTheSpecifiedPosition()
        {
            SetIndexer_WithValidIndex_SetsTheItemAtTheSpecifiedPositionTestHelper<string>();
            SetIndexer_WithValidIndex_SetsTheItemAtTheSpecifiedPositionTestHelper<int>();
        }

        private static void SetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeExceptionTestHelper<T>()
        {
            // Arrange
            var collection = new CustomList<T>();
            const int index = -1;

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => collection[index] = default);
        }

        [Test]
        public void SetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeException()
        {
            SetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeExceptionTestHelper<string>();
            SetIndexer_WithIndexLessThanZero_ThrowsIndexOutOfRangeExceptionTestHelper<int>();
        }

        private static void
            SetIndexer_WithIndexGreaterThanTheCountOfTheElements_ThrowsIndexOutOfRangeExceptionTestHelper<T>()
        {
            // Arrange
            var collection = new CustomList<T>
            {
                default(T)
            };
            var index = collection.Count + 1;

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => collection[index] = default);
        }

        [Test]
        public void SetIndexer_WithIndexGreaterThanTheCountOfTheElements_ThrowsIndexOutOfRangeException()
        {
            SetIndexer_WithIndexGreaterThanTheCountOfTheElements_ThrowsIndexOutOfRangeExceptionTestHelper<string>();
            SetIndexer_WithIndexGreaterThanTheCountOfTheElements_ThrowsIndexOutOfRangeExceptionTestHelper<int>();
        }

        private static void
            SetIndexer_WithIndexEqualToTheCountOfTheElements_ThrowsIndexOutOfRangeExceptionTestHelper<T>()
        {
            // Arrange
            var collection = new CustomList<T>
            {
                default(T)
            };
            var index = collection.Count;

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => collection[index] = default);
        }

        [Test]
        public void SetIndexer_WithIndexEqualToTheCountOfTheElements_ThrowsIndexOutOfRangeException()
        {
            SetIndexer_WithIndexEqualToTheCountOfTheElements_ThrowsIndexOutOfRangeExceptionTestHelper<string>();
            SetIndexer_WithIndexEqualToTheCountOfTheElements_ThrowsIndexOutOfRangeExceptionTestHelper<int>();
        }

        private static void SetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<T>()
        {
            var collection = new CustomList<T>()
            {
                default
            };
            var expected = collection.Count;

            collection[0] = default;
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollection()
        {
            SetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<string>();
            SetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<double>();
            SetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<int>();
            SetIndexer_WithValidIndex_DoesNotChangeTheCountOfTheItemsInTheCollectionTestHelper<char>();
        }

        private static void SetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<T>()
        {
            var collection = new CustomList<T>()
            {
                default
            };
            var expected = collection.Capacity;

            collection[0] = default;
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollection()
        {
            SetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<string>();
            SetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<double>();
            SetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<int>();
            SetIndexer_WithValidIndex_DoesNotChangeTheCapacityOfTheCollectionTestHelper<char>();
        }
    }
}