using System.Collections.Generic;
using System.Drawing;

namespace LinkedListTest
{
    internal class LinkedListTest
    {
        static void Main(string[] args)
        {
            // 실습 1 ~ 3
            /*AddNums nums = new AddNums();

            nums.Add(1);
            nums.Add(-2);
            nums.Add(3);
            nums.Add(-4);
            nums.Add(5);
            nums.Add(-6);*/
        }
    }

    // 실습 1 ~ 3
    /*public class AddNums
    {
        LinkedList<int> numbers;

        LinkedListNode<int> node;

        public AddNums()
        {
            numbers = new LinkedList<int>();
        }

        public void Add(int num)
        {
            if (num < 0)
            {
                numbers.AddFirst(num);
            }
            else if (num > 0)
            {
                numbers.AddLast(num);
            }
            else
            {
                Console.Writeline("0은 넣을 수 없습니다.");
            }

            PrintNums();
        }

        public void PrintNums()
        {
            foreach (int num in numbers) 
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
    }*/

    // 실습 4 요세푸스 순열 문제
    public class JosephusPermu
    {
        int size;
        int k;

        LinkedList<int> numLinkedList;
        LinkedListNode<int> node;

        public JosephusPermu(int size, int k)
        {
            this.size = size;
            this.k = k;
            numLinkedList = new LinkedList<int>();
            //node.ValueRef = numLinkedList.First;
            
        }

        public void Set()
        {
            /*LinkedListNode<int> nodeAfter;
            LinkedListNode<int> nodeBfter;

            nodeAfter = new LinkedListNode<int>(1);
            nodeBfter = new LinkedListNode<int>(size);*/
            

            for (int i = 2; i < size; i++) 
            {
                numLinkedList.AddLast(i);
            }


        }

        public void GetAnswer()
        {
            Console.Write("< ");
            while (numLinkedList.Count > 0) 
            {
                Console.Write($"{numLinkedList.} ");
                numLinkedList.Remove(k);
            }
        }

    }
}
