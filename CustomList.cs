using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IList<T>
    {
        private T[] array;
        private int size;
        private int defaultCapacity = 4;

        private static readonly T[] emptyArray = new T[0];

        public CustomList()
        {
            array = emptyArray;
        }

        public CustomList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity cannot be less than zero.");

            if (capacity == 0)
                array = emptyArray;
            else
                array = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index >= size)
                    throw new ArgumentOutOfRangeException("The index cannot exceed or be equal to the size of the array.");

                return array[index];
            }
            set
            {
                if (index >= size)
                    throw new ArgumentOutOfRangeException("The set index cannot exceed or be equal to the size of the array.");

                array[index] = value;
            }
        }

        public int Capacity
        {
            get
            {
                return array.Length;
            }
            set
            {
                if (value < size)
                    throw new ArgumentOutOfRangeException("The entered value cannot be less than the size.");

                if (value != array.Length)
                {
                    if (value > 0)
                    {
                        T[] newArray = new T[value];

                        if (size > 0)
                        {
                            Array.Copy(array, 0, newArray, 0, size);
                        }

                        array = newArray;
                    }
                    else
                    {
                        array = emptyArray;
                    }
                }
            }
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (size == array.Length)
            {
                EnsureCapacity(size + 1);
            }

            array[size] = item;
            size++;
        }

        private void EnsureCapacity(int min)
        {
            if (array.Length < min)
            {
                int newCapacity = array.Length * 2;

                if (array.Length == 0)
                    newCapacity = defaultCapacity;

                if (newCapacity < min)
                    newCapacity = min;

                Capacity = newCapacity;
            }

        }

        public void Clear()
        {
            Array.Clear(array, 0, array.Length);
            size = 0;
            Capacity = defaultCapacity;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                for (int i = 0; i < size; i++)
                {
                    if (array[i] == null)
                        return true;
                }

                return false;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (item.Equals(array[i]))
                        return true;
                }

                return false;
            }
        }

        public void CopyTo(T[] newArray, int arrayIndex)
        {
            Array.Copy(array, 0, newArray, arrayIndex, size);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return array[i];
            }
        }

        public int IndexOf(T item)
        {
            if (item == null)
                throw new ArgumentNullException("Item is null.");

            for (int i = 0; i < array.Length; i++)
            {
                if (item.Equals(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > size)
                throw new ArgumentOutOfRangeException("The index you have entered is out of the bounds of the array.");

            if (size == array.Length)
            {
                EnsureCapacity(size + 1);
            }

            for (int i = size; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = item;
            size++;
        }

        public bool Remove(T item)
        {
            int curentIndex = IndexOf(item);

            if (curentIndex >= 0)
            {
                RemoveAt(curentIndex);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if(index < 0 || index > size)
                throw new ArgumentOutOfRangeException("The index you have entered is out of the bounds of the array.");

            if (index == array.Length - 1)
            { 
                array[index] = default(T);
                return;
            }

            for (int i = index; i <= size; i++)
            {
                array[i] = array[i + 1];
            }

            size--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
