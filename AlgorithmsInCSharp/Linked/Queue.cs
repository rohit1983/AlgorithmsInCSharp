using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Linked
{
    public class Queue<T> : IEnumerable<T>
    {
        private int sz = 0;
        private Node<T> head = null;
        private Node<T> tail = null;

        public bool IsEmpty()
        {
            return sz == 0;
        }

        public int GetSize()
        {
            return sz;
        }

        public void Enqueue(T item)
        {
            var oldtail = tail;
            var current = new Node<T>()
            {
                Item = item
            };
            tail = current;
            if(oldtail == null)
            {
                head = tail;
            }
            else
            {
                oldtail.Next = tail;
            }
            sz++;
        }

        public T Dequeue()
        {
            if(!(sz > 0))
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T item = head.Item;
            head = head.Next;
            sz--;
            if(head == null)
            {
                tail = null;
            }
            return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while(current != null)
            {
                T item = current.Item;
                current = current.Next;
                yield return item;
            }
        }
    }
}
