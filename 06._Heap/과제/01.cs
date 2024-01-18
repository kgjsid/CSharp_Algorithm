using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1일차 마감? 1일 이전
// 2일차 마감? 2일 이전
// 역순 생각해서 각 일차에 가장 높은애를 하자
// 적어도 이 일자에서 가장 높은 걸 하는거??

namespace _06._Heap.과제
{
    class _01
    {
        static void Main1(string[] args)
        {
            int N;
            int.TryParse(Console.ReadLine(), out N);

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            List<int> d = new List<int>(N);
            List<int> w = new List<int>(N);
            string s;

            for (int i = 0; i < N; i++)
            {
                s = Console.ReadLine();
                d.Add(int.Parse(s.Split(' ')[0]));
                w.Add(int.Parse(s.Split(' ')[1]));
            }

            int max = 0;
            int sum = 0;
            int addScore = 0;
            // 가장 늦게 마감해야 될 날짜 찾기
            for (int i = 0; i < N; i++)
            {
                if (d[i] > max)
                {
                    max = d[i];
                }
            }

            while (max > 0)
            {
                for (int i = 0; i < w.Count; i++)
                {   // 늦은 시간부터 시작하여 과제 찾기
                    if (d[i] == max)
                    {
                        // 높은 점수의 우선순위를 높이기 위해 값은 점수, 우선순위는 점수의 내림차순으로 설정
                        // 점수가 높을수록 우선순위도 높음
                        pq.Enqueue(w[i], (-1) * w[i]);
                    }
                }
                // 비어있을 수도 있으니 있을 때만 큐에서 뽑아내기
                pq.TryDequeue(out addScore, out int temp);
                sum += addScore;
                // 계속해서 일자 줄여서 마감 과제 확인하기
                max--;
            }
            Console.WriteLine(sum);
        }
    }
}