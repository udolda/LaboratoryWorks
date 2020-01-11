using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8_A_n_CA_SNG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int count = 0;
            Console.Write("Введите число: ");
            int r = int.Parse(Console.ReadLine());
            while (count < 10)
            {
                if (Function.SimplicityTest(r, new Random().Next(10)) && Function.LyukaTest(r))
                {
                    Console.WriteLine(r);
                    count++;
                }
                r++;
            }
            Console.ReadKey();
        }

    }

    class Function
    {
        public static bool SimplicityTest(BigInteger n, int iter)
        {
            var num = new List<BigInteger>();
            Random rand = new Random();
            for (var i = 2; i < n; i++)
            {
                num.Add(i);
            }

            for (int i = 0; i < iter; i++)
            {
                BigInteger a = num[(rand.Next(2, (int)n - 1 - i)) % (int)num.Count];
                num.Remove(a);
                if (NOD3((int)a, (int)n) != 1)
                {
                    return false;
                }
                else
                {
                    if (ModPow(a, n - 1) % n != 1)
                    {
                        return false;
                    }
                }
            }
            return true;

        }
        
        private static int NOD3(int a, int b)
        {
            int k = 1;
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }
                while (a % 2 == 0) a /= 2;
                while (b % 2 == 0) b /= 2;
                if (a >= b) a -= b; else b -= a;
            }
            return Math.Max(b, a) * k;
        }

        private static BigInteger ModPow(BigInteger a, BigInteger b)
        {
            int n = (int)b + 1;
            BigInteger res = a;
            for (int i = 1; i < n - 1; i++)
            {
                res *= a;
                res %= n;
            }
            return res;

        }

        private static BigInteger ModPow(BigInteger a, BigInteger b, BigInteger n)
        {
            BigInteger res = a;
            for (int i = 1; i < b; i++)
            {
                res *= a;
                res %= n;
            }
            return res;

        }

        private static List<BigInteger> GetDivided(BigInteger n)
        {
            List<BigInteger> res = new List<BigInteger>();
            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0) res.Add(i);
            }
            return res;
        }

        public static bool LyukaTest(BigInteger n)
        {
            for (int i = 0; i < (int)n - 1; i++)
            {
                if (SimplicityTest(n, (int)n - 2))
                {
                    foreach (var item in GetDivided(n - 1))
                    {
                        if (ModPow(i, (n - 1) / item, n) != 1) return true;
                    }
                }
                else return false;
            }
            return true;
        }

    }
}
