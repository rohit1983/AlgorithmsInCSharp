using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class MergeSort
    {
        protected IComparable[] auxArray = null;
        public void Sort(IComparable[] inputArray)
        {
            int length = inputArray.Length;
            auxArray = new IComparable[length];
            Sort(inputArray, 0, length - 1);
        }
        private void Sort(IComparable[] inputArray,int startIndex,int endIndex)
        {
            if(startIndex >= endIndex)
            {
                return;
            }
            else
            {
                int midIndex = startIndex + (endIndex - startIndex) / 2;
                Sort(inputArray, startIndex, midIndex);
                Sort(inputArray, midIndex + 1, endIndex);
                Merge(inputArray, startIndex, midIndex, endIndex);
            }
        }
        protected void Merge(IComparable[] inputArray,int startIndex,int midIndex,int endIndex)
        {
            int subLeft = startIndex;
            int subRight = midIndex + 1;
            for(int i = startIndex;i <= endIndex;i++)
            {
                auxArray[i] = inputArray[i];
            }
            for(int i=startIndex;i <= endIndex;i++)
            {
                if(subLeft > midIndex)
                {
                    inputArray[i] = auxArray[subRight++];
                }
                else if(subRight > endIndex)
                {
                    inputArray[i] = auxArray[subLeft++];
                }
                else if(auxArray[subLeft].CompareTo(auxArray[subRight]) <= 0)
                {
                    inputArray[i] = auxArray[subLeft++];
                }
                else
                {
                    inputArray[i] = auxArray[subRight++];
                }
            }
        }
    }
}
