namespace CustomList
{
    public interface ICustomList<T>
    {
        int Count { get; }

        /// <summary>
        /// Adds the item at the end of the list.
        /// </summary>
        /// <param name="item">The item to add</param>
        void Add(T item);

        /// <summary>
        /// Removes the first occurrence of an item in the list.
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>false if the item was not found true otherwise</returns>
        bool Remove(T item);

        void Insert(int index, T item);
        T this[int index] { get; set; }
    }
}