using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort.과제
{
    class _02
    {
        // 삽입 정렬
        // 끝에서부터 비교해서 제 자리에 집어넣는 방법
        static void Main2(string[] args)
        {
            Random random = new Random();
            List<int> insertSort = new List<int>();

            int count = 10;

            Console.WriteLine("정렬 전 데이터");
            for (int i = 0; i < count; i++)
            {
                int rnd = random.Next(0, 100);

                Console.Write($"{rnd,3}");
                insertSort.Add(rnd);
            }

            InsertSort(insertSort, 0, insertSort.Count - 1);

            Console.WriteLine("삽입 정렬 결과");
            foreach (int value in insertSort)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }

        static void InsertSort(IList<int> list, int start, int end)
        {
            for(int i = start; i <= end; i++)
            {
                for(int j = i; j >= 1; j--)
                {
                    if (list[j - 1] > list[j])
                    {
                        Swap(list, j - 1, j);
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
