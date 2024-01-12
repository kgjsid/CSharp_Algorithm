using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList.과제
{
    class _03
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            int[] arr = { 3, 2, 1, -3, -1};
            int count = 0;
            // value에 따라 방향설정
            bool isDir = true;

            for(int i = 0; i < arr.Length; i++)
            {
                list.AddLast(arr[i]);
            }

            // 제일 첫번째 터트리기
            int targetValue = list.First();

            list.RemoveFirst();
            Console.Write($"{targetValue} ");

            while (list.Count > 0)
            {
                if((targetValue - 1) == count)
                {
                    // 정방향이면 맨 앞에꺼
                    if (isDir == true)
                    {
                        targetValue = list.First.Value;
                        list.Remove(list.First());
                        Console.Write($"{targetValue} ");
                        count = 0;
                    }
                    else // 역은 맨 뒤에꺼
                    {
                        targetValue = list.Last.Value;
                        list.Remove(list.Last());
                        Console.Write($"{targetValue} ");
                        count = 0;
                    }
                    if(targetValue < 0)
                    {
                        targetValue *= (-1);
                        isDir = false;
                    }
                    else
                    {
                        isDir = true;
                    }
                }
                else
                {
                    // value가 양수면 맨 뒤로
                    if (isDir == true)
                    {
                        int temp = list.First.Value;
                        list.Remove(list.First);
                        list.AddLast(temp);
                        count++;
                    }
                    else if(isDir == false) // 음수면 맨 앞으로
                    {
                        int temp = list.Last.Value;
                        list.Remove(list.Last);
                        list.AddFirst(temp);
                        count++;
                    }
                }
            }
        }
    }
}
