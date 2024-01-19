using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
    class DynamicProgramming
    {
        // 동적 계획법(DynamicProgramming)

        // 작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방법
        // 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법

        // 분할 정복(큰 문제를 작은 문제로)의 반대라고 생각
        // 작은 문제의 해답들을 기록하면 큰 문제에 써먹을 수 있을거다

        // 동적 계획법은 계산한 결과가 계속 필요함(기록해 놓아야 함 / 메모이제이션)
        // -> 큰 문제를 풀 때 작은 문제의 해답이 필요함

        // 예시 - 피보나치 수열
        // 두 개의 이전 기록이 필요함 -> 뒤의 수열을 구하기 위해 앞의 기록이 반드시 필요
        // f(n) = f(n-1) + f(n-2)
        int Fibonachi(int x)
        {
            int[] fibonachi = new int[x + 1];
            fibonachi[1] = 1; // 이전 기록 저장
            fibonachi[2] = 1; // 이전 기록 저장

            for (int i = 3; i <= x; i++)
            {
                // 이전에 구해놓은 기록을 가지고 다음 해답을 찾아냄
                fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
            }

            return fibonachi[x];
        }

        // 분할 정복으로 풀어낸 피보나치수열
        // fino(10)을 구하기 위해 fibo(9) fibo(8)을 -> ...
        int Fibonachi2(int x)
        {
            if (x == 1)
                return 1;
            else if (x == 2)
                return 1;

            return Fibonachi2(x - 1) + Fibonachi2(x - 2);
        }

        // 동적계획법 거듭제곱
        int Pow(int x, int n)
        {
            int[] result = new int[n];
            result[0] = x; // 처음 시작 기록

            for(int i = 0; i < n; i++)
            {
                result[i] = result[i - 1] * x;
            }

            return result[n - 1];
        }
    }
}
