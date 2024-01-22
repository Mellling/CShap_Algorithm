using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Sorting
{
    internal class Sort
    {
        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 가장 작은값 찾아서 앞이랑 교체하는 방식
        // 시간복잡도 -  O(N²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void SelectionSort(IList<int> list, int start, int end)   // IList로 배열도, 리스트도 정렬 가능
        {
            for (int i = start; i <= end; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j <= end; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(list, i, minIndex);
            }
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 뒤에서부터 확인하면서 비교하는 대상이 더 크면 뒤로 한 칸
        // 시간복잡도 -  O(N²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void InsertionSort(IList<int> list, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (list[j - 1] < list[j])
                        break;

                    Swap(list, j - 1, j);
                }
            }
        }

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 시간복잡도 -  O(N²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void BubbleSort(IList<int> list, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                for (int j = start; j < end - i; j++)
                {
                    if (list[j] > list[j + 1])
                        Swap(list, j, j + 1);
                }
            }
        }

        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 -  O(NlogN)
        // 공간복잡도 -  O(N)
        // 안정정렬   -  O
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) 
                return;

            int mid = (left + right) / 2;

            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);
            Merge(list, left, mid, right);
        }

        private static void Merge(IList<int> list, int start, int mid, int end)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= end)
            {
                if (list[leftIndex] < list[rightIndex])
                    sortedList.Add(list[leftIndex++]);
                else
                    sortedList.Add(list[rightIndex++]);
            }

            if (leftIndex > mid)    // 왼쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = rightIndex; i <= end; i++)
                    sortedList.Add(list[i]);
            }
            else  // 오른쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= mid; i++)
                    sortedList.Add(list[i]);
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = 0; i < sortedList.Count; i++)
            {
                list[i + start] = sortedList[i];
            }
        }

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 퀵정렬이 이론적으로는 힙정렬보다 빠름
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(N²)
        // 시간복잡도 -  평균 : O(NlogN)   최악 : O(N²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right) // 엇갈릴때까지 반복
            {
                // pivot보다 큰 값을 만날때까지
                while (list[left] <= list[pivot] && left < end)
                    left++;
                while (list[right] >= list[pivot] && right > start)
                    right--;

                if (left < right)     // 엇갈리지 않았다면
                    Swap(list, left, right);
                else                  // 엇갈렸다면
                    Swap(list, pivot, right);
            }

            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }

        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간복잡도 -  O(NlogN)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
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
                max = left;
            if (right < size && list[right] > list[max])
                max = right;

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }

        public static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }

    }
}
