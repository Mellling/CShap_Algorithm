using System;
using static System.Collections.Specialized.BitVector32;

namespace HashTableTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheatKey cheatKey = new CheatKey();

            cheatKey.Run("ShowMeTheMoney");
            cheatKey.Run("ThereIsNoCowLevel");
            cheatKey.Run("Null");
        }

        // A+ 치트키 구현
        public class CheatKey
        {
            Dictionary<string, Action> cheatDic;

            public CheatKey() 
            {
                cheatDic = new Dictionary<string, Action>();
                Action action;

                cheatDic.Add("ShowMeTheMoney", action = ShowMeTheMoney);
                cheatDic.Add("ThereIsNoCowLevel", action = ThereIsNoCowLevel);
            }

            public void Run(string cheatKey)
            {
                Action action;
                // 조건문 없이 바로 탐색하여 치트키 발동
                cheatDic.TryGetValue(cheatKey, out action);

                action?.Invoke();
            }
            
            public void ShowMeTheMoney()
            {
                Console.WriteLine("골드를 늘려주는 치트키 발동!");
            }

            public void ThereIsNoCowLevel()
            {
                Console.WriteLine("바로 승리합니다 치트키 발동!");
            }
        }
    }
}
