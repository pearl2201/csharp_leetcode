using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinkedList;

namespace Leetcode
{
    public class PalindromeLinkedList
    {
        public bool IsPalindrome(ListNode head)
        {
            int n = 0;
            ListNode tail = new ListNode()
            {
                val = head.val
            };
            ListNode tmpHead = head;
            while (tmpHead != null)
            {
                n++;
                tmpHead = tmpHead.next;
                if (tmpHead != null)
                {
                    tail = new ListNode(0, tail);
                    tail.val = tmpHead.val;
                    
                    ListNodeHelper.PrintListNode(tmpHead);
                }
                  
            }
            ListNodeHelper.PrintListNode(head);
            ListNodeHelper.PrintListNode(tail);
            for (int i = 0; i < n / 2; i++)
            {
                if (tail.val == head.val)
                {
                    tail = tail.next;
                    head = head.next;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }
    }
}
