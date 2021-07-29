using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    internal static class Program
    {
        private static void Main()
        {
            StringInput();
            IntegerInput();
        }

        private static int BinarySearch<T>(IList<T> list, T target)
            where T : IComparable
        {
            var start = 0;
            var end = list.Count - 1;

            if (target.CompareTo(list[end]) == 1 || target.CompareTo(list[start]) == -1)
            {
                return -1;
            }

            var middle = (int) Math.Ceiling((decimal) ((start + end) / 2));

            while (start != end)
            {
                switch (list[middle].CompareTo(target))
                {
                    case 1:
                        end = middle - 1;
                        middle = UpdateMiddle(start, end);
                        break;
                    case 0:
                        return middle;
                    default:
                        start = middle + 1;
                        middle = UpdateMiddle(start, end);
                        break;
                }
            }

            return start;
        }

        private static int BinarySearchRecursion<T>(IList<T> list, T target, int start = 0, int end = -1)
            where T : IComparable
        {
            if (end == -1)
            {
                end = list.Count - 1;
            }

            if (target.CompareTo(list[end]) == 1 || target.CompareTo(list[start]) == -1)
            {
                return -1;
            }

            var middle = (start + end) / 2;

            if (list[middle].Equals(target))
            {
                return middle;
            }

            if (start.Equals(end))
            {
                return start;
            }

            return list[middle].CompareTo(target) == 1
                ? BinarySearchRecursion<T>(list, target, start, middle - 1)
                : BinarySearchRecursion<T>(list, target, middle + 1, end);
        }

        private static int UpdateMiddle(int start, int end)
        {
            return (int) Math.Ceiling((decimal) ((start + end) / 2.0));
        }

        private static void StringInput()
        {
            Console.WriteLine("Please, enter a list of words: ");
            var input = Console.ReadLine()?
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.Write("Please, enter the target word: ");
            var target = Console.ReadLine();

            ValidateInput(input);
            ValidateStringTarget(target);

            Console.WriteLine(BinarySearch(input, target));
            Console.WriteLine(BinarySearchRecursion(input, target));
        }

        private static void ValidateStringTarget(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentException("Target cannot be empty!");
            }
        }

        private static void IntegerInput()
        {
            Console.WriteLine("Please, enter a list of numbers: ");
            var input = Console.ReadLine()?
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.Write("Please, enter the target number: ");
            try
            {
                var target = int.Parse(Console.ReadLine()!);
                ValidateInput(input);

                Console.WriteLine(BinarySearch(input, target));
                Console.WriteLine(BinarySearchRecursion(input, target));
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Target cannot be empty!");
            }
        }

        private static void ValidateInput<T>(List<T> input)
        {
            if (!input.Any())
            {
                throw new ArgumentException("Input cannot be empty!");
            }

            input.Sort();
        }
    }
}