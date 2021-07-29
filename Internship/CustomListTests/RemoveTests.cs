using CustomList;
using NUnit.Framework;

namespace CustomListTests
{
    [TestFixture]
    public class RemoveTests
    {
        private static void
            Remove_WithExistingItem_RemovesTheFirstOccurrenceOfTheItemFromTheCollectionAndReturnsTrueTestHelper<T>()
        {
            // Arrange
            var collection = new CustomList<T>
            {
                default(T)
            };
            var item = default(T);

            // Act
            var actual = collection.Remove(item);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Remove_WithExistingItem_RemovesTheFirstOccurrenceOfTheTheItemFromTheCollectionAndReturnsTrue()
        {
            Remove_WithExistingItem_RemovesTheFirstOccurrenceOfTheItemFromTheCollectionAndReturnsTrueTestHelper<char>();
            Remove_WithExistingItem_RemovesTheFirstOccurrenceOfTheItemFromTheCollectionAndReturnsTrueTestHelper<
                string>();
            Remove_WithExistingItem_RemovesTheFirstOccurrenceOfTheItemFromTheCollectionAndReturnsTrueTestHelper<int>();
        }

        private static void Remove_WithNonExistentItem_ReturnsFalseTestHelper<T>()
        {
            // Arrange
            var collection = new CustomList<T>
            {
                default(T)
            };
            var item = default(T);

            // Act
            var actual = collection.Remove(item);

            // Assert
            Assert.AreNotEqual(false, actual);
        }

        [Test]
        public void Remove_WithNonExistentItem_ReturnsFalse()
        {
            Remove_WithNonExistentItem_ReturnsFalseTestHelper<string>();
            Remove_WithNonExistentItem_ReturnsFalseTestHelper<int>();
            Remove_WithNonExistentItem_ReturnsFalseTestHelper<double>();
            Remove_WithNonExistentItem_ReturnsFalseTestHelper<char>();
        }

        private static void Remove_WithExistingItem_DecreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<T>()
        {
            var collection = new CustomList<T>
            {
                default,
                default,
                default
            };
            var expected = collection.Count - 1;

            collection.Remove(default);
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_WithExistingItem_DecreasesTheCountOfTheItemsInTheCollectionWithOne()
        {
            Remove_WithExistingItem_DecreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<string>();
            Remove_WithExistingItem_DecreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<double>();
            Remove_WithExistingItem_DecreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<int>();
            Remove_WithExistingItem_DecreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<char>();
        }

        private static void Remove_WithExistingItem_DoesNotChangeTheCapacityOfTheCollectionTestHelper<T>()
        {
            var collection = new CustomList<T>
            {
                default,
                default,
                default,
                default,
                default
            };
            var expected = collection.Capacity;

            collection.Remove(default);
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_WithExistingItem_DoesNotChangeTheCapacityOfTheCollection()
        {
            Remove_WithExistingItem_DoesNotChangeTheCapacityOfTheCollectionTestHelper<string>();
            Remove_WithExistingItem_DoesNotChangeTheCapacityOfTheCollectionTestHelper<double>();
            Remove_WithExistingItem_DoesNotChangeTheCapacityOfTheCollectionTestHelper<int>();
            Remove_WithExistingItem_DoesNotChangeTheCapacityOfTheCollectionTestHelper<char>();
        }
    }
}