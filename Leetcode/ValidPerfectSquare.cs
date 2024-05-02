using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ValidPerfectSquare
    {
        public bool IsPerfectSquare(int num)
        {
            float temp = num;

            int x = num;
            while (true)
            {
                var newTemp = NewtonSquareRoot(temp, num);
                if (newTemp * newTemp - num <= 1 && newTemp * newTemp - num >= 0 || (int)(newTemp) == x)
                {
                    x = (int)newTemp;
                    break;
                }
                else
                {
                    x = (int)newTemp;
                    temp = newTemp;
                }
            }
            return x * x == num;
        }

        public float NewtonSquareRoot(float a, float fxn)
        {
            return 0.5f * (a + fxn / a);
        }

        public bool IsPerfectSquareBinary(int num)
        {
            int start = 0;
            int end = num;
            while (true)
            {
                var mid = (end + start) / 2;
                if (mid * mid >=num)
                {

                }    
            }
        }
    }
}
