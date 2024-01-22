using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort
{
    public class Sorting
    {
        // 변경 함수
        public static void Swap(IList<int> list, int leftIndex, int rightIndex)
        {
            int temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }
        // 데이터를 주고 정렬을 위한 순차 작업이 필요함
        // 다양한 방법으로 정렬을 할 수 있음

        // <선택 정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 시간 복잡도 : O(n²)
        // 공간 복잡도 : O(1)

        // 7 2 3 1 6 9 -> 1이 가장 작으니 맨 앞으로 보내기
        // 1 / 7 2 3 6 9 -> 2가 그 다음으로 작으니 1 뒤로 보내기
        // 1 2 / 7 3 6 9 -> 반복 ...

        // 위의 방법은 2개의 공간이 필요함
        // 대체할 수 있는 방법으로 위치를 바꾸는 방법
        // 7 6 3 1 2 9 -> 1과 7자리 바꾸기 -> 1 6 3 7 2 9
        // 1 6 3 7 2 9 -> 2와 6자리 바꾸기 -> 1 2 3 7 6 9...

        public static void SelectionSort(IList<int> list, int start, int end) 
        {
            // 인덱스를 가지고 접근할 수 있는 클래스는 IList인터페이스를 가지고 있음(배열 기반)
            for(int i = start; i <= end; i++)
            {
                // 시작은 start부터
                int minIndex = i;
                // 그 다음부터(i+1) 더 작은 값이면 교체해 나감
                for (int j = i + 1; j <= end; j++)
                {
                    // 비교하여 더 작은 값을 발견하였으면 저장 -> 가장 작은 값 찾기
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // 제일 작은 것과 현재 제일 앞의 위치와 교체하기
                Swap(list, i, minIndex);
            }
        }

        // <삽입 정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간 복잡도 : O(n²)
        // 공간 복잡도 : O(1)

        // 3 1 6 2 7 9
        // -> 3
        // -> 1 3
        // -> 1 3 6
        // -> 1 2 3 6 ... -> 정렬된 자료 중 앞에서부터 하나씩 확인하여 끼워넣는 방식

        public static void InsertionSort(IList<int> list, int start, int end)
        {
            // 맨 앞부터 데이터 선택
            for(int i = start; i <= end; i++)
            {
                // 어느 위치에 들어가야 할 지
                // 뒤에서부터 확인

                // 1 2 4 5 <= 3?
                // 1 2 4 3 5 -> 1 2 3 4 5 -> 뒤에서 부터 한칸씩 확인
                for (int j = i; j >= 1; j--)
                {
                    if (list[j - 1] < list[j])
                    {
                        // 만약 앞의 있는 수가 더 작으면?
                        // 더이상 자리 바꾸기 정지
                        break;
                    }
                    // 삽입을 자리 바꿔가며 진행
                    Swap(list, j - 1, j);
                }
            }
        }

        // <버블 정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 큰 것부터 하나씩 뒤로 보내기
        // 시간 복잡도 : O(n²)
        // 공간 복잡도 : O(1)
        public static void BubbleSort(IList<int> list, int start, int end)
        {
            for(int i = start; i <= end - 1; i++)
            {
                // 끝에는 정렬된 데이터가 쌓이니 end - i
                // i번 실행하면 끝의 i개 데이터는 정렬된 상태. 갈 이유가 없음
                for(int j = start; j < end - i; j++)
                {
                    // 다음 것과 비교하여 지금 자신이 더 크면
                    // 뒤로 가기
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }
        }

        // 삽입, 선택, 버블정렬은 전부 이중 반복문이 필요
        // 전부 시간 복잡도는 O(n²) -> 더 빠른 정렬은 없을까?
        // 100개를 나눠서 생각하면? 50개씩 나눠서 두개를 합치면? -> 시간 절약이 되지 않을까?
        // 반분할(분할 정복)하여 정렬하는 기법들은 훨씬 더 빠를 것(O(nlogn))

        // <병합 정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 : O(nlogn)
        // 공간복잡도 : O(n)

        // 가장 앞서 있는 데이터끼리 비교하기
        // ex) 3 1 7 5 2 8 6 4의 병합정렬??
        // 3 1 7 5    /    2 8 6 4
        // 1 3 5 7    /    2 4 6 8 => 두 데이터의 병합에서 가장 앞 데이터만 확인
        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 의 순으로 병합
        // 전부 확인하는 사항이 아닌 나머지 모든 데이터도 정렬이 되어 있으니 앞선 데이터만 확인
        public static void MergeSort(IList<int> list, int start, int end)
        {
            // 하나 짜리는 정렬하지 않음(시작과 끝이 같다)
            if (start == end)
                return;

            int mid = (start + end) / 2;
            // 중간을 나눠서 절반씩 진행
            MergeSort(list, start, mid);
            MergeSort(list, mid + 1, end);
            // 진행 후 합치는 과정
            Merge(list, start, mid, end);
        }

        // 병합 과정
        public static void Merge(IList<int> list, int start, int mid, int end)
        {
            // 병합될 리스트
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;
            // 1 3 5 7    /    2 4 6 8
            // left는 1을, right는 2를 가리키는 인덱스
            // 왼쪽 혹은 오른쪽 배열이 모두 빌 때까지
            // 만약 한쪽이 다 소진되면? -> 나머지는 그냥 이어 붙이면 됨
            while (leftIndex <= mid && rightIndex <= end)
            {
                // 만약 왼쪽의 제일 앞이 가장 작다면?
                if (list[leftIndex] < list[rightIndex])
                {
                    // 병합할때 제일 먼저 넣고
                    sortedList.Add(list[leftIndex]);
                    // 왼쪽에서 다음 녀석 가리키기
                    leftIndex++;
                }
                else // 오른쪽 제일 앞이 가장 작다면?
                {
                    // 병합할 때 제일 먼저 넣고
                    sortedList.Add(list[rightIndex]);
                    // 오른쪽에서 다음 녀석 가리키기;
                    rightIndex++;
                }
            }

            // 남아 있는 데이터 전부 병합
            // 왼쪽의 데이터를 전부 소진했으면
            if(leftIndex > mid)
            {
                // 남은 오른쪽에 있는 데이터 전부 붙이기
                for(int i = rightIndex; i <= end; i++)
                {
                    sortedList.Add(list[i]);
                }
            }
            else // 오른쪽의 데이터를 전부 소진했으면
            {    // 남은 왼쪽에 있는 데이터 전부 붙이기
                for(int i = leftIndex; i <= mid; i++)
                {
                    sortedList.Add(list[i]);
                }
            }

            // 원래 배열에 정렬 결과 넣어주기
            for(int i = 0; i < sortedList.Count; i++)
            {
                // 시작 위치부터 쭉 이어 붙이기
                list[start + i] = sortedList[i];
            }
        }

        // 병합 정렬은 시간 복잡도에서는 훨씬 유용하나
        // 공간을 하나 더 잡아먹는 문제

        // <퀵 정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
        // 시간복잡도 : 평균 - O(nlogn), 최악 - O(n²)
        // 공간복잡도 : O(1)

        // 피벗 : 기준값
        // 기준값을 중심으로 왼쪽, 오른쪽을 선정
        // left는 기준값보다 큰 값을 찾을때 까지 오른쪽으로
        // right는 기준값보다 작은 값을 찾을때 까지 왼쪽으로
        // 둘 다 찾았으면 교환 -> right와 left가 교차할 때 까지 위의 과정을 반복
        // 교차되면, 피벗과 right를 바꿈 -> 자연스럽게 왼쪽은 pivot보다 작은 값, 오른쪽은 큰 값

        // 퀵 정렬의 단점
        // 9 8 7 6 5 4 3 2 1 을 정렬하면?
        // 8 7 6 5 4 3 2 1 9
        // 7 6 5 4 3 2 1 8 9...의 순서로 정렬이 실행되어 버림
        // 최악의 경우 반분할의 의미가 없어져버림(O(n²))

        public static void QuickSort(IList<int> list, int start, int end)
        {
            // 하나일 때
            if (start >= end)
                return;

            // 처음 피벗은 시작점
            int pivot = start;
            int left = pivot + 1;
            int right = end;

            // left와 right가 엇갈릴 때 까지
            while(left <= right)
            {
                // left는 기준보다 큰 값을 만날 때 까지 오른쪽으로 가기
                while (list[left] <= list[pivot] && left < right)
                {
                    left++;
                }// right는 기준보다 작은 값을 만날 때 까지 왼쪽으로 가기
                while (list[right] > list[pivot] && left <= right)
                {
                    right--;
                }

                // 엇갈리지 않고 값을 찾았다면
                if(left < right)
                {
                    Swap(list, left, right);
                }
                else // 교차되었을 땐
                {
                    // 피벗위치와 교체해야 하므로
                    Swap(list, pivot, right);
                    // 피벗과 바뀌면 정지
                    break;
                }
            }

            // 왼쪽끼리 퀵 정렬
            QuickSort(list, start, right - 1);
            // 오른쪽끼리 퀵 정렬
            QuickSort(list, right + 1, end);
        }

        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간복잡도 : O(nlogn)
        // 공간복잡도 : O(1)

        // 1. 데이터가 있음
        // 2. 데이터를 최대 힙 상태로 만들어 줌
        // 3. 힙의 제거? -> 가장 마지막 데이터와 바꾸고 삭제인데 삭제하지 않으면??
        // => 가장 마지막 데이터가 최대값이 될 것
        // 4. 2, 3의 반복

        public static void HeapSort(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }

            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        // 힙 만들기
        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && list[left] > list[max])
            {
                max = left;
            }
            if (right < size && list[right] > list[max])
            {
                max = right;
            }

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }
        // 6개의 정렬
        // 가장 이론상 완벽한 정렬은 힙정렬? -> 현실적으론 다름
        // 힙보다 퀵이 더 빠름

        // 힙정렬은 캐시 적중률이 낮음??
        // 퀵정렬은 연속적인 메모리 사용을 진행함 -> 왜 중요한가?
        // 컴퓨터는 캐시 메모리가 존재 -> 컴퓨터는 기본적으로 데이터를 들고 올 때 Cpu의 캐시를 이용
        // 반면에 느리긴 하지만 용량이 큰 RAM이 존재 -> 캐시 메모리는 Cpu의 속도를 감당할 만큼 빠름
        // cpu에서 메모리를 요구할 때 캐시에 있다면 우선으로 캐시에 있는 것 부터 이용
        // 없다면? RAM에 요청하여 일부분을 뭉쳐서 들고와서 캐시에 담아놓고 사용하는 방식
        // 배열을 쓸 때엔 순차적으로 씀 -> 연속적으로 쓰니 캐시를 잘 쓸 수 있다

        // ex) 0 ~ 100번 배열이 있다
        // 0번이 필요하다면 한번에 0 ~ 20번을 가져와서 캐시에 저장
        // 다음 것이 필요할 땐 캐시에 있는 것을 사용하다가 21번이 필요해지면
        // RAM에서 다음 것을 요청하여 들고옴(21 ~ 40)

        // 캐시 적중률
        // 캐시메모리가 있는 컴퓨터 시스템은 CPU가 메모리에 접근하기 전 먼저 캐시 메모리에서 원하는 데이터의 존재 여부를 확인한다
        // 이때 필요한 데이터가 있는 경우를 적중(hit), 없는 경우를 실패(miss)라고 한다
        // 이 때 요청한 데이터를 캐시메모리에서 찾을 확률을 적중률(hit ratio)이라고 한다
        // 캐시 메모리의 성능은 적중률에 의해 결정된다

        // 퀵정렬은 연속적 메모리 사용을 하므로 캐시 적중률이 높다 -> 빠른 결과물
        // 힙정렬은 연속적으로 메모리를 사용하지 않아 캐시 적중률이 낮다 -> 느려지는 정렬 가능성

        // C#은 무슨 정렬을 쓸까?
        // 인트로정렬 사용(하이브리드 정렬)

        // 인트로정렬? -> 정렬을 하다 상황에 따라 더 좋은 정렬을 선택함
        // 퀵, 힙, 삽입을 혼합하여 사용

        // 기본적으로 퀵을 시도 -> 최악의 상황으로 근접해지면 힙 정렬로 전환
        // -> 데이터의 크기가 특정 수보다 적어지면 삽입 정렬로 전환
        // 왜 삽입 정렬을?? -> 갯수가 적으면 삽입이 더 빠름 O(n²)??
        // 보통 데이터의 수가 16개보다 적으면 O(n²)이 더 빠른이유??

        // 퀵과 힙은 모두 재귀의 과정이 포함됨
        // 16개 정도인 경우를 굳이 계속해서 나눠가야 할 필요가 있는지?
        // 적은 데이터를 분할 정복하면 함수 호출이 더 느려지는 현상 발생
        // 16개 -> 31번의 함수 호출이 필요
        // 4 * 16연산 * 31번 함수 호출 => 16 * 16연산 * 1번의 함수 호출
    }
}
