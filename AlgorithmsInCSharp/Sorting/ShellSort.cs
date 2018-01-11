using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class ShellSort
    {
        public static void Sort(IComparable[] inputArray)
        {
            int h = 1;
            int length = inputArray.Length;
            while(h <= length/3)
            {
                h = 3 * h + 1;
            }
            while(h >= 1)
            {
                for(int i = h;i < length;i++)
                {
                    for(int j = i;(j-h) >= 0 && inputArray[j].CompareTo(inputArray[j-h]) < 0;j -= h)
                    {
                        Utility.Exchange(inputArray, j, j - h);
                    }
                }
                h = h / 3;
            }
        }
    }
}
