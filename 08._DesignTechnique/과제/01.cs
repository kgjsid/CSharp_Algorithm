using System;
using System.Linq;
using System.Text;

namespace _08._DesignTechnique.과제
{
    public class _01
    {
        static void Main(string[] args)
        {
            int N;

            N = int.Parse(Console.ReadLine());

            // 숫자를 담을 배열
            int[] arr = new int[N];
            // 중간중간 합 확인
            int[] dp = new int[N];
            int max = int.MinValue;

            string[] temp = Console.ReadLine().Split(' ');
            for (int i = 0; i < temp.Length; i++)
            {
                arr[i] = int.Parse(temp[i]);
            }

            dp[0] = arr[0];
            max = dp[0];

            for (int i = 1; i < arr.Length; i++)
            {
                // 다음 합 계산. 만약 이전까지의 합 + 새로운 수와 새로운 수를 비교함
                // 만약 기존 수열의 합이 더 크가면 현재 숫자를 연속된 수열에 포함시키는게 좋음
                // 아니라면 값이 적으므로 다시 수열을 만드는 것이 좋음 -> 해당 수열부터 시작
                dp[i] = dp[i - 1] + arr[i] > arr[i] ? dp[i - 1] + arr[i] : arr[i];
                if (dp[i] > max)
                {
                    max = dp[i];
                }
            }

            Console.WriteLine(max);
        }
    }
}