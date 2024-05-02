using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LongestPalindrome
    {
        public void Solve()
        {
            TextReader textReader = new StreamReader("./assets/LongestPalindrome.txt");
            int testCase = int.Parse(textReader.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                string s = textReader.ReadLine();
                string anwser = textReader.ReadLine();
                string result = Sol(s);
                Console.WriteLine($"{s} -> {result} vs {anwser}");
            }
        }

        private LongestPalindromicResult[,] map;
        public string Sol(string s)
        {
            map = new LongestPalindromicResult[s.Length, s.Length];

            //return LongestPalindromeRecusive(s, 0, s.Length - 1).Value;
            return LongestPalindromeDpTable(s);
        }

        public string LongestPalindromeExpand(string s)
        {
            string ret = "";
            for (int i = 0; i < s.Length; i++)
            {
                var l = i;
                var u = i;
                while (l >= 0 && u <= s.Length - 1 && s[l] == s[u])
                {
                    if (u - l + 1 > ret.Length)
                    {
                        ret = s.Substring(l, u - l + 1);
                    }
                    l--;
                    u++;
                }

                l = i;
                u = i + 1;
                while (l >= 0 && u <= s.Length - 1 && s[l] == s[u])
                {
                    if (u - l + 1 > ret.Length)
                    {
                        ret = s.Substring(l, u - l + 1);
                    }
                    l--;
                    u++;
                }
            }
            return ret;
        }
        public LongestPalindromicResult LongestPalindromeRecusive(string s, int i, int j)
        {
            if (map[i, j] != null)
            {
                return map[i, j];
            }
            //Console.WriteLine($"Check Palindsome: {i} - {j} - {s.Substring(i, j - i + 1)}");
            if (i > j)
            {
                return new LongestPalindromicResult
                {
                    IsPalindromic = PalindromicKind.Empty,
                    Value = ""
                };
            }

            if (i == j)
            {
                map[i, j] = new LongestPalindromicResult
                {
                    IsPalindromic = PalindromicKind.Self,
                    Value = s[i].ToString()
                };
                return map[i, j];
            }
            else if (s[i] == s[j] && i + 1 == j)
            {
                map[i, j] = new LongestPalindromicResult
                {
                    IsPalindromic = PalindromicKind.Self,
                    Value = s[i].ToString() + s[j].ToString()
                };
                return map[i, j];

            }
            else if (i + 1 == j)
            {
                return new LongestPalindromicResult
                {
                    IsPalindromic = PalindromicKind.Empty,
                    Value = s[i].ToString()
                };
            }
            var sub = LongestPalindromeRecusive(s, i + 1, j - 1);
            //Console.WriteLine($"Palindrome {i + 1} - {j - 1} is {sub.Value}, {sub.IsPalindromic}");
            if (s[i] == s[j] && sub.IsPalindromic == PalindromicKind.Self)
            {
                map[i, j] = new LongestPalindromicResult
                {
                    IsPalindromic = PalindromicKind.Self,
                    Value = s[i] + sub.Value + s[j]
                };
                return map[i, j];
            }

            var sub1 = LongestPalindromeRecusive(s, i, j - 1);

            var sub2 = LongestPalindromeRecusive(s, i + 1, j);
            //Console.WriteLine($"Palindrome {i} - {j - 1} is {sub1.Value}, {sub.IsPalindromic}");
            //Console.WriteLine($"Palindrome {i + 1} - {j} is {sub2.Value}, {sub.IsPalindromic}");
            if (sub1.Value.Length > sub2.Value.Length)
            {
                map[i, j] = new LongestPalindromicResult
                {
                    IsPalindromic = PalindromicKind.Sub,
                    Value = sub1.Value
                };
                return map[i, j];
            }
            else
            {
                map[i, j] = new LongestPalindromicResult
                {
                    IsPalindromic = PalindromicKind.Sub,
                    Value = sub2.Value
                };
                return map[i, j];
            }
        }

        public string LongestPalindromeDpTable(string s)
        {
            bool[,] map = new bool[s.Length, s.Length];
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                map[i, i] = true;
            }
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    map[i - 1, i] = true;
                    if (end - start < 1)
                    {
                        start = i - 1;
                        end = i;

                    }
                }

                for (int j = 0; j < i; j++)
                {
                    if (s[j] == s[i] && map[j + 1, i - 1])
                    {
                        map[j, i] = true;
                        if (i - j > end - start)
                        {
                            end = i;
                            start = j;
                        }

                    }
                }
            }
            return s.Substring(start, end - start + 1);
        }
    }

    public class LongestPalindromicResult
    {
        public PalindromicKind IsPalindromic { get; set; }
        public string Value { get; set; }

    }

    public enum PalindromicKind
    {
        Self,
        Sub,
        Empty
    }
}



