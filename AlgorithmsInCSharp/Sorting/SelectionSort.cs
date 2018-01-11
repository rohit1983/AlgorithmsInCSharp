using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class SelectionSort
    {
        public IComparable[] Sort(IComparable[] inputArray)
        {
            int length = inputArray.Length;
            for(int i = 0;i < length;i++)
            {
                int min = i;
                for(int j = i+1;j < length;j++)
                {
                    if(inputArray[j].CompareTo(inputArray[i]) < 0)
                    {
                        min = j;
                    }
                }
                Utility.Exchange(inputArray, i, min);
            }
            return inputArray;
        }
    }
}
