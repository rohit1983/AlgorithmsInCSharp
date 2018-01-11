using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayBased
{
    /// <summary>
    /// 
    /// </summary>
    public class QuickFind
    {
        private int nComponents;
        private int[] sArray;
        public QuickFind(int ncomponents)
        {
            sArray = new int[ncomponents];
            for(int i =0;i < ncomponents;i++)
            {
                sArray[i] = i;
            }
            nComponents = ncomponents;
        }

        public int Count()
        {
            return nComponents;
        }

        public bool IsConnected(int compOne,int compTwo)
        {
            return Find(compOne) == Find(compTwo);
        }

        public int Find(int comp)
        {
            return sArray[comp];
        }

        public void Union(int compOne,int compTwo)
        {
            int c1 = Find(compOne);
            int c2 = Find(compTwo);
            if(c1 == c2)
            {
                return;
            }
            for(int i =0;i < sArray.Length;i++)
            {
                if(sArray[i] == c1)
                {
                    sArray[i] = c2;
                }
            }
            nComponents--;
        }
    }
}
