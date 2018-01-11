using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class QuickSort
    {
        public static void Sort(IComparable[] inputArray)
        {
            new Random().Shuffle(inputArray);
            Sort(inputArray, 0, inputArray.Length - 1);
        }
        private static void Sort(IComparable[] inputArray,int startIndex,int endIndex)
        {
            if(startIndex >= endIndex)
            {
                return;
            }
            int partition = Partition(inputArray, startIndex, endIndex);
            Sort(inputArray, startIndex, partition - 1);
            Sort(inputArray, partition + 1, endIndex);
        }

        public static int Partition(IComparable[] inputArray,int startIndex,int endIndex)
        {
            int subLower = startIndex;
            int subLarger = endIndex + 1;
            IComparable threshhold = inputArray[startIndex];
            while(true)
            {
                while(threshhold.CompareTo(inputArray[++subLower]) > 0)
                {
                    if(subLower >= endIndex)
                    {
                        break;
                    }
                }
                while(threshhold.CompareTo(inputArray[--subLarger]) < 0)
                {
                    if(subLarger <= startIndex)
                    {
                        break;
                    }
                }
                if(subLower >= subLarger)
                {
                    break;
                }
                Utility.Exchange(inputArray, subLower, subLarger);
            }
            Utility.Exchange(inputArray, startIndex, subLarger);
            return subLarger;
        }
    }
}
