using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class Utility
    {
        public static void Exchange(IComparable[] array,int posFrom,int posTo)
        {
            IComparable temp = array[posFrom];
            array[posFrom] = array[posTo];
            array[posTo] = temp;
        }
        /// <summary>
        /// Fisher-Yates algorithm
        /// https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
        /// </summary>
        /// <param name="random"></param>
        /// <param name="array"></param>
        public static void Shuffle(this Random random,IComparable[] array)
        {
            int length = array.Length;
            while(length > 1)
            {
                int number = random.Next(length--);
                IComparable temp = array[length];
                array[length] = array[number];
                array[number] = temp;
            }
        }
        //find nth smallest element. The element returned will have n elements smaller or equal to
        public static IComparable GetNthElement(IComparable[] inputArray,int n)
        {
            new Random().Shuffle(inputArray);
            int startIndex = 0;
            int endIndex = inputArray.Length - 1;
            while(endIndex > startIndex)
            {
                int j = QuickSort.Partition(inputArray, startIndex, endIndex);
                if(j == n)
                {
                    return inputArray[n];
                }
                if(j  > n)
                {
                    endIndex = j-1;
                }
                else
                {
                    startIndex = j + 1;
                }
            }
            return inputArray[n];
        }
    }
}
