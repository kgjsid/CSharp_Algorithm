using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class _LinkedList<T> // 연결 리스트 구현
    {
        private _LinkedListNode<T> head; // 제일 앞
        private _LinkedListNode<T> tail; // 제일 뒤
        private int count;              // 연결리스트 요소의 수

        public _LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public _LinkedListNode<T> First { get { return head; } }
        public _LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public _LinkedListNode<T> AddFirst(T value) // AddFirst 구현
        {
            _LinkedListNode<T> newNode = new _LinkedListNode<T>(value);

            if(head == null)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeBefore(head, newNode); // 맨 처음에 붙이기 -> 헤드 앞에 붙이기
            }

            return newNode;
        }

        public _LinkedListNode<T> AddBefore(_LinkedListNode<T> node, T value)
        {
            _LinkedListNode<T> newNode = new _LinkedListNode<T>(value);
            InsertNodeBefore(node, newNode);
            return newNode;
        }

        public _LinkedListNode<T> AddLast(T value)
        {
            _LinkedListNode<T> newNode = new _LinkedListNode<T>(value);

            if(tail == null)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            { 
                InsertNodeAfter(tail, newNode);
            }
            return newNode;
        }

        public _LinkedListNode<T> AddAfter(_LinkedListNode<T> node, T value)
        {
            _LinkedListNode<T> newNode = new _LinkedListNode<T>(value);
            InsertNodeAfter(node, newNode);
            return newNode;
        }
        // node가 head인 경우
        // 1. newNode의 next를 node로 바꾸기
        // 2. node의 prev를 newNode로 바꾸기

        // node가 head가 아니라 앞에 다른 노드가 있는 경우
        // newNode의 이전 이후 그리고 두 노드의 이전(뒤) 이후(앞)가 바뀌어야 함

        //                      prev | newnode | next 
        // prev | prevnode | next                   prev | node | next
        //
        // prevnode 가 없으면 newnode가 헤드

        public bool Remove(T value)
        {
            _LinkedListNode<T> findNode = Find(value);
            if(findNode != null)
            {
                RemoveNode(findNode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(_LinkedListNode<T> node)
        {
            RemoveNode(node);
        }

        public void RemoveFirst(_LinkedListNode<T> node)
        {
            RemoveNode(head);
        }

        public void RemoveLast(_LinkedListNode<T> node)
        {
            RemoveNode(tail);
        }

        public _LinkedListNode<T> Find(T value)
        {
            for(_LinkedListNode<T> node = First; node != null; node = node.next)
            {
                if (value.Equals(node.Value))
                    return node;
            }

            return null;
        }

        private void InsertNodeBefore(_LinkedListNode<T> node, _LinkedListNode<T> newNode) // node앞에 newNode 붙이기
        {
            // 1. newNode의 prev를 node의 prev로
            newNode.prev = node.prev;

            // 2. newNode의 next는 node로
            newNode.next = node;

            // 3. node 앞의 노드의 유무에 따라
            if (node == head)    // 3-1. head를 newNode로
            {
                head = newNode;
            }
            else // 3-2. node의 prev의 next를 newNode로
            {
                node.prev.next = newNode;
            }

            // 4. node의 prev를 newNode로
            node.prev = newNode;

            count++;
        }

        //                   prev | newnode | next 
        // prev | node | next                   prev | nextnode | next                   

        private void InsertNodeAfter(_LinkedListNode<T> node, _LinkedListNode<T> newNode) // node뒤에 newNode 붙이기
        {
            // 1. newNode의 prev을 node로
            newNode.prev = node;
            // 2. newNode의 next은 node의 next로
            newNode.next = node.Next;

            // 3. 만약 node가 tail이면??
            if(node == tail) // tail을 newNode로
            {
                tail = newNode;
            }
            else            // nextnode의 prev를 newNode로
            {
                node.next.prev = newNode;
            }
            node.next = newNode; // node의 next를 newNode로

            count++;
        }

        private void InsertNodeToEmptyList(_LinkedListNode<T> newNode)
        {
            // 비어 있는 리스트에 노드 추가
            head = newNode;
            tail = newNode;
            count++;
        }

        private void RemoveNode(_LinkedListNode<T> node)
        {
            // 예외처리 : 없는 노드 지우기는 불가능
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            //                        prev | node | next 
            // prev | node.prev | next                   prev | node.next | next     
            if(head == node)
            {
                head = node.next;
            }
            if(tail == node)
            {
                tail = node.prev;
            }

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;
        }
    }

    public class _LinkedListNode<T> // 노드 구현
    {
        private T value;                    // 노드가 가지고 있는 값

        public _LinkedListNode<T> prev;    // 노드의 이전 참조
        public _LinkedListNode<T> next;    // 노드의 다음 참조

        public _LinkedListNode(T value)
        {
            this.value = value;
            this.prev = null;
            this.next = null;
        }

        public _LinkedListNode(T value, _LinkedListNode<T> prev, _LinkedListNode<T> next)
        {
            this.value = value;
            this.prev = prev;
            this.next = next;
        }

        public _LinkedListNode<T> Prev { get { return prev; } } // 이전 노드 프로퍼티
        public _LinkedListNode<T> Next { get { return next; } }  // 다음 노드 프로퍼티
        public T Value
        {
            get { return value; }
            set { this.value = value; } // 값 가져오기
        }

    }
}