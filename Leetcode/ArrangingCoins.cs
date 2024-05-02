
//https://leetcode.com/problems/arranging-coins/
namespace Leetcode
{
    public class ArrangingCoins
    {
        public int Solve(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int start = 0;
            int end = n;
            while (true)
            {
                var mid = start + (end - start) / 2;
                long sqrMid = mid * ((long)mid + 1) / 2;
                if (sqrMid == n)
                {
                    return mid;
                }
                else if (sqrMid > n)
                {
                    end = mid;
                }
                else
                {
                    start = mid;
                }

                if (end - start == 1 || end == start)
                {
                    return start;
                }
            }
        }
    }
}
