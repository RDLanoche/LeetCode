using System;
using System.Collections.Generic;

namespace leetcode
{
    public static class LinkedListAddition
    {
        public static void AdditionOfLinkedLists()
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());

            string num1s = Convert.ToString(num1);
            string num2s = Convert.ToString(num2);

            List<int> num1arr = new List<int>();
            List<int> num2arr = new List<int>();

            foreach (char c in num1s)
            {
                num1arr.Add(Convert.ToInt32(c) - 48);
            }
            foreach (char c in num2s)
            {
                num2arr.Add(Convert.ToInt32(c) - 48);
            }

            LinkedList<int> linkedListNum1 = new LinkedList<int>(num1arr);
            LinkedList<int> linkedListNum2 = new LinkedList<int>(num2arr);

            LinkedList<int> sumList = SumLinkedLists(new LinkedList<int>(), linkedListNum1, linkedListNum2, 0, linkedListNum1.Last, linkedListNum2.Last);
            foreach (int i in sumList)
            {
                Console.WriteLine(i);
            }
        }

        static LinkedList<int> SumLinkedLists(LinkedList<int> sumList, LinkedList<int> linkedList1,
            LinkedList<int> linkedList2, int surplus, LinkedListNode<int> node1, LinkedListNode<int> node2)
        {
            if (node1 == null || node2 == null)
            {
                if (node1 == null && node2 == null)
                {
                    return null;
                }
                if (node1 == null)
                {
                    sumList.AddFirst(node2.Value + surplus);
                    SumLinkedLists(sumList, linkedList1, linkedList2, 0, node1, node2.Previous);
                    return sumList;
                }
                if (node2 == null)
                {
                    sumList.AddFirst(node1.Value + surplus);
                    SumLinkedLists(sumList, linkedList1, linkedList2, 0, node1.Previous, node2);
                    return sumList;
                }
            }

            int nodeSum = node1.Value + node2.Value + surplus;
            if (nodeSum > 9)
            {
                sumList.AddFirst(nodeSum - 10);
                surplus = 1;
            }
            else
            {
                sumList.AddFirst(nodeSum);
                surplus = 0;
            }
            SumLinkedLists(sumList, linkedList1, linkedList2, surplus, node1.Previous, node2.Previous);

            return sumList;
        }
    }
}
