using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._Hashtable.과제
{
    class _01
    {
        public class CheatKey
        {
            private Dictionary<string, Action> cheatDic;

            public CheatKey()
            {
                // key에는 치트키 문자가, value에는 실행할 함수
                // cheatDic[key] = value;
                cheatDic = new Dictionary<string, Action>();
                cheatDic.Add("ShowMeTheMoney", ShowMeTheMoney);
                cheatDic.Add("ThereIsNoCowLevel", ThereIsNoCowLevel);
            }

            public void Run(string cheatKey)
            {
                // 조건문 없이 바로 탐색하여 치트키 발동
                // cheatKey에 따라 해당 함수 탐색
                cheatDic.TryGetValue(cheatKey, out Action action);

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

        static void Main3(string[] args)
        {
            CheatKey cheatKey = new CheatKey();

            string chat;

            chat = Console.ReadLine();
            cheatKey.Run(chat);

        }
    }
}
