using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class QuickSortThreeWay
    {
        public static void Sort(IComparable[] inputArray)
        {
            int length = inputArray.Length;
            new Random().Shuffle(inputArray);
            Sort(inputArray, 0, length - 1);
        }
        private static void Sort(IComparable[] inputArray,int startIndex,int endIndex)
        {
            if(startIndex >= endIndex)
            {
                return;
            }
            int lt = startIndex;
            int i = startIndex+1;
            int gt = endIndex;
            IComparable thvalue = inputArray[startIndex];
            while(i <= gt)
            {
                int cmp = thvalue.CompareTo(inputArray[i]);
                if(cmp > 0)
                {
                    Utility.Exchange(inputArray, lt++, i++);
                }
                else if(cmp < 0)
                {
                    Utility.Exchange(inputArray, i, gt--);
                }
                else
                {
                    i++;
                }
            }
            Sort(inputArray, startIndex, lt - 1);
            Sort(inputArray, gt + 1, endIndex);
        }
    }
}
