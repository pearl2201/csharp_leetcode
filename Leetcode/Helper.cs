using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Helper
    {
        public static bool Bfs(int n, bool[,] map, int u, int v)
        {
            bool[] visits = new bool[n];
            Queue<int> currentVerticles = new Queue<int>() { };
            currentVerticles.Enqueue(n);
            while (currentVerticles.Count > 0)
            {
                int currentVerticle = currentVerticles.Dequeue();
                for (int j = 0; j < n; j++)
                {
                    if (!visits[j] && map[currentVerticle, j])
                    {
                        visits[j] = true;
                        currentVerticles.Enqueue(j);
                        if (j == v)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool[,] ConvertInputToMap(int n, List<List<int>> edges)
        {
            var map = new bool[n, n];
            for (int i = 0; i < edges.Count; i++)
            {
                int u = edges[i][0] - 1;
                int v = edges[i][1] - 1;
                map[u, v] = true;
                map[v, u] = true;
            }
            return map;
        }
    }
}
