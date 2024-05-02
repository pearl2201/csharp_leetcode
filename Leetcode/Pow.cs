using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class PowSolution
    {
        Dictionary<long, double> map = new Dictionary<long, double>();

        public double MyPow(double x, long n)
        {


            if (n < 0)
            {
                long mn = -n;
                return 1 / MyPow(x, mn);
            }
            else if (n == 0 || x == 1)
            {
                return 1;
            }
            else if (n == 1)
            {
                return x;
            }
            if (map.TryGetValue(n, out var ret))
            {
                return ret;
            }
            Console.WriteLine($"{n}");
            if (n % 2 == 0)
            {
                ret = MyPow(x, n / 2) * MyPow(x, n / 2);
            }
            else
            {
                ret = x * MyPow(x, n / 2) * MyPow(x, n / 2);
            }
            map[n] = ret;
            return ret;
        }
    }
}
