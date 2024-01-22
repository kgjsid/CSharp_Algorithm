using System;
using System.Linq;
using System.Text;

namespace _08._DesignTechnique.과제
{
    public class _02
    {
        static void Main(string[] args)
        {
            int N, M;
            int[] numbers;
            StringBuilder sb = new StringBuilder();
            int count = 0;

            string temp = Console.ReadLine();

            // N개 중
            N = int.Parse(temp.Split(' ')[0]);
            // M개의 숫자
            M = int.Parse(temp.Split(' ')[1]);

            // 배열 생성 M칸
            numbers = new int[M];

            // 백트래킹 시작
            // 총 숫자는 N개, 0인덱스부터 채우고, M개의 숫자까지 채울 예정
            BackTracking(N, 0, M, sb, numbers);

            Console.WriteLine(sb.ToString());
        }

        public static void BackTracking(int N, int index, int M, StringBuilder sb, int[] numbers)
        {
            // 만약 index가 M이라면? M개의 숫자를 채움
            if (index == M)
            {
                sb.AppendLine(string.Join(' ', numbers));
                return;
            }

            for (int i = 1; i <= N; i++)
            {
                // index는 0부터 시작하여 하나씩 채우기 시작
                numbers[index] = i;
                // 다음 인덱스(index+1) 채우기
                BackTracking(N, index + 1, M, sb, numbers);
                numbers[index] = 0;
            }
        }
    }

}