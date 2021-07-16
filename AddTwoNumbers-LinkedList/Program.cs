using System;

namespace AddTwoNumbers_LinkedList
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
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 9, 9, 9, 9, 9, 9, 9 };
            ListNode head1 = InsertIntoLinkedList(arr1);
            int[] arr2 = { 9, 9, 9, 9 };
            ListNode head2 = InsertIntoLinkedList(arr2);
            ListNode sumLists = AddTwoNumbers(head1,head2);
            parseLinkedList(sumLists);

        }
        public static ListNode InsertIntoLinkedList(int[] arr)
        {
            if (arr.Length < 1)
                return null;
            ListNode head = new ListNode(arr[0]);
            ListNode node = head;
            for (int i = 1; i < arr.Length; i++)
            {
                node.next = new ListNode(arr[i]);
                node = node.next;
            }
            return head;

        }
        public static void parseLinkedList(ListNode n)
        {
            while (n != null)
            {
                Console.WriteLine(n.val);
                n = n.next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int sum, carry=0;
            sum = l1.val+l2.val;
            carry = sum >= 10 ? 1 : 0;
            sum = sum >= 10 ? sum - 10 : sum;
            ListNode head = new ListNode(sum);
            ListNode curr = head;
            l1 = l1.next;
            l2= l2.next;
            while(l1!=null && l2 != null)
            {
                sum = l1.val + l2.val + carry;
                carry = sum >= 10 ? 1 : 0;
                sum = sum >= 10 ? sum - 10 : sum;
                curr.next = new ListNode(sum);
                curr = curr.next;
                l1 = l1.next;
                l2 = l2.next;
            }
            if (l1 != null)
            {
                while (l1 != null)
                {
                    sum = l1.val + carry;
                    carry = sum >= 10 ? 1 : 0;
                    sum = sum >= 10 ? sum - 10 : sum;
                    curr.next = new ListNode(sum);
                    curr = curr.next;
                    l1 = l1.next;
                }
            }
            if (l2 != null)
            {
                while (l2 != null)
                {
                    sum = l2.val + carry;
                    carry = sum >= 10 ? 1 : 0;
                    sum = sum >= 10 ? sum - 10 : sum;
                    curr.next = new ListNode(sum);
                    curr = curr.next;
                    l2 = l2.next;
                }
            }
            if (carry != 0)
                curr.next = new ListNode(carry);
            return head;

        }
    }
}
