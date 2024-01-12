﻿namespace _02._LinkedList
{
    // 리스트 -> 접근에 있어 좋음.다만 추가 삭제에 아쉬움이 있음
    // 무조건 연속적으로 데이터를 보관해야 함 -> 중간에 추가, 삭제가 나머지 자료를 이동해야 함
    // ⇒ 효율적인 관리가 필요

    // 배열은 연속적으로 데이터를 포함해야 하는 특징이 있음(비어있는 공간이 없다)
    // -> 따로 따로 보관할 순 없을까?? ⇒ 연결 리스트를 사용!

    // 연속적으로 두지 않는다 -> 따로따로 둔다 -> 어떻게 다음 위치를 찾을지???

    // 배열과 연결리스트
    // 1 2 3 4 5 6 -> 배열(인덱스로 관리)
    // 1   2 4   3  5 -> 따로따로 두면??? -> 데이터만 보관하면 찾을 수 없음

    // 배열은 인덱스가 정해져 있으니 데이터만 보관하고, 인덱스로 접근하면 됨
    // 연결리스트는 데이터와 함께 다음 위치도 함께 보관해서 사용함

    // 연결식? -> 중간에 하나 지워버려도, 추가하여도, 위치를 연결시켜주면 됨

    // ex) A가 B를 B가 C를 가리키고 있는데 B를 지우면? A가 C를 가리킬 수 있도록 수정하면 문제없음
    // 중간에 F를 삽입하여도, A가 F를, F가 C를 가리키게 하면 문제없음 => 추가, 삭제에 데이터의 이동이 필요없음

    // 정리
    // 연결 리스트는 데이터와 함께 다음 위치를 가리키는 것도 함께 저장함
    // 데이터가 몇개가 있던, 하나를 지우거나 추가하여도 연결만 잘 관리하면 한번에 해결 가능


    // 연결리스트(Linked List)

    // 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
    // 데이터와 다른 데이터 지점의 참조변수를 가진 노드를 기본 단위로 사용
    // 데이터를 노드를 통해 연결식으로 구성하기 때문에 데이터의 추가/삭제에 유용
    // 노드가 메모리에 연속적으로 배치되지 않고 연결 구조로 다른 데이터의 위치를 확인

    // ※ 노드(마디, 단계)?
    // 데이터 뿐만 아니라 관리를 위한 추가 정보를 단위로 보관하는 개념

    // <연결리스트 구현>
    // 연결리스트는 노드를 기본 단위로 연결식으로 구현
    // 노드간의 연결구조에 따라 단방향, 양방향, 환형 으로 구분
    //
    // 1. 단방향 연결리스트
    // 노드가 다음 노드를 참조
    // ┌────┬─┐  ┌────┬─┐  ┌────┬─┐  ┌────┬─┐
    // │Data│───→│Data│───→│Data│───→│Data│ │
    // └────┴─┘  └────┴─┘  └────┴─┘  └────┴─┘
    //
    // 2. 양방향 연결리스트
    // 노드가 이전/다음 노드를 참조
    // ┌─┬────┬─┐  ┌─┬────┬─┐  ┌─┬────┬─┐  ┌─┬────┬─┐
    // │ │Data│←────→│Data│←────→│Data│←────→│Data│ │
    // └─┴────┴─┘  └─┴────┴─┘  └─┴────┴─┘  └─┴────┴─┘
    //
    // 3. 환형 연결리스트
    // 노드가 이전/다음 노드를 참조하며, 시작 노드와 마지막 노드를 참조
    //  ┌──────────────────────────────────────────┐
    // ┌│┬────┬─┐  ┌─┬────┬─┐  ┌─┬────┬─┐  ┌─┬────┬│┐
    // │↓│Data│←────→│Data│←────→│Data│←────→│Data│↓│
    // └─┴────┴─┘  └─┴────┴─┘  └─┴────┴─┘  └─┴────┴─┘
    // -> 이건 언제 쓰는지?? => 페이지 넘기기!(끝에 도달하면 맨 처음으로 / 순환구조)

    // 연결 리스트의 장점
    // 추가, 삭제에서 연결 구조만 변경하면 나머지 데이터를 이동할 필요가 없음

    // <연결리스트 삽입>
    // 새로 추가하는 노드가 이전/이후 노드를 참조한 뒤
    // 이전/이후 노드가 새로 추가하는 노드를 참조함
    // 
    //          ┌─┬───┬─┐                      ┌─┬───┬─┐                      ┌─┬───┬─┐ 
    //          │ │ C │ │                    ┌───│ C │───┐                  ┌───│ C │───┐
    //          └─┴───┴─┘          =>        ↓ └─┴───┴─┘ ↓        =>        ↓ └─┴───┴─┘ ↓
    // ┌─┬───┬─┐         ┌─┬───┬─┐    ┌─┬───┬─┐         ┌─┬───┬─┐    ┌─┬───┬─┐ ↑     ↑ ┌─┬───┬─┐
    // │ │ A │←───────────→│ B │ │    │ │ A │←───────────→│ B │ │    │ │ A │───┘     └───│ B │ │
    // └─┴───┴─┘         └─┴───┴─┘    └─┴───┴─┘         └─┴───┴─┘    └─┴───┴─┘         └─┴───┴─┘

    // <연결리스트 삭제>
    // 삭제하는 노드의 이전 노드가 이후 노드를 참조한 뒤
    // 삭제하는 노드의 이후 노드가 이전 노드를 참조함
    // 
    //          ┌─┬───┬─┐                      ┌─┬───┬─┐                      ┌─┬───┬─┐
    //        ┌──→│ C │←──┐                    │ │ C │←──┐                    │ │ C │ │
    //        │ └─┴───┴─┘ │        =>          └─┴───┴─┘ │        =>          └─┴───┴─┘
    // ┌─┬───┬│┐         ┌│┬───┬─┐    ┌─┬───┬─┐         ┌│┬───┬─┐    ┌─┬───┬─┐         ┌─┬───┬─┐
    // │ │ A │↓│         │↓│ B │ │    │ │ A │──────────→│↓│ B │ │    │ │ A │←───────────→│ B │ │
    // └─┴───┴─┘         └─┴───┴─┘    └─┴───┴─┘         └─┴───┴─┘    └─┴───┴─┘         └─┴───┴─┘

    // <연결리스트 특징>
    // 연결리스트의 경우 데이터를 연속적으로 배치하는 배열과 다르게 연결식으로 구성
    // 따라서, 데이터의 추가/삭제 과정에서 다른 데이터의 위치와 무관하게 진행되므로 수월함
    // 하지만, 데이터의 접근 과정에서 연속적인 데이터 배치가 아니기 때문에 인덱스 사용 불가하여 처음부터 탐색해야 함

    // 배열? 0부터 연속적(0, 1, 2..), 다만 연결리스트는?? 어디 있는지 모름... 
    // 마구잡이로 엉켜 있을 수 있기 때문에 접근 과정에서는 모든 노드를 탐색해야 함

    // 연결리스트와 배열/리스트

    // 연결리스트  : 연결식. 추가/삭제 수월함, 접근 어려움
    // 배열/리스트 : 연속적. 접근 쉬움, 추가/삭제 어려움

    // <LinkedList의 시간복잡도>
    // 접근    탐색     삽입    삭제
    // O(n)    O(n)    O(1)    O(1)

    class Program
    {
        static void Main(string[] args)
        {
            // 연결리스트 만들기(리스트와 유사)
            LinkedList<string> linkedList = new LinkedList<string>();

            // 삽입(추가)
            // 반환형 노드 -> 추가, 삭제시 노드를 만드는 행위
            // LinkedListNode<string> node0 = linkedList.AddFirst("0번 데이터");
            // 기본적인 C#의 노드는 양방향

            // 1. AddFirst (맨 앞에 붙이기)
            LinkedListNode<string> node0 = linkedList.AddFirst("0번 데이터");  // 0
            LinkedListNode<string> node1 = linkedList.AddFirst("1번 데이터");  // 1 - 0

            // 2. AddLast (맨 뒤에 붙이기)
            LinkedListNode<string> node2 = linkedList.AddLast("2번 데이터");   // 1 - 0 - 2
            LinkedListNode<string> node3 = linkedList.AddLast("3번 데이터");   // 1 - 0 - 2 - 3
            
            // 3. AddBefore (특정 노드 앞), AddAfter (특정 노드 뒤)
            LinkedListNode<string> node4 = linkedList.AddBefore(node0, "0번 앞에 데이터"); // 1 <-> 4 <-> 0 <-> 2 <-> 3
            LinkedListNode<string> node5 = linkedList.AddBefore(node0, "0번 뒤에 데이터"); // 1 <-> 4 <-> 0 <-> 5 <-> 2 <-> 3


            // 삭제
            // 1. Remove(데이터) : 삭제할 데이터의 노드 찾아서 지우기, 반환형 bool (효율 좋지 않음 O(n))
            linkedList.Remove("1번 데이터");        // 4 0 5 2 3
            linkedList.Remove("1번 데이터");        // 1번 데이터 없으므로 false 

            // 2. Remove(노드) : 삭제할 노드를 직접적으로 지정하기(O(1))
            linkedList.Remove(node3);              // 4 0 5 2

            // 3. RemoveFirst (맨 앞의 노드), RemoveLast (맨 뒤의 노드)
            linkedList.RemoveFirst();              // 0 5 2
            linkedList.RemoveLast();               // 0 5 


            // 접근
            // 1. First (첫번째 노드), Last (마지막 노드) : 반환값 노드
            LinkedListNode<string> first = linkedList.First;  // 0
            LinkedListNode<string> last = linkedList.Last;    // 5

            // 2. Previous (노드를 기준 이전), Next (노드를 기준 다음) : 반환값 노드
            LinkedListNode<string> prev = node0.Previous;     // x
            LinkedListNode<string> next = node0.Next;         // 5


            // 탐색
            // 1. Find (특정 데이터의 노드 찾기) : 반환값 노드
            LinkedListNode<string> findNode = linkedList.Find("0번 데이터");    // node0
        }
    }
}