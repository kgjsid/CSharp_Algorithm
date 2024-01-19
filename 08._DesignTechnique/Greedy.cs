using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
    class Greedy
    {
        // 탐욕 알고리즘 (Greedy Algorithm)

        // 문제를 해결하는데 사용되는 근시안(짧은시야)적 방법
        // 문제를 직면한 당시에 당장 최적인 답을 선택하는 과정을 반복
        // 단, 반드시 최적의 해를 구해준다는 보장이 없음

        // 탐욕 알고리즘은 빠른 알고리즘 중 하나
        // 당장 문제를 직면한 당시에 빠르게 해결하기 위해 사용

        // 빠르고 직관적이나 다만 아쉬운 부분은 상황에 따라 지금은 유리했는데
        // 나중에 반드시 해결되리라는 보장은 없음 -> 문제에 따라 다름

        // 예시 - 자판기 알고리즘
        void CoinMachine(int money)
        {
            int[] coinType = { 500, 100, 50, 10, 5, 1 };

            foreach(int coin in coinType)
            {
                while(money <= coin)
                {
                    Console.WriteLine($"{coin} 코인 배출");
                    money -= coin;
                }
            }
        }

        // 저번에 풀은 회의실 문제 + 우선순위 큐 + 길찾기
    }
}
