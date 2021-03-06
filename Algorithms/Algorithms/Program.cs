using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //int N = 3;
            //int M = 3;
            var s = Console.ReadLine().Split(' ');
            int M = Int32.Parse(s[0]);
            int N = Int32.Parse(s[1]);
            if (N > M)
            {
                var tmp = N; N = M; M = tmp;
            }
            var x = isCompatible(24, 7, N);
            int max_mask = 1 << N;
            int[] arr = new int[max_mask]; // save number of ways to make a tile with the 
            for (int i = 0; i < max_mask; i++)
                arr[i] = 1;
            for (int t = 1; t < M; t++)
            {
                int[] next = new int[max_mask];
                for (int j = 0; j < max_mask; j++)
                {
                    // count next[j]
                    for (int i = 0; i < max_mask; i++)
                    {
                        if (isCompatible(i, j, N))
                            next[j] += arr[i];
                    }
                }
                arr = next;
            }
            int res = 0;
            for (int i = 0; i < max_mask; i++)
                res += arr[i];
            Console.WriteLine(res);
        }
        public static bool isCompatible(int i, int j, int length)
        {
            var bi = Convert.ToString(i, 2).PadLeft(length, '0');
            var bj = Convert.ToString(j, 2).PadLeft(length, '0');
            for (int t = 0; t < length - 1; t++)
            {
                if ((bi[t] == bi[t + 1]) && (bj[t] == bj[t + 1]) && (bi[t] == bj[t]))
                    return false;
            }
            return true;
        }
    }
}
