using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayBased
{
    public class ResizingArrayStack<T> : IEnumerable<T>
    {
        private T[] array;
        private int size;
        public ResizingArrayStack()
        {
            array = new T[1];
            size = 0;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public int GetSize()
        {
            return size;
        }
        public void Push(T item)
        {
            if (size == array.Length)
            {
                ReSize(array.Length * 2);
            }
            array[size++] = item;
        }
        public T Pop()
        {
            if(size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T item = array[--size];
            array[size] = default(T);
            if(size == array.Length/4)
            {
                ReSize(array.Length / 2);
            }
            return item;
        }

        private void ReSize(int capacity)
        {
            T[] temp = new T[capacity];
            for(int i = 0;i < size;i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = size - 1;i >= 0;i--)
            {
                yield return array[i];
            }
        }
    }
}
