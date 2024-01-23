using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Search
{
    public class Graph
    {
        // 그래프(Graph)
        // 노드와 그 노드를 연결하는 간선을 하나로 모아 놓은 자료 구조
        // 순환 구조 => 시작에서 다른 방향을 통해 자기 자신으로 올 수 있음(연결 구조)
        // 지도, 노선도, 경로 파악

        // 트리(Tree)
        // 그래프의 한 종류
        // 부모와 자식 관계가 있고 자식이 여러 자식을 가질 수 있는 구조
        // 계층형 구조 => 자식에서 부모로 가는 경우가 없음

        /************************************************************************
        * 그래프 (Graph)
        * 
        * 정점(노드 / Vertex)의 모음과 이 정점을 잇는 간선(연결선 / Edge)의 모음의 결합
        * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐
        * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
        * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
        ************************************************************************/

        // 프로그램에서의 그래프 표현?
        // 2가지 방법이 있음(2차원 배열 / 행렬, 연결리스트)
        // 보통은 2차원 배열 / 행렬 방식을 선호함(더 빠름)

        // <인접행렬 그래프>
        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
        // 2차원 배열을 [출발정점, 도착정점] 으로 표현
        // 장점 : 인접여부 접근이 빠름
        // 단점 : 메모리 사용량이 많음

        // 예시 : 양방향 연결 그래프(중간을 기점으로 대칭)
        bool[,] matrixGraph1 = new bool[5, 5]
        {
            { false, false, false, false,  true },
            { false, false,  true, false, false },
            { false,  true, false,  true, false },
            { false, false,  true, false,  true },
            {  true, false, false,  true, false },
        };
        // 연결이 되어 있으면 true 아니면 false
        // [0,4] -> true : 0에서 4는 연결
        // [1,2] -> true : 1에서 2는 연결
        // [1,3] -> false : 1에서 3은 연결되지 않음

        // 가중치로 그래프 만들기 -> true, false가 아닌 숫자(int)로 표현
        const int INF = int.MaxValue;

        // 예시 - 단방향 가중치 그래프 (단절은 최대값으로 표현)
        int[,] matrixGraph2 = new int[5, 5]
        {
            {   0, 132, INF, INF,  16 },
            {  12,   0, INF, INF, INF },
            { INF,  38,   0, INF, INF },
            { INF,  12, INF,   0,  54 },
            { INF, INF, INF, INF,   0 },
        };
        // 0에서 1은 132 가중치, 1에서 0은 12가중치...
        // 0에서 2는 INF -> 무한히 걸린다 -> 단절 되어 있다


        // <인접리스트 그래프>
        // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
        // 인접한 간선만을 리스트에 추가하여 관리
        // 장점 : 메모리 사용량이 적음
        // 단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요

        public class Node<T> // 연결그래프
        {
            // 정점
            public T vertex;
            // 간선들
            public List<Node<T>> edge;
        }

        public class GrapeNode<T> // 가중치 그래프
        {
            public T vertex;
            // 간선들과 가중치값
            public List<(Node<T>, int)> edge;
        }
    }
}
