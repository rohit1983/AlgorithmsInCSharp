using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sorting;

namespace Algorithms.ArrayBased
{
    public class PriorityQueue<T>
    {
        private int Size;
        private IPriority<T>[] priorityArray;
        public PriorityQueue(int capacity)
        {
            priorityArray = new IPriority<T>[capacity];
            Size = 0;
        }
        protected void SwimUp(int index)
        {
            while(index > 1 && priorityArray[index].Priority < priorityArray[index/2].Priority)
            {
                Utility.Exchange(priorityArray, index, index/2);
                index = index / 2;
            }
        }

        protected void SinkDown(int index)
        {
            while(2*index <= Size)
            {
                int childIndex = 2 * index;
                if(childIndex < Size && priorityArray[childIndex].Priority < priorityArray[childIndex+1].Priority)
                {
                    childIndex++;
                }
                if(priorityArray[index].Priority >= priorityArray[childIndex].Priority)
                {
                    break;
                }
                Utility.Exchange(priorityArray, index, childIndex);
                index = childIndex;
            }
        }
        public bool IsEmpty()
        {
            return Size == 0;
        }
        public int GetSize()
        {
            return Size;
        }

        public void Insert(IPriority<T> item)
        {
            priorityArray[++Size] = item;
            SwimUp(Size);
        }

        public T ProcessMax()
        {
            T item = priorityArray[1].item;
            Utility.Exchange(priorityArray, 1, Size);
            priorityArray[Size] = null;
            Size--;
            SinkDown(1);
            return item;
        }

    }
}
