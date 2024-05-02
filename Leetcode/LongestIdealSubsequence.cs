using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    // https://leetcode.com/problems/longest-ideal-subsequence/description/
    public class LongestIdealSubsequence
    {

        public void Solve()
        {
            TextReader textReader = new StreamReader("./assets/LongestIdealSubsequence.txt");
            int testCase = int.Parse(textReader.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                string s = textReader.ReadLine();
                int k = int.Parse(textReader.ReadLine());
                int anwser = int.Parse(textReader.ReadLine());
                int result = LongestIdealString2(s, k);
                Console.WriteLine($"{result} vs {anwser}");
            }
        }

        public int LongestIdealString(string s, int k)
        {
            Node[,] map = new Node[s.Length, s.Length];
            int m = 0;
            for (int i = 0; i < s.Length; i++)
            {
                map[0, i] = new Node
                {
                    LastValue = s[0],
                    Length = 0
                };
            }
            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i == j)
                    {
                        map[i, j] = new Node
                        {
                            LastValue = s[i],
                            Length = 0
                        };
                        continue;
                    }
                    bool isSatisfies = Math.Abs(s[i] - map[i - 1, j].LastValue) <= k;
                    if (!isSatisfies)
                    {
                        map[i, j] = new Node
                        {
                            LastValue = map[i - 1, j].LastValue,
                            Length = map[i - 1, j].Length
                        };
                    }
                    else
                    {
                        map[i, j] = new Node
                        {
                            LastValue = s[i],
                            Length = map[i - 1, j].Length + 1
                        };
                    }
                    m = Math.Max(m, map[i, j].Length);
                }
            }

            return m + 1;
        }

        public int LongestIdealString2(string s, int k)
        {
            int[] snapshot = new int[s.Length];
            int ret = 0;
            for (int i = 1; i < s.Length; i++)
            {
                bool found = false;
                int max = -1;
                for (int j = i - 1; j   >= 0; j--)
                {
                    if (Math.Abs(s[i] - s[j]) <= k)
                    {
                        max = Math.Max(max, snapshot[j]);
                        found = true;
                    }
                }

                if (found)
                {
                    snapshot[i] = max + 1;
                }
                else
                {
                    snapshot[i] = 0;
                }
                ret = Math.Max(snapshot[i], ret);
            }
            return ret + 1;
        }

        public class Node
        {
            public char LastValue { get; set; }

            public int Length { get; set; }
        }
    }
}
