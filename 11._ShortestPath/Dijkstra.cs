using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._ShortestPath
{
    // → BFS, DFS는 연결 되어 있는 그래프에서 다른 정점으로 갈 수 있냐 없냐(탐색의 가능 여부 + 어떤 경로인지)를 파악하기에 좋음
    // ⇒ 방문 가능 여부와 누가 탐색하였는지 찾기에 유용한 알고리즘임

    // → 만약 가중치가 포함되면?? → 깊이 우선과 너비 우선과는 다르게 생각해야 함
    // → 더 빠른 경로가 존재하는데 깊이, 너비 우선은 그것을 무시하고 탐색함
    // → 탐색에 있어 가중치가 생기면 추가 고려 사항이 생김 ⇒ 최단 거리가 무엇이냐

    // ex) A에서 B까지 50 / A에서 C를 가는데 10 + C에서 D를 가는데 10 + D에서 B를 가는데 10
    // A → B(50) 보다 A → C → D → B(30)가 최단 거리임
    // → 가중치가 있다면 다른 알고리즘이 필요하다 ⇒ 데이크스트라 알고리즘

    public class Dijkstra
    {
        /********************************************************************
        * 다익스트라 알고리즘 (Dijkstra Algorithm)
        * 
        * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
        * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
        * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
        ********************************************************************/

        // 다익스트라는 두 가지만 고려
        // 1. 가장 가까운 정점을 선정하는 것
        // 2. 선택한 정점을 거쳐서 가는 경로 중 distance(거리)를 짧은 것으로 변경한다

        // A->B / A->B->C
        // 직접 가는 것 보다 경유해서 가는 것이 더 작다면?
        // 해당 경로로 가자(A->B->C) / 해당 경로로 생각하자

        // A -> B : 30 / A -> C : 50?? => 굳이 검사할 필요가 있는지??
        // C선정에 있어 가장 가까운 정점부터 선정

        // 가장 가까운 정점부터 선정하여 해당 정점을 거쳐 더 짧아지는 경우가 존재
        // -> 해당 거리를 갱신시켜주는 작업을 반복
        // => 결과적으로 시작 정점으로부터 다른 정점까지의 거리가 최단거리가 되어버림

        const int INF = 99999; // 단절 상태 표현
        
        // distance : 거리
        public static void ShortestPath(int[,] graph, int start, out bool[] visited, out int[] distance, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            distance = new int[size];
            parents = new int[size];

            // 초기 세팅
            for(int i = 0; i < size; i++)
            {
                visited[i] = false;
                distance[i] = INF;
                parents[i] = -1;
            }

            // 시작 지점의 길이는 0
            distance[start] = 0;

            for(int i = 0; i < size; i++)
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점 선택
                // 방문하지 않은 정점(next) 찾기
                int next = -1;      // -1은 찾지 못한 경우
                int minDistance = INF;
                for(int j = 0; j < size; j++)
                {
                    if (!visited[j] &&              // 방문하지 않았으며
                        distance[j] < minDistance)  // 거리가 더 짧은 경우에
                    {   // 해당 정점을 방문할 예정이다
                        next = j;
                        minDistance = distance[j];
                    }
                }

                Console.WriteLine($" \n{start}부터 다음 최소 거리의 정점 : {next} 거리 : {minDistance}");
                // 단절되어 있는 경우?? -> 연결이 없음 -> 탐색 불가
                if (next < 0)
                    break;

                Console.WriteLine();

                if (i != 0)
                    Console.WriteLine($"방문 예정지 : {next}\n");

                // 2. 직접연결된 거리보다 거쳐서 더 짧아지는 경우 갱신

                // 모든 정점을 확인해 보자
                for (int j = 0; j < size; j++)
                {
                    // (A -> B) distance[j] : 목적지까지 직접 연결된 거리
                    // (A -> C) distance[next] : 탐색중인 정점까지 거리
                    // (B -> C) graph[next, j] : 탐색중인 정점부터 목적지까지의 거리

                    // A -> B보다 A -> C -> B가 더 짧다면??
                    // => 거리를 변경시킨다(최단 거리 갱신)
                    if (graph[next, j] != INF)
                        Console.WriteLine($"{next} 에서 {j} 까지의 거리 {graph[next, j]}");
                    
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        // 다른 경로가 생김
                        parents[j] = next;
                    }
                }

                // 해당 정점은 방문하였으니
                visited[next] = true;
                Console.WriteLine($"{next}에서 갈 수 있는 경로 탐색 완료");
            }
        }

    }
}
