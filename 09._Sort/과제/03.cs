using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort.과제
{
    class _03
    {
        // 병합정렬
        // 분할하며 정렬하기
        // 합병할 때 왼쪽 / 오른쪽 나누고
        // 왼쪽의 맨 앞, 오른쪽의 맨 앞 비교하여 하나씩 넣기
        static void Main3(string[] args)
        {
            Random random = new Random();
            List<int> mergeSort = new List<int>();

            int count = 10;

            Console.WriteLine("정렬 전 데이터");
            for (int i = 0; i < count; i++)
            {
                int rnd = random.Next(0, 100);

                Console.Write($"{rnd,3}");
                mergeSort.Add(rnd);
            }

            MergeSort(mergeSort, 0, mergeSort.Count - 1);

            Console.WriteLine("병합 정렬 결과");
            foreach (int value in mergeSort)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }

        static void MergeSort(IList<int> list, int start, int end)
        {
            // 시작이랑 끝이랑 같다
            // 데이터가 한개면 분할하지 않기
            if(start == end)
            {
                return;
            }

            int mid = (start + end) / 2;

            // 반 분할 start ~ mid / mid + 1 ~ end
            MergeSort(list, start, mid);
            MergeSort(list, mid + 1, end);
            Merge(list, start, mid + 1, end);
        }

        static void Merge(IList<int> list, int start, int mid, int end)
        {
            // 왼쪽, 오른쪽 시작 지점 찾기
            int leftIndex = start;
            int rightIndex = mid;
            List<int> sortedList = new List<int>();

            while(leftIndex < mid && rightIndex <= end) // 한쪽을 다 쓸 때 까지
            {
                // 왼쪽이 더 작을 때
                if (list[leftIndex] < list[rightIndex])
                {
                    sortedList.Add(list[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    sortedList.Add(list[rightIndex]);
                    rightIndex++;
                }
            }

            // 나머지 다 넣기
            if(leftIndex > mid)
            {
                for(int i = rightIndex; i <= end; i++)
                {
                    sortedList.Add(list[i]);
                }
            }
            else
            {
                for(int i = leftIndex; i < mid; i++)
                {
                    sortedList.Add(list[i]);
                }
            }

            // 원래 배열에 붙여주기
            for(int i = 0; i < sortedList.Count; i++)
            {
                list[i + start] = sortedList[i];
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
