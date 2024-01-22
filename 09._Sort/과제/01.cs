using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort.과제
{
    class _01
    {
        // 선택정렬
        // 가장 작은 거 선택하고 맨 앞이랑 자리 바꾸기
        static void Main2(string[] args)
        {
            Random random = new Random();
            List<int> selectSort = new List<int>();

            int count = 10;

            Console.WriteLine("정렬 전 데이터");
            for (int i = 0; i < count; i++)
            {
                int rnd = random.Next(0, 100);

                Console.Write($"{rnd,3}");
                selectSort.Add(rnd);
            }

            SelectSort(selectSort, 0, selectSort.Count - 1);

            Console.WriteLine("선택 정렬 결과");
            foreach (int value in selectSort)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }

        static void SelectSort(IList<int> list, int start, int end)
        {
            int MinIndex = start;

            for(int i = start; i <= end; i++)
            {
                for(int j = i + 1; j <= end; j++)
                {
                    if (list[MinIndex] > list[j])
                    {
                        MinIndex = j;
                    }
                }
                Swap(list, i, MinIndex);
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
