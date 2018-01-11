using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class MergeSortBU : MergeSort
    {
        public void SortBU(IComparable[] inputArray)
        {
            int length = inputArray.Length;
            auxArray = new IComparable[length];
            for(int sz=1;sz < length;sz = sz+sz)
            {
                for(int sub=0;sub < length-sz;sub += sz+sz)
                {
                    Merge(inputArray, sub, sub + sz - 1, Math.Min(sub + sz + sz - 1, length-1));
                }
            }
        }
    }
}
