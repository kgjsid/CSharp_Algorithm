using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._ShortestPath.과제
{
    // 데이크스트라 구현
    class _01
    {
        const int INF = 99999;
        public void Ds(int[,] graph, int start, out int[] distance, out bool[] visited, out int[] parents)
        {
            // 기준 사이즈 측정
            int size = graph.GetLength(0);

            distance = new int[size];
            visited = new bool[size];
            parents = new int[size];

            // 초기 설정
            for(int i = 0; i < size; i++)
            {
                distance[i] = INF;
                visited[i] = false;
                parents[i] = -1;
            }

            // 시작 위치의 거리는 0
            // 자기 자신과의 거리니까 0
            distance[start] = 0;

            for (int i = 0; i < size; i++)
            {
                // next -> 다음에 갈 정점
                int next = -1;
                // 다음에 갈 정점은 가장 짧은 값이니 해당 값을 찾아야 함
                int minDistance = INF;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j]) // 방문하지 않은 정점 중
                    {
                        if (distance[j] < minDistance) // 최단 거리 찾기
                        {
                            // 찾았다면 next는 다음 정점
                            next = j;
                            // 최솟값 저장해 두고 비교하기
                            minDistance = distance[j];
                        }
                    }
                }
                // next가 -1에서 변하지 않았다?
                // 갈 수 있는 정점이 없다
                if (next == -1)
                {
                    Console.WriteLine("연결되어 있는 정점이 없습니다");
                    break;
                }

                // 다음 정점에 가서 최단 경로를 계산할 예정이니
                // 방문 하였다고 바꾸고
                visited[next] = true;

                for (int j = 0; j < size; j++)
                {
                    // 해당 경로로 직선으로 가는 것과
                    // next를 경유해서 가는 경우를 비교해서 최단 거리 갱신
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];

                        parents[j] = next;
                    }
                }
            }
        }
    }
}
