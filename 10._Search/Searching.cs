using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _10._Search
{
    public class Searching
    {
        // <순차탐색>
        // 자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
        // 시간복잡도 : O(n)

        // list안에서 item 찾기
        // 시작부터 끝까지 쭉 둘러보는 방식 / 반드시 원하는 데이터를 찾을 수 있음
        public static int SequentialSearch<T>(IList<T> list, T item) where T : notnull // T에는 null 아닌 것만
        {
            // 리스트의 요소를 전부 탐색하며
            for (int i = 0; i < list.Count; i++)
            {
                // 현재 리스트의 요소가 item과 동일하면
                if (list[i].Equals(item))
                {
                    // 해당 인덱스 리턴
                    return i;
                }
            }
            // 없다면? -1 리턴(찾지 못했다)
            return -1;
        }

        // <이진탐색>
        // 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색 
        // 단, 이진 탐색은 정렬이 되어 있는 자료에만 올바른 결과를 도출
        // 시간복잡도 : O(logn)

        // ex) 1 2 3 4 5 6 7 8 9에서 3 찾기??
        // 정 중앙을 기점으로 작을 땐 왼쪽, 클 땐 오른쪽

        // 1. 제일 작은 위치 low, 제일 큰 위치 high, 중간 값 middle
        // 2-1. 찾고자 하는 값이 만약 middle보다 더 작은 값? -> high를 middle 전 칸으로 옮기기(왼쪽 범위)
        // 2-2. 찾고자 하는 값이 만약 middle보다 더 큰 값? -> low를 middle 다음 칸으로 옮기기(오른쪽 범위)
        // 3. 원하는 값을 찾기 위해 low와 high를 이용해 범위를 줄여나감
        // 4. low, high, middle이 동일한 위치를 가리키면 해당 값을 찾아낸 것.

        // 1 2 3 4 5 6 7 8 9 -> 3찾기
        // L       M       H -> 5보다 3가 작으므로 H를 M전칸으로
        // L M   H           -> M을 새로 설정(1+4 / 2 => 2) / 2보다 3이 크므로 L를 M다음 칸으로
        //     L H           -> M을 새로 설정(3+4 / 2 => 3) / M위치가 3이 되니 원하는 값 찾음

        public static int BinarySearch<T>(IList<T> list, T item) where T : IComparable<T> // 정렬은 비교가 가능할 수 있는 자료형만
        {
            // 시작 위치
            int low = 0;
            // 끝 위치
            int high = list.Count - 1;

            // 반복은 똑같거나, 안좁혀졌을 때 까지
            while (low <= high)
            {
                // 중간 값 구하기
                int mid = (high + low) / 2;
                int compare = list[mid].CompareTo(item);
                // A.CompareTo(B) 의 결과
                // 1. 음수 -> A보다 B가 더 크다
                // 2. 양수 -> A보다 B가 더 작다
                // 3. 0 -> A와 B가 같다 

                if (compare < 0)
                {
                    // 찾고자 하는 값(item)이 중간값보다 크다면
                    // low를 뒤으로 당기기(오른쪽 범위)
                    low = mid + 1;
                }
                else if (compare > 0)
                {
                    // 찾고자 하는 값(item)이 중간값보다 작다면
                    // high를 앞으로 당기기(왼쪽 범위)
                    high = mid - 1;
                }
                else
                {   // 중간 값이 딱 원하는 것이였다면?
                    // 해당 값의 인덱스를 찾아낸 것
                    return mid;
                }
            }

            // 만약 위의 반복문을 실행하였는데 원하는 값이 없다면
            return -1;
        }


        // 그래프의 탐색?
        // 특정 정점으로부터 특정 정점으로 이동할 수 있는가?
        // (0번에서 5번으로 갈 수 있는가? / 연결되어 있는가?)

        // 어떤 기준으로 탐색할까?
        // 모든 정점을 탐색하는 것이 기본임(순회)
        // 크게 두 가지 기준이 존재함 -> DFS, BFS

        // DFS (Depth - First - Search)
        // 깊게까지 쭉 내려간뒤 더 이상 내려갈 수 없으면 다른 분기를 가자
        // 일단 들이박자

        // BFS (Breadth - First - Search)
        // 우선 한 칸 떨어진 곳에서 탐색하고 찾지 못하면 한 칸씩 넘어가며 보는 방법
        // 같은 깊이를 한번 쭉 보는 형식
        // 너비 우선적

        // <깊이 우선 탐색 (Depth-First Search)>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 분기의 탐색을 마쳤을 때 다음 분기를 탐색
        // 스택(함수 호출 스택)을 통해 구현 -> 최대한 깊게 내려간다? 최신 상황에서 탐색이 필요
        // 문제가 발생하였을 때 이전 호출 지점을 찾기에 좋음

        // DFS 구현
        // graph : 그래프, start : 시작점, visited : 정점을 찾을 수 있는지 여부, parent : 누구에 의해 탐색이 가능한지
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
        {
            // 정점의 수
            visited = new bool[graph.GetLength(0)];
            // visited[0] = false? -> 0 정점을 갈 수 없다
            // visited[2] = true? -> 2 정점은 탐색 가능하다
            parent = new int[graph.GetLength(1)];
            // parent[1] = 2 -> 2정점이 1정점으로 갈 수 있다(찾을 수 있다)
            // parent[3] = -1 -> 3정점은 아무도 올 수 없다

            // 기본 상황 세팅
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }

            // 시작 지점부터 시작
            SearchNode(graph, start, visited, parent);
        }

        public static void SearchNode(bool[,] graph, int start, bool[] visited, int[] parent)
        {
            // 시작 지점은 탐색이 가능 -> 시작이니까 탐색이 된 곳
            visited[start] = true;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                // [출발 정점, 도착 정점] -> start를 기준으로 연결된 정점을 확인
                if (graph[start, i] &&  // 연결되어 있는 정점이며,
                    !visited[i])         // 방문한적 없는 정점
                {
                    parent[i] = start; // i는 start에 의해 탐색되었다
                    // 그 후 탐색한 정점으로 부터 다음 위치로 가기
                    SearchNode(graph, i, visited, parent);
                }
            }
        }

        // <너비 우선 탐색 (Breadth-First Search)>
        // 그래프의 분기를 만났을 때 모든 분기들을 탐색한 뒤,
        // 다음 깊이의 분기들을 탐색
        // 큐를 통해 탐색 -> 다음에 갈 정점들을 전부 큐에 넣어서 구현
        // 탐색할 정점들을 큐에 담아두고 큐의 내용을 하나씩 꺼내며 해당 정점을 탐색하는 식으로 진행
        // => 항상 최단경로가 나옴

        // BFS 구현
        public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
        {
            // 사전 세팅은 DFS와 동일            
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(1)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }

            // 큐로 BFS를 구현
            Queue<int> queue = new Queue<int>();
            // 시작 데이터를 큐에 넣음
            queue.Enqueue(start);
            visited[start] = true;

            // 큐의 데이터를 다 빼낼 때 까지 반복
            while (queue.Count > 0)
            {
                // 다음 탐색 위치를 위해 큐에서 데이터 하나를 빼내기
                int next = queue.Dequeue();

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    // [출발 정점, 도착 정점] -> start를 기준으로 연결된 정점을 확인
                    if (graph[next, i] &&    // 연결되어 있는 정점이며,
                        !visited[i])         // 방문한적 없는 정점
                    {
                        parent[i] = next; // i는 next에 의해 탐색되었다
                        visited[i] = true;
                        queue.Enqueue(i);  // 탐색된 데이터는 큐에 넣기
                    }
                }
            }
        }

        // DFS, BFS 둘 다 모두 병행해서 사용
        // BFS는 최단거리를 보장
        // DFS는 실행순서를 보장해 주므로 이전 노드를 알 수 있음(유효성 검사)
    }
}