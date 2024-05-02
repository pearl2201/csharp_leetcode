using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MinimumFallingPathSumIISolution
    {
        public void Solve()
        {
            TextReader textReader = new StreamReader("./assets/MinimumFallingPathSumII.txt");
            int testCase = int.Parse(textReader.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                int n = int.Parse(textReader.ReadLine());
                var k = textReader.ReadLine().Split().Select(x => int.Parse(x)).Chunk(n).ToArray();
                int anwser = int.Parse(textReader.ReadLine());
                int result = MinFallingPathSum(k);
                Console.WriteLine($"{result} vs {anwser}");
            }
        }

        public int MinFallingPathSum(int[][] grid)
        {
            return DpBottomUp(grid);
        }

        public int DpBottomUp(int[][] grid)
        {
            int n = grid.Length;
            int[] lastM = new int[n];

            for (int i = 0; i < n; i++)
            {
                lastM[i] = grid[0][i];
            }
            int[] curr = new int[n];
            for (int i = 1; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {


                    curr[j] = int.MaxValue;
                    for (int k = 0; k < n; k++)
                    {
                        if (k != j)
                        {
                            curr[j] = Math.Min(curr[j], lastM[k]);
                        }

                    }


                    curr[j] = curr[j] + grid[i][j];
                }

                for (int j = 0; j < n; j++)
                {
                    lastM[j] = curr[j];
                }
            }

            int ret = lastM[0];
            for (int i = 1; i < n; i++)
            {
                if (ret > lastM[i])
                {
                    ret = lastM[i];
                }
            }

            return ret;
        }
    }
}
