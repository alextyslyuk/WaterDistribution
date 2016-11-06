using System;
using System.Collections.Generic;

namespace WaterInGlasses
{
    internal class Permutations
    {
        private static void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static List<int[]> GetPer(int[] list)
        {
            int x = list.Length - 1;
            var outList = new List<int[]>();
            GetPer(list, 0, x, ref outList);
            return outList;
        }

        private static void GetPer(int[] inList, int k, int m, ref List<int[]> outList)
        {
            if (k == m)
            {
                outList.Add((int[])inList.Clone());
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref inList[k], ref inList[i]);
                    GetPer(inList, k + 1, m, ref outList);
                    Swap(ref inList[k], ref inList[i]);
                }
        }
    }
}