using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Linked
{
    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> Head = null;
        private int Sz;

        public bool IsEmpty()
        {
            return Sz == 0;
        }

        public int GetSize()
        {
            return Sz;
        }

        public void Push(T item)
        {
            var oldHead = Head;
            Head = new Node<T>()
            {
                Item = item
            };
            Head.Next = oldHead;
            Sz++;
        }

        public T Pop()
        {
            if(Head == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T item = Head.Item;
            Head = Head.Next;
            Sz--;
            return item;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                T item = current.Item;
                current = current.Next;
                yield return item;
            }
        }
    }
}
