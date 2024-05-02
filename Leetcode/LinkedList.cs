public class LinkedList
{




    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class ListNodeHelper
    {
        public static void PrintListNode(ListNode node)
        {
            List<int> nodes = new List<int>() { node.val };
            while (node != null)
            {
                node = node.next;
                if (node != null)
                    nodes.Add(node.val);
            }

            Console.WriteLine(string.Join(",", nodes.ToArray()));
        }

        public static ListNode ConvertArrToListNode(int[] arr)
        {
            ListNode start = new ListNode(arr[0], null);
            ListNode prevNode = start;
            for (int i = 1; i < arr.Length; i++)
            {
                ListNode tmp = new ListNode(arr[i], null);
                prevNode.next = tmp;
                prevNode = tmp;
            }

            return start;
        }
    }

    public class Solution
    {
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {

            ListNode tmpNode = list1;
            while (tmpNode.val != a)
            {
                tmpNode = tmpNode.next;
            }
            ListNode nodeA = tmpNode;
            nodeA.next = list2;
            while (tmpNode.val != b)
            {
                tmpNode = tmpNode.next;
            }
            ListNode nodeB = tmpNode;

            tmpNode = nodeA;
            while (tmpNode.next != null)
            {
                tmpNode = tmpNode.next;
            }
            tmpNode.next = nodeB;
            return list1;
        }
    }
}