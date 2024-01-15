using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._Queue.과제
{
    class _03
    {
        static void Main(string[] args)
        {
            int[] jobList = { 4, 4, 12, 10, 2, 10 };

            int[] answer = ProcessJob(jobList);

            foreach(int i in answer)
            {
                Console.WriteLine(i);
            }
        }

        static int[] ProcessJob(int[] jobList)
        {
            Queue<int> queue = new Queue<int>();
            List<int> list = new List<int>();
            const int WORKTIME = 8;
            int remainTime = WORKTIME; // 할 수 있는 일의 시간
            int temp = 0;              // 해야할 일의 시간
            int day = 1;

            for (int i = 0; i < jobList.Length; i++)
            {
                queue.Enqueue(jobList[i]);
            }

            temp = queue.Dequeue();

            while (true)
            {
                if (remainTime == 0)
                {
                    remainTime = WORKTIME;
                }

                // 1. temp보다 workTime이 길때
                if (temp > remainTime)
                {
                    // 남은 양에서 할 수 있는 만큼 빼고
                    temp -= remainTime;
                    remainTime = 0;
                    // 하루 증가
                    day++;
                }// 2. 짧을 때
                else if (temp < remainTime)
                {
                    // 진행하고
                    remainTime -= temp;
                    temp = 0;
                    // 해당 일자에 끝났으니 추가
                    list.Add(day);
                }
                else // 3. 같을 때
                {
                    // 전부 진행 후
                    remainTime -= temp;
                    temp = 0;
                    // 해당 일자에 끝났으니 추가
                    list.Add(day);
                    // 할 수 있는 일이 없으므로 하루 증가
                    day++;
                }

                // 남은 일이 없고 일이 남아 있지 않으면
                if (temp == 0 && queue.Count == 0)
                {
                    break;
                }
                else if (temp == 0) // 일이 남아 있으면 꺼내기
                {
                    temp = queue.Dequeue();
                }
            }

            return list.ToArray();
        }

    }
}
