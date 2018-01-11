using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class InsertionSort
    {
        public static IComparable[] Sort(IComparable[] inputArray)
        {
            int length = inputArray.Length;
            for(int i=1;i<length;i++)
            {
                for(int j = i;j >= 0 && inputArray[j].CompareTo(inputArray[j-1]) < 0;j--)
                {
                    Utility.Exchange(inputArray, j, j - 1);
                }
            }
            return inputArray;
        }
    }
}
