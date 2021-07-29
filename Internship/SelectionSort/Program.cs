using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectionSort
{
    internal static class Program
    {
        private static void Main()
        {
            var list = Console.ReadLine()?
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            SortFromFrontToBackGeneric(list);
        }

        private static void SortFromBackToFront(IList<int> list)
        {
            var indexToChange = list.Count - 1;

            for (var i = 0; i < list.Count - 1; i++)
            {
                var best = list[0];
                var indexOfBest = 0;

                for (var j = 1; j <= indexToChange; j++)
                {
                    var current = list[j];
                    if (current <= best) continue;
                    best = current;
                    indexOfBest = j;
                }

                var temp = list[indexToChange];
                list[indexToChange] = best;
                list[indexOfBest] = temp;
                indexToChange--;
            }

            Console.WriteLine(string.Join(", ", list));
        }

        private static void SortFromFrontToBack(IList<int> list)
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                var best = list[i];
                var indexOfBest = i;

                for (var j = i + 1; j < list.Count; j++)
                {
                    var current = list[j];
                    if (current > best) continue;
                    best = current;
                    indexOfBest = j;
                }

                var temp = list[i];
                list[i] = best;
                list[indexOfBest] = temp;
            }

            Console.WriteLine(string.Join(", ", list));
        }

        private static void SortFromFrontToBackGeneric<T>(IList<T> list)
            where T : IComparable<T>
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                var best = list[i];
                var indexOfBest = i;

                for (var j = i + 1; j < list.Count; j++)
                {
                    var current = list[j];
                    if (current.CompareTo(best) >= 1) continue;
                    best = current;
                    indexOfBest = j;
                }

                var temp = list[i];
                list[i] = best;
                list[indexOfBest] = temp;
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}