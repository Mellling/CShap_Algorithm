

namespace StackQueueTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 실습 2
            /*ParenthesesChecker parenthesesChecker = new ParenthesesChecker();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("괄호 입력: ");
                string str = Console.ReadLine();
                if (parenthesesChecker.IsOk(str))
                {
                    Console.WriteLine("완성.");
                }
                else
                {
                    Console.WriteLine("미완성.");
                }
            }*/
            int[] array = { 4, 4, 12, 10, 2, 10 };
            Job job = new Job();
            foreach (int i in job.ProcessJob(array))
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }

    // 실습 1
    /*
     * a. 스택: 5, 4, 3, 2, 1     큐: 1, 2, 3, 4, 5
     * b. 스택: 3, 2, 6, 7, 5, 4, 1     큐:  1, 2, 3, 4, 5, 6, 7
     * c. 스택: 1, 4, 5, 6, 7, 8, 9, 2, 3    큐:  3, 2, 1, 6, 7, 8, 9, 4, 5
     * d. 스택: 5, 8, 4, 3, 1, 2    큐: 1, 3, 5, 2, 4, 8, 1, 3
     * e. 스택: 1, 2, 1, 2, 1, 2, 3, 3, 3     큐: 3, 2, 3, 2, 3, 2, 1, 1, 1
     */

    // 실습 2
    /*public class ParenthesesChecker
    {
        Stack<char> stack = new Stack<char>();

        public bool IsOk(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i]) 
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(text[i]);
                        break;
                    default:
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        switch (text[i])
                        {
                            case ')':
                                if (stack.Pop() != '(')
                                {
                                    return false;
                                }
                                break;
                            case '}':
                                if (stack.Pop() != '{')
                                {
                                    return false;
                                }
                                break;
                            case ']':
                                if (stack.Pop() != '[')
                                {
                                    return false;
                                }
                                break;
                        }
                        break;
                }
            }

            if (stack.Count != 0)
            {
                return false;
            }

            return true;
        }
    }*/

    // 실습 3
    public class Job
    {
        const int CANJOB = 8;
        public int[] ProcessJob(int[] jobList)
        {
            int[] answer = new int[jobList.Length];

            int canJob = CANJOB;
            int jobDays = 1;

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < jobList.Length; i++)
            {
                if (jobList[i] < canJob)
                {
                    queue.Enqueue(i);
                    canJob -= jobList[i];
                }
                else if (jobList[i] == canJob)
                {
                    if (queue.Count > 0)
                    {
                        while (queue.Count != 0) 
                        {
                            answer[queue.Dequeue()] = jobDays;
                        }
                    }
                    answer[i] = jobDays;
                    jobDays++;
                    canJob = CANJOB;
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        canJob = CANJOB;
                        while (queue.Count != 0)
                        {
                            answer[queue.Dequeue()] = jobDays;
                        }
                        answer[i] = jobDays;
                        jobDays++;
                    }
                    else
                    {
                        int count = 1;
                        while(true)
                        {
                            if(CANJOB * count > jobList[i])
                            {
                                jobDays += count - 1;
                                canJob = CANJOB * count - jobList[i];
                                answer[i] = jobDays;
                                break;
                            }
                            count++;
                        }
                    }
                }
            }

            return answer;
        }
    }
}
