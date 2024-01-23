namespace _10.Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 순차탐색
            int[] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };
            int sequentialIndex = Search.SequentialSearch(array, 2);
            Console.Write("순차탐색 배열 : ");
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine("순차탐색 결과 위치 : {0}", sequentialIndex);
            Console.WriteLine();

            // 이진탐색
            Array.Sort(array);  // 이진탐색의 경우 우선 정렬이 필요
            int binaryIndex = Search.BinarySearch(array, 2);
            Console.Write("이진탐색 배열 : ");
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine("이진탐색 결과 위치 : {0}", binaryIndex);
            Console.WriteLine();
        }
    }
}
