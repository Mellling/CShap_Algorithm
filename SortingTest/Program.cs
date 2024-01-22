using System.Collections.Generic;
using System.ComponentModel;

namespace SortingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<int> selectionList = new List<int>();
            List<int> insertionList = new List<int>();
            List<int> bubbleList = new List<int>();
            List<int> mergeList = new List<int>();
            List<int> quickList = new List<int>();
            List<int> heapList = new List<int>();

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < 20; i++)
            {
                int rand = random.Next() % 100;
                Console.Write(string.Format("{0} ", rand));

                selectionList.Add(rand);
                insertionList.Add(rand);
                bubbleList.Add(rand);
                heapList.Add(rand);
                mergeList.Add(rand);
                quickList.Add(rand);
            }
            Console.WriteLine();

            Console.WriteLine("선택 정렬 결과 : ");
            SelectionSort(selectionList);
            foreach (int i in selectionList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();


            Console.WriteLine("삽입 정렬 결과 : ");
            InsertionSort(insertionList);
            foreach (int i in insertionList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();


            Console.WriteLine("버블 정렬 결과 : ");
            BubbleSort(bubbleList);
            foreach (int i in bubbleList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();


            Console.WriteLine("합병 정렬 결과 : ");
            MergeSort(mergeList, 0, mergeList.Count - 1);
            foreach (int i in mergeList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();


            Console.WriteLine("퀵 정렬 결과 : ");
            QuickSort(quickList, 0, quickList.Count - 1);
            foreach (int i in quickList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();


            Console.WriteLine("힙 정렬 결과 : ");
            HeapSort(heapList);
            foreach (int i in heapList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();
        }

        // 1. 선택정렬 구현
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int minIndex = i;
                for(int j = i + 1;  j < list.Count; j++)
                {
                    if (list[minIndex] > list[j])
                    {
                        minIndex = j;
                    }
                }
                Swap(list, i, minIndex);
            }
        }

        // 2. 삽입 정렬
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++) 
            {
                for (int j = i; j >= 1; j--) 
                {
                    if (list[j - 1] < list[j]) ///////
                    {
                        break;
                    }

                    Swap(list, j - 1, j);
                }
            }
        }

        // 3. 병합정렬
        public static void MergeSort(IList<int> list, int start, int end)
        {
            if (start == end)
            {
                return;
            }

            int mid = (start + end) / 2;
            MergeSort(list, start, mid);
            MergeSort(list, mid + 1, end);
            Merge(list, start, mid, end);
        }

        private static void Merge(IList<int> list, int start, int mid, int end)
        {
            List<int> tmp = new List<int>();
            int leftIndex = start;
            int rigthIndex = mid + 1;

            while (leftIndex <= mid && rigthIndex <= end)
            {
                if (list[leftIndex] < list[rigthIndex]) 
                {
                    tmp.Add(list[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    tmp.Add(list[rigthIndex]); 
                    rigthIndex++;
                }
            }

            if (leftIndex > mid)
            {
                for (int i = rigthIndex; i <= end; i++)
                {
                    tmp.Add(list[i]);
                }
            }
            else
            {
                for (int i = leftIndex; i <= mid; i++)
                {
                    tmp.Add(list[i]);
                }
            }

            for (int i = 0; i < tmp.Count; i++) 
            {
                list[i + start] = tmp[i];
            }
        }

        // 4. 버블정렬
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i; j < list.Count; j++)
                {
                    if (list[j] < list[i]) 
                    {
                        Swap (list, j, i);
                    }
                }
            }
        }

        // 5. 퀵정렬
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right)
            {
                while (list[left] <= list[pivot] && left < end)
                {
                    left++;
                }

                while (list[right] >= list[pivot] && right > start)
                {
                    right--;
                }

                if (left < right)
                {
                    Swap(list, left, right);
                }
                else
                {
                    Swap(list, pivot, right);
                }
            }

            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }

        // A++ 힙정렬
        public static void HeapSort(IList<int> list)
        {
            MakeHeap(list);
            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        private static void MakeHeap(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }
        }

        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;

            int max = index;

            if (left < size && list[left] > list[max])
            {
                max = left;
            }

            if (right < size && list[right] > list[max])
            {
                max = right;
            }

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }

        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
