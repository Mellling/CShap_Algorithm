namespace HeapTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;

            OutBestScore outBestScore = new OutBestScore();

            int.TryParse(Console.ReadLine(), out num);

            for (int i = 0; i < num; i++)
            {
                string nums = Console.ReadLine();

                int day = (int)char.GetNumericValue(nums[0]);

                int score = int.Parse(nums.Substring(2, nums.Length - 2));

                outBestScore.PutDays(new int[] { day, score }, score);
                outBestScore.PutScores(new int[] { day, score } , score);
            }

            outBestScore.PutNum(num);

            outBestScore.BestScore();
        }

        public class OutBestScore
        {
            PriorityQueue<int[], int> leftDays = new PriorityQueue<int[], int>();
            PriorityQueue<int[], int> scores = new PriorityQueue<int[], int>();

            int num;

            public void PutNum(int num)
            {
                this.num = num;
            }

            public void PutDays(int[] input, int score) // 날짜 얼마 안 남은 수
            {
                leftDays.Enqueue(input, score);
            }

            public void PutScores(int[] input, int score)   // 날짜 많이 남은 수
            {
                scores.Enqueue(input , -score);
            }

            public void BestScore()
            {
                int sum = 0;
                int nowDay = 1;

                int count = 1;

                while (count <= num)
                {
                    int[] up = leftDays.Dequeue();
                    int[] down = scores.Dequeue();
                    if (up[1] > down[1]) 
                    {
                        if (up[0] >= nowDay)
                        {
                            sum += up[1];
                            nowDay++;
                        }
                        else if (down[0] >= nowDay)
                        {
                            sum += down[1];
                            nowDay++;
                        }
                    }
                    else 
                    {
                        if (down[0] >= nowDay)
                        {
                            sum += down[1];
                            nowDay++;
                        }
                        else 
                        {
                            sum += up[1];
                            nowDay++;
                        }
                    }
                    count++;
                }

                Console.WriteLine(sum);

            }
        }
    }
}
