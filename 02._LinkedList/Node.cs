using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList
{
    class Node
    {
        // 노드 (Node)
         
        // 여러 자료구조에서 사용하는 기본 단위(정점)
        // 데이터와 다른 노드를 참조하는 값을 가짐(간선 / 연결 관리)
        // 다른 노드의 참조를 연결하는 방식에 따라 여러 자료구조를 구현가능

        // 노드는 쉽게 생각하면 길찾기? -> 정점과 간선 (ⓐ---ⓑ---ⓒ---ⓓ) 

        // <노드 구현>
        // 노드에 데이터와 다른 노드를 참조하는 값을 구성하여 구현

        // 연결된 노드를 가지는 일정갯수의 변수 또는 배열을 통해 고정적인 연결구조를 가짐
        // 연결구조가 일정한 연결리스트/트리 등에 사용

        public class LinkedListNode<T>
        {
            public T value; // 값(데이터)

            //    prev  value  next
            //ⓟ  ----   ⓥ    ----  ⓝ
            public LinkedListNode<T> prev; // 연결 선(참조) / 이전 노드의 위치
            public LinkedListNode<T> next; // 연결 선(참조) / 다음 노드의 위치
        }

        // 이진(2)트리의 노드
        public class BinaryTreeNode<T>
        {
            public T value;

            public BinaryTreeNode<T> parent;
            public BinaryTreeNode<T> left;
            public BinaryTreeNode<T> right;
        }

        // 옥타(8)트리의 노드
        public class OctTreeNode<T>
        {
            public T value;

            public OctTreeNode<T> parent;
            public OctTreeNode<T>[] children = new OctTreeNode<T>[8];
        }

        // 연결된 노드를 가지는 List를 통해 유동적인 연결구조를 가짐
        // 연결구조가 일정하지 않은 트리/그래프 등에 사용
        public class AdjacentNode<T>
        {
            public T value;

            public List<AdjacentNode<T>> connect = new List<AdjacentNode<T>>();
        }
    }
}
