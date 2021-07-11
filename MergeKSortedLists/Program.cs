using System;
using System.Collections;
using System.Collections.Generic;

namespace MergeKSortedLists
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
            int[] arr1 = {1,4,5 };
            ListNode head1 = InsertIntoLinkedList(arr1);
            int[] arr2 = {1,3,4 };
            ListNode head2 = InsertIntoLinkedList(arr2);
            int[] arr3 = {2,6 };
            ListNode head3 = InsertIntoLinkedList(arr3);
            ListNode[] lists = { head1, head2, head3 };

            //ListNode mergeHead= MergeLists(head1, head2);
            ListNode mergeHead = MergeKLists(lists);
            parseLinkedList(mergeHead);
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

        public static ListNode MergeKLists(ListNode[] lists)
        {
           
            SortedList<int,int>sList = new SortedList<int,int>();
            foreach(ListNode list in lists)
            {
                ListNode l = list;
                while(l != null)
                {
                    if (sList.ContainsKey(l.val))
                        sList[l.val]++;
                    else
                        sList.Add(l.val,1);
                    l = l.next;

                }
            }
            ListNode head = null;
            ListNode node = null;
            foreach (KeyValuePair<int,int> i in sList)
            {
               
                if (sList.Count < 1)
                    return null;
                int val = i.Key;
                int count = i.Value;
                if (head == null){
                    head = new ListNode(val);
                    count--;
                    node = head;
                }
                for (int j = 0; j < count; j++)
                {
                    node.next = new ListNode(val);
                    node = node.next;
                }                       
            }
            return head;

        }
    }
}
