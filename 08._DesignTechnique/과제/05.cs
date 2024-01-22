using System;
using System.Linq;
using System.Text;

namespace _08._DesignTechnique.과제
{
    public class _05
    {
        static void Main(string[] args)
        {
            int N;

            N = int.Parse(Console.ReadLine());

            int[,] tri = new int[N, N];
            int max = int.MinValue;

            for (int i = 0; i < N; i++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    tri[i, j] = int.Parse(temp[j]);
                }
            }

            // 7
            // 3 8
            // 8 1 0   
            // 2 7 4 4
            // 4 5 2 6 5
            /*
            for (int j = 0; j < tri.GetLength(0); j++)
            {
                for(int i = 0; i < tri.GetLength(1); i++)
                {
                    Console.Write($"{tri[j, i]} ");
                }
                Console.WriteLine();
            }
            */

            for (int j = 1; j < tri.GetLength(0); j++)
            {
                // 7 3 8 2 4 -> 이쪽은 한 갈래
                // tri[1, 0] => tri[1, 0](3) + tri[0, 0](7)
                tri[j, 0] += tri[j - 1, 0];
                for (int i = 1; i < tri.GetLength(1); i++)
                {
                    // 그 이외에는 위에 두 개중 큰 값을 더해야 함
                    if (tri[j - 1, i - 1] > tri[j - 1, i])
                    {
                        tri[j, i] += tri[j - 1, i - 1];
                    }
                    else
                    {
                        tri[j, i] += tri[j - 1, i];
                    }
                }
            }
            // 마지막 라인 중 가장 큰 값을 골라야 정답처리
            for (int i = 0; i < tri.GetLength(1); i++)
            {
                if (max < tri[tri.GetLength(0) - 1, i])
                {
                    max = tri[tri.GetLength(0) - 1, i];
                }
            }

            Console.WriteLine(max);
        }
    }
}