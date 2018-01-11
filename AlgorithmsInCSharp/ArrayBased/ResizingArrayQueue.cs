using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayBased
{
    public class ResizingArrayQueue<T> : IEnumerable<T>
    {
        private T[] array;
        private int head;
        private int tail;
        private int size;

        public ResizingArrayQueue()
        {
            array = new T[2];
            head = 0;
            tail = 0;
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
        public void Enqueue(T item)
        {
            if(size == array.Length)
            {
                ReSize(array.Length * 2);
            }
            array[tail++] = item;
            if(tail == array.Length)
            {
                tail = 0;
            }
            size++;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }
            T item = array[head];
            array[head] = default(T);
            head++;
            size--;
            if(head == array.Length)
            {
                head = 0;
            }
            if(size >0 && size == array.Length/4)
            {
                ReSize(array.Length / 2);
            }
            return item;
        }
        private void ReSize(int capacity)
        {
            T[] temp = new T[capacity];
            for(int i =0;i < size;i++)
            {
                temp[i] = array[head + i % array.Length];
            }
            array = temp;
            head = 0;
            tail = size;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0;i < size;i++)
            {
                yield return array[(head + i) % array.Length];
            }
        }


    }
}
