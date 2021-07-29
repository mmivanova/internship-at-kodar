using System;
using NUnit.Framework;
using CustomList;

namespace CustomListTests
{
    [TestFixture]
    public class CustomListTests
    {
        private static void CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCountZeroTestHelper<T>()
        {
            const int expected = 0;

            var collection = new CustomList<T>();
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCountZero()
        {
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCountZeroTestHelper<string>();
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCountZeroTestHelper<double>();
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCountZeroTestHelper<int>();
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCountZeroTestHelper<char>();
        }

        private static void
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCapacityOfFourTestHelper<T>()
        {
            const int expected = 4;

            var collection = new CustomList<T>();
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCapacityOfFour()
        {
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCapacityOfFourTestHelper<string>();
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCapacityOfFourTestHelper<double>();
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCapacityOfFourTestHelper<int>();
            CustomList_WithNoArgumentsAndNoBody_InitializesNewCustomListWithCapacityOfFourTestHelper<char>();
        }

        private static void
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheItemAtTheZeroIndexTestHelper<T>()
        {
            var expected = default(T);

            var collection = new CustomList<T>()
            {
                default
            };
            var actual = collection[0];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheItemAtTheZeroIndex()
        {
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheItemAtTheZeroIndexTestHelper<
                string>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheItemAtTheZeroIndexTestHelper<
                double>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheItemAtTheZeroIndexTestHelper<
                int>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheItemAtTheZeroIndexTestHelper<
                char>();
        }

        private static void
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCountOfTheItemsToOneTestHelper<
                T>()
        {
            const int expected = 1;

            var collection = new CustomList<T>()
            {
                default
            };
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCountOfTheItemsToOne()
        {
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCountOfTheItemsToOneTestHelper<
                string>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCountOfTheItemsToOneTestHelper<
                double>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCountOfTheItemsToOneTestHelper<
                int>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCountOfTheItemsToOneTestHelper<
                char>();
        }

        private static void
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCapacityToFourTestHelper<
                T>()
        {
            const int expected = 4;

            var collection = new CustomList<T>()
            {
                default
            };
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndDoesNotChangeTheCapacityOfTheCollection()
        {
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCapacityToFourTestHelper<
                string>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCapacityToFourTestHelper<
                double>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCapacityToFourTestHelper<int>();
            CustomList_WithNoArgumentsAndBodyWithOneItem_CreatesNewCustomListAndSetsTheCapacityToFourTestHelper<char>();
        }

        private static void
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCountOfTheItemsToFiveTestHelper<
                T>()
        {
            const int expected = 5;

            var collection = new CustomList<T>()
            {
                default,
                default,
                default,
                default,
                default
            };
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCountOfTheItemsToFive()
        {
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCountOfTheItemsToFiveTestHelper
                <string>();
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCountOfTheItemsToFiveTestHelper
                <double>();
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCountOfTheItemsToFiveTestHelper
                <int>();
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCountOfTheItemsToFiveTestHelper
                <char>();
        }

        private static void
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCapacityToEightTestHelper<T>()
        {
            const int expected = 8;

            var collection = new CustomList<T>()
            {
                default,
                default,
                default,
                default,
                default
            };
            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCapacityToEight()
        {
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCapacityToEightTestHelper<
                string>();
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCapacityToEightTestHelper<
                double>();
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCapacityToEightTestHelper<
                int>();
            CustomList_WithNoArgumentsAndBodyWithFiveItems_CreatesNewCustomListAndSetsTheCapacityToEightTestHelper<
                char>();
        }

        private static void
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper<
                T>()
        {
            var random = new Random();
            var number = random.Next(100);

            var collection = new CustomList<T>(number);
            var expected = number;

            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCapacityToSpecifiedValue()
        {
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper<
                string>();
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper<
                double>();
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper<
                int>();
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper<
                char>();
        }

        private static void CustomList_WithCapacityLessThanZero_ThrowsArgumentOutOfRangeExceptionTestHelper<T>()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var customList = new CustomList<T>(-1);
            });
        }

        [Test]
        public void CustomList_WithCapacityLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            CustomList_WithCapacityLessThanZero_ThrowsArgumentOutOfRangeExceptionTestHelper<string>();
            CustomList_WithCapacityLessThanZero_ThrowsArgumentOutOfRangeExceptionTestHelper<double>();
            CustomList_WithCapacityLessThanZero_ThrowsArgumentOutOfRangeExceptionTestHelper<int>();
            CustomList_WithCapacityLessThanZero_ThrowsArgumentOutOfRangeExceptionTestHelper<char>();
        }

        private static void
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCountToZeroTestHelper<T>()
        {
            var random = new Random();
            var number = random.Next(100);

            var collection = new CustomList<T>(number);
            const int expected = 0;

            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCountToZero()
        {
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCountToZeroTestHelper<string>();
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCountToZeroTestHelper<double>();
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCountToZeroTestHelper<int>();
            CustomList_WithValidCapacityAndNoBody_CreatesNewCustomListAndSetsTheCountToZeroTestHelper<char>();
        }

        private static void
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCountToTheNumberOfTheItemsTestHelper<
                T>()
        {
            var collection = new CustomList<T>(7)
            {
                default,
                default,
                default,
                default
            };
            const int expected = 4;

            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCountToTheNumberOfTheItems()
        {
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCountToTheNumberOfTheItemsTestHelper
                <string>();
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCountToTheNumberOfTheItemsTestHelper
                <double>();
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCountToTheNumberOfTheItemsTestHelper
                <int>();
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCountToTheNumberOfTheItemsTestHelper
                <char>();
        }

        private static void
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper<
                T>()
        {
            var collection = new CustomList<T>(7)
            {
                default,
                default,
                default,
                default
            };
            const int expected = 7;

            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValue()
        {
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper
                <string>();
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper
                <double>();
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper
                <int>();
            CustomList_WithValidCapacityAndBodyWithFourItems_CreatesNewCustomListAndSetsTheCapacityToTheSpecifiedValueTestHelper
                <char>();
        }

        private static void
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndResetsTheCapacityOfTheCollectionTestHelper<
                T>()
        {
            var collection = new CustomList<T>(2)
            {
                default,
                default,
                default,
                default
            };
            const int expected = 4;

            var actual = collection.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndResetsTheCapacityOfTheCollection()
        {
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndResetsTheCapacityOfTheCollectionTestHelper
                <string>();
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndResetsTheCapacityOfTheCollectionTestHelper
                <double>();
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndResetsTheCapacityOfTheCollectionTestHelper
                <int>();
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndResetsTheCapacityOfTheCollectionTestHelper
                <char>();
        }

        private static void
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndSetsTheCountOfTheCollectionToTheNumberOfItemsInItTestHelper<
                T>()
        {
            var collection = new CustomList<T>(2)
            {
                default,
                default,
                default,
                default
            };
            const int expected = 4;

            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndSetsTheCountOfTheCollectionToTheNumberOfItemsInIt()
        {
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndSetsTheCountOfTheCollectionToTheNumberOfItemsInItTestHelper
                <string>();
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndSetsTheCountOfTheCollectionToTheNumberOfItemsInItTestHelper
                <double>();
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndSetsTheCountOfTheCollectionToTheNumberOfItemsInItTestHelper
                <int>();
            CustomList_WithValidCapacityAndBodyWithItemsMoreThanTheCapacity_CreatesNewCustomListAndSetsTheCountOfTheCollectionToTheNumberOfItemsInItTestHelper
                <char>();
        }
    }
}