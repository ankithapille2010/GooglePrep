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
            int[] arr1 = {-9,3};
            ListNode head1 = InsertIntoLinkedList(arr1);
            int[] arr2 = {5,7};
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
            ListNode curr = null;
            SortedList<int, int> mList = new SortedList<int, int>();

            while (head1 != null && head2 != null)
            {
                int val = 0;
                if (head1.val < head2.val)
                {
                    val = head1.val;
                    head1 = head1.next;
                }
                else
                {
                    val = head2.val;
                    head2 = head2.next;
                }
                if (mList.ContainsKey(val))
                    mList[val]++;
                else
                    mList.Add(val, 1);

            }

            while (head1 != null)
            {
                
                if (mList.ContainsKey(head1.val))
                    mList[head1.val]++;
                else
                    mList.Add(head1.val, 1);
                head1 = head1.next;
            }
            while (head2 != null)
            {
                if (mList.ContainsKey(head2.val))
                    mList[head2.val]++;
                else
                    mList.Add(head2.val, 1);
                head2 = head2.next;
            }


            while (mList.Count != 0) {

                if (head == null)
                {
                    head = new ListNode(mList.Keys[0]);
                    if (mList.Values[0] == 1)
                        mList.Remove(mList.Keys[0]);
                    else
                        mList[mList.Keys[0]]--;
                    curr = head;
                }
                else
                {
                    curr.next = new ListNode(mList.Keys[0]);
                    if (mList.Values[0]==1)
                        mList.Remove(mList.Keys[0]);
                    else
                        mList[mList.Keys[0]]--;
                    curr = curr.next;
                    
                }

            }
        

            return head;
        }
    }
    
}
