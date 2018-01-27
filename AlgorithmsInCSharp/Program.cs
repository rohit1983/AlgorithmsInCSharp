using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sorting;
using AlgorithmsInCSharp.DynamicProgramming;

namespace AlgorithmsInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            SubString sub = new SubString();
            int outStartPos = -1;
            int length = sub.FindMaxCommonSubstring("RohitChauhanJS", "JainChauhanSingh", out outStartPos);
            int outTow = -1;
            Console.WriteLine("RohitChauhanJS".Substring(outStartPos, length));
            int checkTow = sub.FindMaxCommonSubstring("TooOld", "OldIGold", out outTow);
            if(checkTow >= 1)
            {
                string sbr = "TooOld".Substring(outTow, checkTow);
                Console.WriteLine(sbr);
            }
            int outTthree = -1;
            int checkThree = sub.FindMaxCommonSubstring("ChRohit", "Chauhan", out outTthree);
            if (checkThree >= 1)
            {
                string sbr2 = "ChRohit".Substring(outTthree, checkThree);
                Console.WriteLine(sbr2);
            }
            //remove null elements of array in beginning
            IComparable[] inputArray = {'S', 'O', 'R', 'T', 'E', 'X', 'A', 'M', 'P', 'L', 'E' };
            IComparable[] inputArrayHeap = { null, 'S', 'O', 'R', 'T', 'E', 'X', 'A', 'M', 'P', 'L', 'E' };
            //TODO Add tests for below
            IComparable[] inputArraySorted = { null, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            IComparable[] inputArrayReverseSorted = { null, "Zeb", "Yam", "XI" };
            IComparable[] inputArraySingle = { null, 0 };
            IComparable[] inputArrayEmpty = { };
            IComparable[] inputArrayDuplicates = { null, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            MergeSortBU sortBU = new MergeSortBU();
            sortBU.SortBU(inputArray);
            QuickSortThreeWay.Sort(inputArray);
            HeapSort.Sort(inputArrayHeap);
            HeapSort.Sort(inputArraySorted);
            HeapSort.Sort(inputArrayReverseSorted);
            HeapSort.Sort(inputArraySingle);
            HeapSort.Sort(inputArrayEmpty);
            HeapSort.Sort(inputArrayDuplicates);
            IComparable[] inputArrayN = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            IComparable NthElement = Utility.GetNthElement(inputArrayN, 1);

            Console.ReadLine();
        }
    }
}
