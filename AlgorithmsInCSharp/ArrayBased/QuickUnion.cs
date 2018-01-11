using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayBased
{
    public class QuickUnion
    {
        private int nComponents;
        private int[] sArray;

        public QuickUnion(int ncomponents)
        {
            this.nComponents = ncomponents;
            sArray = new int[ncomponents];
            for(int i=0;i < ncomponents;i++)
            {
                sArray[i] = i;
            }
        }

        public int Count()
        {
            return nComponents;
        }

        public bool IsConnected(int cmpOne,int cmpTwo)
        {
            return Find(cmpOne) == Find(cmpTwo);
        }

        public int Find(int component)
        {
            while(sArray[component] != component)
            {
                component = sArray[component];
            }
            return component;
        }

        public void Union(int cmpOne,int cmpTwo)
        {
            int rootOne = Find(cmpOne);
            int rootTwo = Find(cmpTwo);
            if(rootOne == rootTwo)
            {
                return;
            }
            sArray[rootOne] = rootTwo;
            nComponents--;
        }
    }
}
