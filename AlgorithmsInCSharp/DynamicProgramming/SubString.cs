using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsInCSharp.DynamicProgramming
{
    public class SubString
    {
        int[,] maxCommonSubstring = null;

        public int FindMaxCommonSubstring(string firststring,string secondstring,out int startPosition)
        {
            int length = 0;
            startPosition = -1;
            int lengthFirst = firststring.Length;
            int lengthSecond = secondstring.Length;
            maxCommonSubstring = new int[lengthFirst + 1,lengthSecond + 1];
            for(int i=0;i <= lengthFirst;i++)
            {
                maxCommonSubstring[i, 0] = 0;
            }
            for(int i=0;i <= lengthSecond;i++)
            {
                maxCommonSubstring[0, i] = 0;
            }
            for(int i = 1;i <= lengthFirst;i++)
            {
                for(int j = 1;j <= lengthSecond;j++)
                {
                    if(firststring[i-1] == secondstring[j-1])
                    {
                        maxCommonSubstring[i, j] = maxCommonSubstring[i - 1, j - 1] + 1;
                        if(maxCommonSubstring[i,j] > length)
                        {
                            length = maxCommonSubstring[i, j];
                            startPosition = i - length;
                        }
                    }
                    else
                    {
                        maxCommonSubstring[i, j] = 0;
                    }
                }
            }
            return length;

        }
    }
}
