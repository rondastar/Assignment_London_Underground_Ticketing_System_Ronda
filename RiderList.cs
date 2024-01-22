using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
    public class RiderList<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _count;

        // default constructor with capacity 10
        public RiderList() : this(10)
        {

        }

        // constructor to specify starting size
        public RiderList(int initialSize)
        {
            _items = new T[initialSize];
        }
        
        // Add inserts item at the end
        public void Add(T item)
        {
            CheckIntegrity(); // ensures there's enough space
            _items[_count++] = item;
        }

        // AddAtIndex places items at a specified index
        public void AddAtIndex(T item, int index)
        {
            CheckIntegrity(); // ensures there's enough space
            ValidateIndexWithinRange(index);

            for (int i = _count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = item;
            _count++;
        }

        public void RemoveAtIndex(int index)
        {
            ValidateIndexWithinRange(index);
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
        }

        public T GetItem(int index)
        {
            ValidateIndexWithinRange(index);
            T item = _items[index]; 
            return item;
        }

        public void ValidateIndexWithinRange(int index)
        {
            if (index < 0 || index > _count) throw new ArgumentOutOfRangeException(nameof(index));
        }


        // CheckIntegrity ensures the array size is sufficient, expanding it when 80% full
        private void CheckIntegrity()
        {
            if (_count >= 0.8 * _items.Length)
            {
                T[] largerArray = new T[_items.Length * 2];
                Array.Copy(_items, largerArray, _count);
                _items = largerArray;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    } // class
} // namespace

