using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort.과제
{
    class _04
    {
        // 버블정렬
        // 두 개씩 비교해서 정렬하기
        static void Main4(string[] args)
        {
            Random random = new Random();
            List<int> bubbleSort = new List<int>();

            int count = 10;

            Console.WriteLine("정렬 전 데이터");
            for (int i = 0; i < count; i++)
            {
                int rnd = random.Next(0, 100);

                Console.Write($"{rnd,3}");
                bubbleSort.Add(rnd);
            }

            BubbleSort(bubbleSort, 0, bubbleSort.Count - 1);

            Console.WriteLine("버블 정렬 결과");
            foreach (int value in bubbleSort)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }

        static void BubbleSort(IList<int> list, int start, int end)
        {
            for(int i = start; i < end; i++)
            {
                for(int j = start + 1; j <= end; j++)
                {
                    if (list[j] < list[j - 1])
                    {
                        Swap(list, j, j - 1);
                    }
                }
            }

        }
        static void Swap(IList<int> list, int leftIndex, int rightIndex)
        {
            int temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }
    }
}
