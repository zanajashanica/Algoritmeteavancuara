using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritme
{
    class Program
    {
        public const int mod = 1000000007;
        public static long[,] vec = new long[2500, 50000];
        public static long answer = 0;
        static void Main(string[] args)
        {
            DivFree rezultati = new DivFree();
            Console.WriteLine(rezultati.dfcount(3, 2));
        }

        public class DivFree
        {
            public long dfcount(int n, int k)
            {
                for (int i = 1; i <= k; i++)
                {
                    vec[1, i] = 1;
                }

                for (int pozita = 2; pozita <= n; pozita++)
                {
                    long sum = 0;
                    for (int i = 1; i <= k; i++)
                    {
                        sum = (sum + vec[pozita - 1, i]) % mod;
                    }
                    for (int i = 1; i <= k; i++)
                    {
                        vec[pozita, i] = (vec[pozita, i] + sum);
                        for (int j = 2 * i; j <= k; j += i)
                        {
                            vec[pozita, i] = (vec[pozita, i] - vec[pozita - 1, j] + mod) % mod;
                        }
                    }
                }

                for (int i = 1; i <= k; i++)
                {
                    answer = (answer + vec[n, i]) % mod;
                }

                return answer;
            
    }
}

 }
}
