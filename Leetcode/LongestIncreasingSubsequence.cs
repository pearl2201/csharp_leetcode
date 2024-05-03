// https://leetcode.com/problems/longest-increasing-subsequence/description/
//Given an integer array nums, return the length of the longest strictly increasing 
//subsequence
//.



//Example 1:

//Input: nums = [10, 9, 2, 5, 3, 7, 101, 18]
//Output: 4
//Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
//Example 2:

//Input: nums = [0, 1, 0, 3, 2, 3]
//Output: 4
//Example 3:

//Input: nums = [7, 7, 7, 7, 7, 7, 7]
//Output: 1



//Constraints:

//1 <= nums.length <= 2500
//- 104 <= nums[i] <= 104
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            
            int[] maxLength = new int[nums.Length];
            int finalResult = -1;
            for(int i = 0; i< nums.Length; i++)
            {
                int maxLengthItem = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {

                        maxLengthItem = Math.Max(maxLengthItem, maxLength[j]);
                    }
                }
                maxLengthItem++;
                finalResult = Math.Max(finalResult, maxLengthItem);
                maxLength[i] = maxLengthItem;
            }

            return finalResult;
        }
    }
}
