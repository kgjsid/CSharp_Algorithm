using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace _08._DesignTechnique.과제
{
    // 연속 합
    // 백트래킹 : 반드시 결과는 찾을 수 있음
    // 동적계획법 : 작은 문제의 해답을 이용해서 큰 문제 해결 가능
    class _01
    {
        static void Main1(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            string[] temp = Console.ReadLine().Split(' ');

            for(int i = 0; i < n; i++)
            {
                list.Add(int.Parse(temp[i]));
            }
            // ex) [2, 4] => 2 ~ 4를 더한 값
            int[] result = new int[n * n];
            int max = int.MinValue;

            // [1, 1] => 1, [2, 2] => 2
            for(int i = 0; i < n; i++)
            {
                result[i * 10 + i] = list[i];
                if (max < result[i * 10 + i])
                {
                    max = result[i * 10 + i];
                }
            }

            // result[1, 3] => result[1, 2] + result[3, 3]
            for(int start = 0; start < n - 1; start++)
            {
                for(int end = start + 1; end < n; end++)
                {
                   
                }
            }

            Console.WriteLine(max);
        }
    }
}
