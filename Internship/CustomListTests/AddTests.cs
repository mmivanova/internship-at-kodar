using CustomList;
using NUnit.Framework;

namespace CustomListTests
{
    [TestFixture]
    public class AddTest
    {
        private static void Add_WithValidItem_AddsTheItemAtTheEndOfTheCollectionTestHelper<T>()
        {
            // Arrange
            var collection = new CustomList<T>();
            var expected = default(T);

            // Act
            collection.Add(default(T));
            var actual = collection[^1];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_WithValidItem_AddsTheItemAtTheEndOfTheCollection()
        {
            Add_WithValidItem_AddsTheItemAtTheEndOfTheCollectionTestHelper<string>();
            Add_WithValidItem_AddsTheItemAtTheEndOfTheCollectionTestHelper<double>();
            Add_WithValidItem_AddsTheItemAtTheEndOfTheCollectionTestHelper<int>();
            Add_WithValidItem_AddsTheItemAtTheEndOfTheCollectionTestHelper<char>();
        }

        private static void Add_WithValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<T>()
        {
            var collection = new CustomList<T>();
            var expected = collection.Count + 1;

            collection.Add(default);
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_WithValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOne()
        {
            Add_WithValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<string>();
            Add_WithValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<char>();
            Add_WithValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<int>();
            Add_WithValidItem_IncreasesTheCountOfTheItemsInTheCollectionWithOneTestHelper<double>();
        }

        private static void
            Add_WithValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper<T>()
        {
            var collection = new CustomList<T>
            {
                default,
                default,
                default,
                default
            };
            var expected = collection.Capacity * 2;

            collection.Add(default);
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_WithValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItems()
        {
            Add_WithValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper<string>();
            Add_WithValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper<int>();
            Add_WithValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper<double>();
            Add_WithValidItem_DoublesTheCapacityOfTheCollectionIfItIsEqualToTheCountOfTheItemsTestHelper<char>();
        }

        private static void
            Add_WithValidItem_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper<T>()
        {
            var collection = new CustomList<T>
            {
                default,
                default
            };
            var expected = collection.Capacity;

            collection.Add(default);
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_WithValidItem_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItems()
        {
            Add_WithValidItem_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper<
                string>();
            Add_WithValidItem_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper<
                double>();
            Add_WithValidItem_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper<
                int>();
            Add_WithValidItem_DoesNotChangeTheCapacityOfTheCollectionIfItIsGreaterThanTheCountOfTheItemsTestHelper<
                char>();
        }
    }
}