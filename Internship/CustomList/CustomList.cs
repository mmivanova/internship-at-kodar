using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomList
{
    public class CustomList<T> : ICustomList<T>, IEnumerable<T>
    {
        private T[] _collection;
        private const int InitialCapacity = 4;
        public int Count { get; private set; }
        public int Capacity { get; set; }

        public CustomList() : this(InitialCapacity)
        {
        }

        public CustomList(int capacity)
        {
            ValidateCapacity(capacity);
            _collection = new T[capacity];
            Capacity = capacity;
            Count = 0;
        }

        public void Add(T item)
        {
            ResizeIfNeeded();
            _collection[Count] = item;
            IncreaseCount();
        }

        public bool Remove(T item)
        {
            if (!_collection.Contains(item)) return false;

            var indexToRemove = Array.IndexOf(_collection, item);

            _collection
                .Where((element, index) => index != indexToRemove)
                .ToArray()
                .CopyTo(_collection, 0);

            ResetLastItem();
            DecreaseCount();

            return true;
        }

        public void Insert(int index, T item)
        {
            ValidateIndexForInsertMethod(index);

            var remaining = Count - index;
            var elementsAfterIndex = new T[remaining];

            ResizeIfNeeded();

            Array.Copy(_collection,
                index + 1,
                elementsAfterIndex,
                0,
                remaining);

            _collection[index] = item;
            elementsAfterIndex.CopyTo(_collection, index + 1);
            IncreaseCount();
        }

        public T this[int index]
        {
            get
            {
                ValidateIndexIsWithinTheBoundariesOfTheCollection(index);
                return _collection[index];
            }
            set
            {
                ValidateIndexIsWithinTheBoundariesOfTheCollection(index);
                _collection[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return _collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private T[] Resize(T[] collection)
        {
            Capacity *= 2;
            var resizedCollection = new T[Capacity];
            collection.CopyTo(resizedCollection, 0);

            return resizedCollection;
        }

        private void ResizeIfNeeded()
        {
            if (Capacity.Equals(Count))
            {
                _collection = Resize(_collection);
            }
        }

        private void ResetLastItem()
        {
            if (Count.Equals(Capacity))
            {
                _collection[Count - 1] = default;
            }
        }

        private void ValidateIndexIsWithinTheBoundariesOfTheCollection(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ValidateIndexForInsertMethod(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private static void ValidateCapacity(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void IncreaseCount()
        {
            Count++;
        }

        private void DecreaseCount()
        {
            Count--;
        }
    }
}