﻿namespace _04._Queue
{
    class Program
    {
        // 큐 (Queue)

        // 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
        // 입력된 순서대로 처리해야 하는 상황에 이용
        // 스택은 박스 큐는 파이프라인(입구와 출구가 따로)

        // A -> B -> C 순서대로 데이터를 집어넣으면 꺼낼 때도 A -> B -> C 순서
        // 대기열이나 순서 처리에 활용


        // 큐의 활용

        // 판정이나 순서 처리에 유용하게 사용
        // 동시에 타격했다? -> 중요한 이슈를 큐에 넣어두고 판정식으로 처리
        // 네트워크 -> 처리가 늦은 경우에도 쓸 수 있음(버퍼개념)

        // <큐 구현>
        // 1. 배열 사용
        // 선입선출(FIFO), 후입후출(LILO) 을 구현하기 위해 배열을 생성하고 순차적으로 데이터를 배치
        //      ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // front│1│2│3│4│5│ │ │ │back
        //      └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 삽입 -
        // 비어있는 가장 뒷쪽에 데이터를 배치
        //  ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        //  │1│2│3│4│5│ │ │ │   =>   │1│2│3│4│5│6│ │ │
        //  └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 삭제 -
        // 가장 앞쪽 데이터를 출력하고 빈자리를 채우기 위해 나머지 데이터를 앞당기기 진행
        //  ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        //  │1│2│3│4│5│6│ │ │   =>   │2│3│4│5│6│ │ │ │
        //  └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 문제발생 -
        // 큐의 삭제 과정시 나머지 데이터를 앞당겨야하는 N번의 작업 발생
        //  ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        //  │1│2│3│4│5│6│ │ │   =>   │ │2│3│4│5│6│ │ │   =>   │2│3│4│5│6│ │ │ │
        //  └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘

        // 큐를 연결리스트로 구현??
        // -> C#에서는 노드 기반의 자료구조가 효율적이지 않음
        // 어떻게 문제를 해결할지? -> 데이터를 앞으로 안당기면 됨 => head, tail 표시
        // head : 다음에 빠질 위치, tail : 다음에 추가될 위치

        // 2. 전단 & 후단
        // 삽입 & 삭제 시 데이터를 앞당기지 않고 head와 tail을 표시하여 삽입할 위치와 삭제할 위치를 지정
        //
        // - 삽입 -
        // tail 위치에 데이터를 추가하고 tail을 한칸 뒤로 이동
        //     h       t                h         t
        //     ↓       ↓                ↓         ↓      
        //  ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        //  │ │2│3│4│5│ │ │ │   =>   │ │2│3│4│5│6│ │ │
        //  └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 삭제 -
        // head 위치에 데이터를 추가하고 head을 한칸 뒤로 이동
        //     h         t                h       t
        //     ↓         ↓                ↓       ↓
        //  ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        //  │ │2│3│4│5│6│ │ │   =>   │ │ │3│4│5│6│ │ │
        //  └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 문제발생 -
        // 큐의 배열 마지막 위치까지 사용하는 경우 빈자리가 없어 저장 불가한 상황 발생
        //       h         t              h           t
        //       ↓         ↓              ↓           ↓
        //  ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        //  │ │ │3│4│5│6│7│ │   =>   │ │ │3│4│5│6│7│8│
        //  └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘ 

        // head, tail은 맨 마지막까지 사용하는 경우가 위험함
        // -> 순환 배열을 이용
        // -> tail이 맨 뒤로가면 앞으로 이동(꼬리잡기)


        // 3. 순환배열
        // 배열의 끝까지 도달하여 빈자리가 없을 경우 처음으로 돌아가서 빈공간을 활용
        //
        // - 마지막위치 도달시 -
        // 다시 가장 앞 위치를 사용하여 빈공간을 재활용
        //          h     t          t       h           
        //          ↓     ↓          ↓       ↓           
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │ │ │ │ │5│6│7│ │   =>   │ │ │ │ │5│6│7│8│
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 문제발생 -
        // tail이 head을 침범하는 경우 모든 공간이 비어있는 상황과 가득차 있는 상황을 구분할 수 없음
        // 
        //         th                       th       
        //         ↓↓                       ↓↓       
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │ │ │ │ │ │ │ │ │        │5│6│7│8│1│2│3│4│
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘
        //   비어있는 경우             가득찬 경우

        // tail이 계속 추가되어 한번 순환하고 head와 겹치면??
        // -> head와 tail이 일치하면 비어있다 -> head 전 칸에 tail이 있다면?
        // -> 가득 차있고 배열을 더 크게 만들어야 한다

        // 4. 포화상태확인
        // head와 tail이 일치하는 경우를 비어있는 경우로 판정
        // tail이 head 전위치에 있는 경우를 실제로는 한자리가 비어있지만 가득찬 경우로 판정
        //         th                      t h       
        //         ↓↓                      ↓ ↓       
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │ │ │ │ │ │ │ │ │        │5│6│7│ │1│2│3│4│
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘
        //   비어있는 경우         가득찬 경우(로 판정)

        // C++은 연결 리스트로 구현. C#은 노드 기반에서 메모리 사용 문제가 있어(파편화) 순환배열로 구현

        static void Main(string[] args)
        {
            // Queue 클래스를 활용하여 큐를 만들 수 있음
            Queue<int> queue = new Queue<int>();

            // 데이터 집어넣기
            // 1. Enqueue
            for(int i = 0; i < 5; i++)
            {
                queue.Enqueue(i); // 0 1 2 3 4순으로 집어넣기
            }

            // 큐의 최상단 확인하기
            Console.WriteLine(queue.Peek()); // 0
            // 큐 안의 데이터 수 확인하기
            Console.WriteLine(queue.Count);  // 5

            // 데이터 꺼내기
            // 1. Dequeue
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(queue.Dequeue());
                // 0 1 2 순으로 꺼내짐
            }

            Console.WriteLine(queue.Peek());            // 다음순서 : 3

            for (int i = 5; i < 10; i++)
            {
                queue.Enqueue(i);                       // 입력순서 : 5, 6, 7, 8, 9
            }
            // 현재 상황 3 4 5 6 7 8 9
            Console.WriteLine(queue.Peek());            // 다음순서 : 3

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());     // 출력순서 : 3, 4, 5, 6, 7, 8, 9
            }
        }
    }
}