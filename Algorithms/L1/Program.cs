using System;
using System.Collections.Generic;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = Int64.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(N));
        }
        
        public static int Calculate(long N)
        {
            if (N < 3) return 0;
            if (N == 3) return 1;
            if (N % 2 == 0) return 2 * Calculate(N / 2);
            var k = N / 2;
            return Calculate(k) + Calculate(k + 1);
        }
    }
}
