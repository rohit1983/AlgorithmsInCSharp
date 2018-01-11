using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class HeapSort
    {
        private static void SinkDown(IComparable[] inputArray,int index,int limitIndex)
        { 
            while(2*index <= limitIndex)
            {
                int childIndex = 2 * index;
                if(childIndex < limitIndex && inputArray[childIndex].CompareTo(inputArray[childIndex+1]) < 0)
                {
                    childIndex++;
                }
                if(inputArray[index].CompareTo(inputArray[childIndex]) >= 0)
                {
                    break;
                }
                Utility.Exchange(inputArray, index, childIndex);
                index = childIndex;
            }
        }


        public static void Sort(IComparable[] inputArray)
        {
            //for binary heap we create from 1 - n
            int length = inputArray.Length - 1;
            for(int i = length/2;i>=1;i--)
            {
                SinkDown(inputArray, i, length);
            }
            while(length > 1)
            {
                Utility.Exchange(inputArray, 1, length--);
                SinkDown(inputArray, 1, length);
            }
        }
    }
}
