using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    // 우선순위 큐 구현
    // TElement : 실제 데이터, TPriority : 우선순위 / 우선순위는 비교할 수 있어서 제약사항
    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        // 구조체로 만드는 이유? 배열로 구현하려고
        private struct Node
        {
            public TElement element;
            public TPriority priority;

            public Node(TElement element, TPriority priority)
            {
                this.element = element;
                this.priority = priority;
            }
        }

        private List<Node> nodes;

        public PriorityQueue()
        {
            nodes = new List<Node>();
        }

        // 우선순위큐에 넣을 데이터와 우선순위 메소드
        public void Enqueue(TElement element, TPriority priority)
        {
            // 가장 뒤에 추가하고 부모와 비교해서 상승작업이 더 이상 올라가지 않을 때 까지 반복해서 필요함
            Node newNode = new Node(element, priority);

            // 리스트의 맨 뒷자리에 넣기
            nodes.Add(newNode);

            // 현재 인덱스 -> 리스트의 가장 끝
            int index = nodes.Count - 1;

            while(index > 0)
            {
                // 부모의 인덱스와 인덱스를 통해 노드 찾기
                int parentIndex = (index - 1) / 2;
                Node parentNode = nodes[parentIndex];

                // 부모의 우선순위와 비교
                // newNode.CampareTo(parentNode)의 값이 0보다 작다? -> newNode 값이 더 작다
                if(newNode.priority.CompareTo(parentNode.priority) < 0)
                {
                    // 상승
                    nodes[index] = parentNode;
                    nodes[parentIndex] = newNode;
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        // 우선순위큐에서 빠질 데이터
        public TElement Dequeue()
        {
            Node rootNode = nodes[0];

            // 제거작업 -> 마지막 데이터와 교체하고 대신 지움
            // 맨 위의 노드를 지우면 힙이 깨져버리니까
            Node lastNode = nodes[nodes.Count - 1];
            nodes[0] = lastNode;

            // 가장 마지막 데이터 지워짐
            nodes.RemoveAt(nodes.Count - 1);

            // 그 다음 하강 작업을 반복
            int index = 0;
            while(index < nodes.Count)
            {
                // 왼쪽 자식과 오른쪽 자식을 비교해서 하강할 위치 선정하기
                int leftIndex = (index * 2) + 1;
                int rightIndex = (index * 2) + 2;
                
                // 자식의 수에 따라 하강이 변함

                if(rightIndex < nodes.Count)      // 자식이 둘 다 있는 경우(오른쪽 자식이 있다면 왼쪽 자식은 반드시 있음)
                {
                    // 더 작은 자식과 교체해야 함
                    int lessIndex;

                    // 더 작은 자식 찾기
                    if (nodes[leftIndex].priority.CompareTo(nodes[rightIndex].priority) < 0)
                    {
                        lessIndex = leftIndex;
                    }
                    else
                    {
                        lessIndex = rightIndex;
                    }
                    
                    // 더 작은 자식과 비교하기
                    Node lessNode = nodes[lessIndex];
                    // 작은 자식과 비교해서 크면 하강하기
                    // A.CampareTo(B)의 값이 0보다 크다? -> A값이 B보다 더 크다
                    if (nodes[index].priority.CompareTo(nodes[lessIndex].priority) > 0)
                    {
                        nodes[lessIndex] = lastNode;
                        nodes[index] = lessNode;
                        index = lessIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else if(leftIndex < nodes.Count)  // 자식이 하나만(왼쪽 자식) 있는 경우
                {
                    Node leftNode = nodes[leftIndex];
                    if (nodes[index].priority.CompareTo(nodes[leftIndex].priority) > 0)
                    {
                        // 내려가기
                        nodes[leftIndex] = lastNode;
                        nodes[index] = leftNode;
                        index = leftIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else      // 자식이 없는 경우
                {
                    break;
                }
            }

            return rootNode.element;
        }


    }
}
