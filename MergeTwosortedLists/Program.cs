using System;
using System.Collections.Generic;

namespace MergeTwosortedLists
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
            int[] arr1 = {1,2,3 };
            ListNode head1 = InsertIntoLinkedList(arr1);
            int[] arr2 = {1,3,4 };
            ListNode head2 = InsertIntoLinkedList(arr2);
            ListNode mergehead = MergeLists(head1, head2);
            parseLinkedList(mergehead);

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



        private static ListNode MergeLists(ListNode head1, ListNode head2)
        {
            ListNode head = null;
            SortedList<int, int> mList = new SortedList<int, int>();
           
            while (head1 != null || head2 != null)
            {
                int val = head1.val < head2.val ? head1.val : head2.val;
                if (mList.ContainsKey(val))
                    mList[val]++;
                else
                    mList.Add(val,1);
                head1 = head1.next;
                head2 = head2.next;
            }
            if (head1 != null)
            {
                if (mList.ContainsKey(head1.val))
                    mList[head1.val]++;
                else
                    mList.Add(head1.val, 1);
                head1 = head1.next;
            }
            if (head2 != null)
            {
                if (mList.ContainsKey(head2.val))
                    mList[head2.val]++;
                else
                    mList.Add(head2.val, 1);
                head2 = head2.next;
            }

            foreach (KeyValuePair<int,int> l in mList)
            {
                for (int i= 0;i <l.Value;i++)
                Console.Write(l.Key+ " ");
            }

            return head;
        }
    }
    
}
