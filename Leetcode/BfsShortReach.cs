using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
//https://www.hackerrank.com/challenges/bfsshortreach/problem?isFullScreen=true

namespace Leetcode
{
    public class BfsShortReach
    {
        /*
    * Complete the 'bfs' function below.
    *
    * The function is expected to return an INTEGER_ARRAY.
    * The function accepts following parameters:
    *  1. INTEGER n
    *  2. INTEGER m
    *  3. 2D_INTEGER_ARRAY edges
    *  4. INTEGER s
    */

        public List<int> bfs(int n, int m, List<List<int>> edges, int s)
        {
            var map = new bool[n, n];
            for (int i = 0; i < edges.Count; i++)
            {
                int u = edges[i][0] - 1;
                int v = edges[i][1] - 1;
                map[u, v] = true;
                map[v, u] = true;
            }

            var current = new List<int>() { s-1 };
            var next = new List<int>();
            var currentStep = 1;

            var result = new int[n];
            for (int i = 0; i< n; i++)
            {
                result[i] = -1;
            }

            while (current.Count > 0)
            {
                for (int i = 0; i< current.Count; i++)
                {
                    int v = current[i];
                    for (int neightboughV = 0; neightboughV < n; neightboughV++ )
                    {
                        if (neightboughV != v && result[neightboughV] == -1 && map[v, neightboughV])
                        {
                            result[neightboughV] = currentStep * 6;
                            next.Add(neightboughV);
                        }
                    }
                }
                current.Clear();
                foreach(var i in next)
                {
                    current.Add(i);
                }
                next.Clear();
                currentStep++;
            }
            var ret = result.ToList();
            ret.RemoveAt(s - 1);
            return ret;
        }




        public BfsShortReach()
        {
            TextWriter textWriter = new StreamWriter("bfsshortreach_answer.txt", true);
            TextReader textReader = new StreamReader("bfsshortreach.txt", true);
            int q = Convert.ToInt32(textReader.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] firstMultipleInput = textReader.ReadLine().TrimEnd().Split(' ');

                int n = Convert.ToInt32(firstMultipleInput[0]);

                int m = Convert.ToInt32(firstMultipleInput[1]);

                List<List<int>> edges = new List<List<int>>();

                for (int i = 0; i < m; i++)
                {
                    edges.Add(textReader.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
                }

                int s = Convert.ToInt32(textReader.ReadLine().Trim());

                List<int> result = bfs(n, m, edges, s);

                textWriter.WriteLine(String.Join(" ", result));
            }

            textWriter.Flush();
            textWriter.Close();
            textReader.Close();
        }
    }
}
