using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
    // 문제를 풀 때 접근방법?

    // 큰 문제에서 생각 -> 작은 문제로 쪼개보자(분할하자) 그러다 보면 풀릴것이다
    // 어려운 문제를 굉장히 간단한 문제로 생각할 수 있을거다

    // 분할해서 정복하고 합쳐내자 => 분할정복
    //  Divide  Conquer

    class DivideAndConquer
    {
        // 분할정복 (Divide and Conquer)

        // 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
        // 분할을 통해서 해결하기 쉬운 작은 문제로 나눈 후 정복한 후 병합하는 과정

        // 예시 - 거듭 제곱
        // 2 ^ 16 -> 4 ^ 8 -> 16 ^ 4 -> 256 ^ 2 -> 256 * 256
        // 2를 16번 곱하는 것 = 4를 8번 곱하는 것 => ... => 256을 2번 곱하는 것
        // 16번의 연산을 2번으로 줄일 수 있음

        // 2 ^ 16 -> 2 ^ 8 * 2 ^ 8 등 큰 문제를 두개로 분할하여 생각하여도 좋음

        // -> 한번 분할할 때 마다 곱하는 횟수가 적어짐
        // 분할 거듭 제곱 방법(O(logN))
        int Pow(int x, int n)
        {   // x ^ n -> x를 n번이나 곱해야 하는 O(n)
            // (x * x) ^ (n/2) -> O(logN)
            if (n == 1)
            {
                return x;
            }

            /*
            // 2 ^ 16 -> 2 ^ 8 * 2 ^ 8 로 변환
            return Pow(x, n / 2) * Pow(x, n / 2);
            */

            if (n % 2 == 0)
            {
                return Pow(x * x, n / 2);
            }
            else
            {   // 홀수 인 경우(2 ^ 7) -> 2 ^ 3 * 2 ^ 3 * 2
                return Pow(x * x, n / 2) * x;
            }
            
        }

        // 흔히 이용하는 거듭 제곱 방법(O(n))
        int Power(int x, int n)
        {
            int result = 1;
            for(int i = 0; i < n; i++)
            {
                result *= x;
            }

            return result;
        }
    }
}
