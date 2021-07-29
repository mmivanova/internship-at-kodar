#nullable enable
using System;
using System.Collections.Generic;

namespace CustomLINQ
{
    public static class CustomLinq
    {
        public static bool Any<T>(this IEnumerable<T>? source)
        {
            if (source == null) throw new ArgumentNullException();

            foreach (var x in source)
            {
                if (x != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool All<T>(this IEnumerable<T>? source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in source)
            {
                if (predicate(element) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Contains<T>(this IEnumerable<T>? source, T value)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in source)
            {
                if (element.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T>? source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<T> Intersect<T>(this IEnumerable<T>? first, IEnumerable<T>? second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var firstElement in RemoveDuplicates(first))
            {
                foreach (var secondElement in RemoveDuplicates(second))
                {
                    if (firstElement.Equals(secondElement))
                    {
                        yield return firstElement;
                        break;
                    }
                }
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T>? source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            var i = 0;
            foreach (var element in source)
            {
                if (i < count)
                {
                    i++;
                    yield return element;
                    continue;
                }

                break;
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T>? source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            var i = 0;
            foreach (var element in source)
            {
                if (i < count)
                {
                    i++;
                    continue;
                }

                yield return element;
            }
        }

        public static IEnumerable<T> Reverse<T>(this IEnumerable<T>? source)
        {
            if (source == null) throw new ArgumentNullException();

            Stack<T> stack = new(source);
            foreach (var element in stack)
            {
                yield return element;
            }
        }

        public static T First<T>(this IEnumerable<T>? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in source)
            {
                if (element != null)
                {
                    return element;
                }
            }

            throw new InvalidOperationException();
        }

        public static T FirstOrDefault<T>(this IEnumerable<T>? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in source)
            {
                if (element != null)
                {
                    return element;
                }
            }

            return default;
        }

        private static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T>? source)
        {
            if (source == null) throw new ArgumentNullException();
            HashSet<T> set = new(source);
            return set;
        }
    }
}