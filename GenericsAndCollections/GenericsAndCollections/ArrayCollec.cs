using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndCollections
{
    public class ArrayCollec<T>
    {
        private readonly int maxSize;
        private int index;
        private T[] items;

        public ArrayCollec(int maxSize = 5)
        {
            this.maxSize = maxSize;
            this.items = new T[maxSize];
            this.index = 0;
        }

        public void Add(T item)
        {
            if ( index >= maxSize )
                throw new InvalidOperationException("Array is full.");
            items[index++] = item;
        }

        public T GetByIndex(int idx)
        {
            if (idx < 0 || idx >= maxSize)
                throw new IndexOutOfRangeException("Index out of range.");
            return items[idx];
        }

        public void SetByIndex(int idx, T item)
        {
            if (idx < 0 || idx >= maxSize)
                throw new IndexOutOfRangeException("Index out of range.");
            items[idx] = item;
        }

        public void SwapByIndex(int idx1, int idx2)
        {
            if (idx1 < 0 || idx1 >= maxSize || idx2 < 0 || idx2 >= maxSize)
                throw new IndexOutOfRangeException("Index out of bounds");

            T temp = items[idx1];
            items[idx1] = items[idx2];
            items[idx2] = temp;
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < index; i++)
            {
                output += items[i] + " ";
            }
            return output;
        }
    }
}
