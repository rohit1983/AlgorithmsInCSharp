using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayBased
{
    public class WeightedQuickUnion
    {
        private int nComponents;
        private int[] sArray;
        private int[] sz;
        public WeightedQuickUnion(int ncomponents)
        {
            nComponents = ncomponents;
            sArray = new int[nComponents];
            sz = new int[nComponents];
            for(int i=0;i<ncomponents;i++)
            {
                sArray[i] = i;
                sz[i] = 1;
            }
        }

        public int Count()
        {
            return nComponents;
        }

        public int Find(int cmp)
        {
            while(sArray[cmp] != cmp)
            {
                cmp = sArray[cmp];
            }
            return cmp;
        }

        public bool IsConnected(int cmpOne,int cmpTwo)
        {
            return Find(cmpOne) == Find(cmpTwo);
        }

        public void Union(int cmpOne,int cmpTwo)
        {
            int rootOne = sArray[cmpOne];
            int rootTwo = sArray[cmpTwo];
            if(rootOne == rootTwo)
            {
                return;
            }
            if(sz[rootTwo] >= sz[rootOne])
            {
                sArray[rootOne] = rootTwo;
                sz[rootTwo] += sz[rootOne];
            }
            else
            {
                sArray[rootTwo] = rootOne;
                sz[rootOne] += sz[rootTwo];
            }
        }
    }
}
