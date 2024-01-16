using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 자료형으로써 비교를 할 수 없는 자료형은 불가능함
    public class BinarySearchTree<T> where T : IComparable<T> // where? 자료형 제약 : 비교 가능한 자료형만 가능
    {
        private Node<T> root; // 루트노드 : 맨 위의 노드

        // 생성자
        public BinarySearchTree()
        {
            this.root = null; // 생성하였을 땐 루트노드 없음
        }

        // 새로운 노드를 만들고 루트부터 비교하여 빈자리를 찾을 때 까지
        public bool Add(T item)
        {
            Node<T> newNode = new Node<T>(item, null, null, null);

            if(root == null)
            {
                root = newNode;
                return true;
            }

            Node<T> current = root;
            
            // 1. 왼쪽
            //  1-1. 빈공간
            //  1.2. 아닌 경우

            while(current != null)
            {
                if(item.CompareTo(current.item) < 0)
                {
                    // 왼쪽으로 가는 경우(현재 노드와 비교했을 때 값이 작은 경우)
                    if(current.left != null)
                    {
                        // 왼쪽 자식이 있는 경우
                        // 왼쪽으로 가서 계속 하강작업을 반복
                        current = current.left;
                    }
                    else
                    {
                        // 왼쪽 자식이 없는 경우
                        // 왼쪽에 추가
                        current.left = newNode;   // 왼쪽은 새로운 노드
                        newNode.parent = current; // 새로운 노드의 부모는 현재 노드
                        break;
                    }
                }
                else if(item.CompareTo(current.item) > 0)
                {
                    // 오른쪽으로 가는 경우(현재 노드와 비교했을 때 값이 큰 경우)
                    if(current.right != null)
                    {
                        // 오른쪽 자식이 있는 경우
                        // 오른쪽으로 가서 계속 하강작업을 반복
                        current = current.right;
                    }
                    else
                    {
                        // 오른쪽 자식이 없는 경우
                        // 오른쪽에 추가
                        current.right = newNode;
                        newNode.parent = current;
                        break;
                    }
                }
                else
                {
                    // 똑같은 값은 허용하지 않음
                    // 중복 무시
                    return false;
                }
            }

            return true;
        }

        // 원하는 값 하나 지우기
        public bool Remove(T item)
        {
            // 찾고
            Node<T> findNode = FindNode(item); 

            // 없으면 false
            if(findNode == null)
            {
                return false;
            }
            else // 찾으면 지우고 true
            {
                EraseNode(findNode);
                return true;
            }

        }

        // 해당 값이 트리에 있는지?
        public bool Contains(T item)
        {
            // 탐색으로 쉽게 해결
            Node<T> findNode = FindNode(item);

            if(findNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // 탐색 : 노드 찾기
        private Node<T> FindNode(T item)
        {
            // 루트가 없으면 하나도 없음
            if(root != null)
            {
                return null;
            }

            Node<T> current = root;

            while(current != null)
            {
                if(item.CompareTo(current.item) < 0)
                {
                    // 왼쪽으로 가는 경우
                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    // 오른쪽으로 가는 경우
                    current = current.right;
                }
                else
                {
                    // 똑같은 것을 발견한 경우
                    // 찾았다. (탐색 완료)
                    return current;
                }
            }

            return null;
        }

        // 노드 지우기
        // 3가지 상황(자식 0개, 1개, 2개)
        private void EraseNode(Node<T> node)
        {
            if(node.HasNoChild)
            {
                // 자식이 0개인 경우
                // -> 단순 삭제(부모의 연결 끊기)
                if(node.IsLeftChild)
                {
                    // 부모의 왼쪽 없음
                    node.parent.left = null;
                }
                else if(node.IsRightChild)
                {
                    // 부모의 오른쪽 없음
                    node.parent.right = null;
                }
                else // 루트 노드인 경우
                {
                    // 루트가 사라짐
                    root = null;
                }
            }
            else if(node.HasLeftChild || node.HasRightChild)
            {
                // 자식이 1개인 경우
                // 부모와 자식을 연결해주고 자기 자신은 사라지면 됨
                Node<T> parent = node.parent;
                Node<T> child = node.HasLeftChild ? node.left : node.right;

                // 부모 - 자신 - 자식 => 부모 - 자식
                // 부모와 자식을 연결해주고 삭제
                if (node.IsLeftChild)
                {
                    parent.left = child;
                }
                else if(node.IsRightChild)
                {
                    parent.right = child;
                }
                else // 루트 노드일 때
                {
                    // 자식이 루트가 됨
                    root = child;
                    child.parent = null;
                }
            }
            else
            {
                // 자식이 2개인 경우
                // 직접 지울 수 없음 -> 오른쪽 자식 중 제일 작은 값과 교체하고 삭제
                Node<T> nextNode = node.right;
                while(nextNode.left != null) // 오른쪽 자식 중 제일 작다? -> 왼쪽 자식이 없다
                {
                    nextNode = nextNode.left;
                }
                // 교체를 하고
                node.item = nextNode.item;
                EraseNode(nextNode);
            }
        }

    }

    // 노드 클래스
    public class Node<T>
    {
        public T item; // 값 데이터

        public Node<T> parent; // 부모
        public Node<T> left;   // 왼쪽
        public Node<T> right;  // 오른쪽

        // 생성자
        public Node(T item, Node<T> parent, Node<T> left, Node<T> right)
        {
            this.item = item;
            this.parent = parent;
            this.left = left;
            this.right = right;
        }
        
        // 루트노드 -> 부모가 없다
        public bool IsRootNode { get { return parent == null; } }
        // 왼쪽 자식인가? -> 부모가 있고 부모의 왼쪽이 나
        public bool IsLeftChild { get { return parent != null && parent.left == this; } }
        // 오른쪽 자식인가? -> 부모가 있고 부모의 오른쪽이 나
        public bool IsRightChild { get { return parent != null && parent.right == this; } }

        // 자식이 없다(왼쪽 오른쪽이 전부 비어 있다)
        public bool HasNoChild { get { return left == null && right == null; } }
        // 왼쪽 자식이 있다
        public bool HasLeftChild { get { return left == null && right != null; } }
        // 오른쪽 자식이 있다
        public bool HasRightChild { get { return left != null && right == null; } }
        // 자식이 둘 다 있다
        public bool HasBothChild { get { return left != null && right != null; } }
    }
}
