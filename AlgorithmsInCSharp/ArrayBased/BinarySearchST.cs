using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayBased
{
    public class BinarySearchST<TKey,TValue> where TKey:IComparable
    {
        private int Size;
        private TKey[] tkeys;
        private TValue[] values;
        //we can design this for arbitrary capacity but there are performance problems for array resizing
        //in practical situations hence other structures ,BST and HashTable, are preferred
        public BinarySearchST(int capacity)
        {
            tkeys = new TKey[capacity];
            values = new TValue[capacity];
        }
        public TValue Get(TKey key)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Table is empty");
            }
            int rank = Rank(key);
            if(rank < Size && tkeys[rank].CompareTo(key) == 0)
            {
                return values[rank];
            }
            throw new InvalidOperationException("Key Not Found");
        }
        public bool IsEmpty()
        {
            return Size == 0;
        }
        public int GetSize()
        {
            return Size;
        }
        public void Put(TKey key,TValue value)
        {
            int rank = Rank(key);
            if(rank < Size && tkeys[rank].CompareTo(key) == 0)
            {
                values[rank] = value;
            }
            else
            {
                for(int i = Size;i > rank;i--)
                {
                    tkeys[i] = tkeys[i - 1];
                    values[i] = values[i - 1];
                }
                tkeys[rank] = key;
                values[rank] = value;
                Size++;
            }
        }
        //returns the posn of key or such that n values are smaller than key
        private int Rank(TKey key)
        {
            int startIndex = 0;
            int endIndex = tkeys.Length - 1;
            while(startIndex <= endIndex)
            {
                int middle = startIndex + endIndex - startIndex / 2;
                int cmp = key.CompareTo(tkeys[middle]);
                if(cmp == 0)
                {
                    return middle;
                }
                else if(cmp > 0)
                {
                    startIndex = middle + 1;
                }
                else
                {
                    endIndex = middle - 1;
                }
            }
            return startIndex;
        }

    }
}
