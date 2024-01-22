using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort.과제
{
    class _05
    {
        // 퀵 정렬
        // 하나의 pivot을 정하고(start)
        // pivot을 기준 left, right를 정한다
        // left는 pivot보다 큰 값을 찾을 때 까지 오른쪽으로 
        // right는 pivot보다 작은 값을 찾을 때 까지 왼쪽으로 이동

        // 1. 두 개의 값을 찾았다면? -> 교환
        // 2. 두 개의 값을 찾았다만 교차되면? -> pivot과 right를 교체

        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> quickSort = new List<int>();

            int count = 10;

            Console.WriteLine("정렬 전 데이터");
            for (int i = 0; i < count; i++)
            {
                int rnd = random.Next(0, 100);

                Console.Write($"{rnd,3}");
                quickSort.Add(rnd);
            }

            QuickSort(quickSort, 0, quickSort.Count - 1);

            Console.WriteLine("퀵 정렬 결과");
            foreach (int value in quickSort)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }

        static void QuickSort(IList<int> list, int start, int end)
        {
            // 시작과 끝이 같다면 먼저 종료조건
            if(start >= end)
            {
                return;
            }

            int pivot = start;
            int leftIndex = start + 1;
            int rightIndex = end;

            while (true)
            {
                // 중간값보다 왼쪽 오른쪽으로 이동하며 더 큰 값 찾기
                // 같을 때 멈추기
                while (list[pivot] > list[leftIndex] && leftIndex < rightIndex)
                {
                    leftIndex++;
                }
                // 중간값보다 오른쪽에서 왼쪽으로 이동하며 더 작은 값 찾기
                // 같을 때 움직이기
                // 겹치는 오류 발생
                while (list[pivot] <= list[rightIndex] && leftIndex <= rightIndex)
                {
                    rightIndex--;
                }
                // 교차x
                if (leftIndex < rightIndex)
                {   // 해당 값들 바꾸기
                    Swap(list, leftIndex, rightIndex);
                }
                else // 교차
                {   // pivot과 right바꾸기
                    Swap(list, pivot, rightIndex);
                    // 더 이상 진행하지 않고
                    break;
                }
            }
            // 두 부분으로 나누기
            // 시작부터 right / left부터 end
            QuickSort(list, start, rightIndex - 1);
            QuickSort(list, rightIndex + 1, end);
        }

        static void Swap(IList<int> list, int leftIndex, int rightIndex)
        {
            int temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }
    }
}
