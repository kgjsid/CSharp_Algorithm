using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._PathFinding
{
    public class AStar
    {
        /************************************************************
         * A* 알고리즘
         * 
         * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
         * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
         ************************************************************/

        // 다익스트라에서 조금 더 유망한 해부터 탐색한다?

        // 게임? -> 보통 좌표계는 데카르트 좌표계(x, y, z)
        // 게임은 3D 공간이라던가 가상 공간에서 위치 이동을 하는 경우가 많음
        // 현실 상황에서도 북쪽, 서쪽으로 xm 이동한다 이렇게 표현하니 게임도 동일함

        // 만약 다익스트라 알고리즘을 통해 여러 경로들을 탐색한다?
        // 아쉬운 부분이 발생 -> 해당 경우에는 목적지를 알기 위해서 전방향으로 탐색이 필요함

        // 다익스트라의 경우
        // 다음으로 탐색할 정점 선택 기준 자체가 방문하지 않았고 가까운 정점만 찾기 때문임
        // 좌표계에서 특히 상,하,좌,우 전부 간격이 동일(가중치가 동일)하므로 모든 방향을 우선적으로 찾음

        // ex) 내 캐릭터는 중심, 적은 오른쪽 위에 있는 상황에서
        // 다익스트라는 전부 전방향으로 찾아봄.(캐릭터를 중심으로 원을 그린다고 생각)
        // 내 캐릭터의 목적지는 오른쪽으로 가야 하는데 왼쪽은 굳이 탐색해야 할까??
        // 특히 목적지가 멀면 멀수록 탐색의 범위는 더욱 커져가고, 시간도 오래 걸림


        // => 새로운 알고리즘으로 A*알고리즘 -> 다익스트라의 살짝 변형?
        // 가장 가까운 정점이 아닌 유망한 경로를 조금 더 찾아볼까?
        // 다익스트라의 경우에서 어떤 정점을 먼저 찾을지 조금 더 설계하는 기법

        // ex) 조금 더 오른쪽으로 탐색할까? 아래쪽을 위주로 탐색할까?
        // => 유망한 곳. 내 목적지가 있을만한 곳을 우선적으로 탐색하는 기법


        // 다익스트라 vs A* 

        // 다익스트라
        // 1. 방문하지 않은 정점 중 가장 가까운 정점 선택
        // 2. 목적지까지 가기 위하여 거쳐서 더 짧은 거리가 되는 경우, 기존의 거리 갱신

        // A*
        // 1. 방문하지 않은 정점 중 예상 가중치가 가장 가까운 정점을 선택
        // 2. 다익스트라와 동일(더 짧은거리 찾기)

        // 그렇다면 문제는 어떻게 더 유망한 지점(예상 가중치)을 선택하느냐가 중점이 됨
        // 게임? 좌표가 존재함 -> (2, 3)에서 (10, 10)으로 가게하려면?
        // 아마 오른쪽 위로 가야 할 것이다(좌표로 위치의 추측이 가능함)


        // 선정하려면 좌표가 필요하니 그래프로 표현하자 -> 어떻게?? 인접 행렬과 리스트??
        // 좌표는 각 칸을 모두 표현해야 함 -> 행렬이나 리스트로 구현하면? 최소 정점은 몇 백개 ~ 몇 천개..
        // => 타일맵 그래프!!


        // 어떻게 예상 가중치를 선정하느냐?
        // 목적지와 출발지의 위치만 알고 있다면 간단함
        // 항상 최소 요구 시간 확인하기!!!

        // 1. 단순한 칸 수를 측정해보기 -> 예상되는 소요 거리
        // 10칸, 8칸이 있다면 최단 거리는 8칸 굳이 10칸을 찾아볼 필요는 없음
        // 예상되는 거리가 짧은 것 부터 탐색하면 최단 거리가 될 것 같다

        // 중간에 장애물이 있으면?? 그래도 최단 거리는 변하지 않음
        // 그래도 최소칸만 따라가다보면 최단 거리가 나옴

        // 극단적으로 장애물이 엄청크다면? -> 어차피 가중치가 늘어나며 더 짧은 녀석을 우선적으로 탐색함
        // 다른 경로를 포함할 예정


        // 칸수의 판단 기준
        // f(총점 => g + h), g(실제 이동 거리), h(예상 남은 거리) 각각의 점수를 판정할 예정
        // f가 가장 작은 것이 다음에 갈 위치라고 생각
        // g는 실제 이동거리니 한 칸당 +10(직선) +14(대각선)
        // ex) 현재 위치까지 대각선 1칸, 직선 1칸왔다? => g : 14 * 1 + 10 * 1 => 24

        // h(휴리스틱) -> h를 어떻게 예상하느냐에 따라 성능 차이가 난다(다익스트라는 1)

        // 휴리스틱?
        // 문제를 해결하거나 불확실한 사항에 대해 판단을 내릴 필요가 있지만, 명확한 실마리가 없을 경우에 사용하는 편의적 발견적인 방법

        // 맨허튼
        // -> 도착지까지 직각 사각형이 배치되어 있는 경우
        // 사각형을 따라 직선을 통해서만 가는 방법(가로 떨어진 갯수 + 세로 떨어진 갯수)
        // ex) 목적지까지 가로로 2칸, 세로로 3칸? => h : 10 * 2 + 10 * 3 => 50

        // 유클리드
        // -> 단순 일직선 거리(피타고라스)
        // 실제 예상 거리와 가장 유사하지만 계산에서 시간이 걸림
        // 루트 연산은 연산에서 선호되지 않으므로 대각선 몇 칸, 직선 몇 칸으로 계산함
        // ex) 목적지까지 대각선으로 2칸, 직선으로 1칸? => h : 14 * 2 + 10 => 38

        // f는 예상 경로로 가는 경우 계속해서 값이 유지됨
        // 만약 장애물이 있는 경우 예상 시간이 늘어남


        const int CostStraight = 10; // 직선 코스트
        const int CostDiagonal = 14;  // 대각선 코스트

        // 한 지점의 방향을 관리하기 위한 배열
        static Point[] Direciton =
        {
            new Point(0, +1),   // 상
            new Point(0, -1),   // 하
            new Point(-1, 0),   // 좌
            new Point(+1, 0),   // 우
            new Point(-1, +1),  // 좌상
            new Point(-1, -1),  // 좌하
            new Point(+1, +1),  // 우상
            new Point(+1, -1),  // 우하
        };

        // 경로가 있으면 true, 없다면 false
        // 타일맵, 시작 위치에서 도착 위치까지 경로탐색
        // path에 경로를 넣을 예정
        public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path)
        {
            // 맵 사이즈 활용
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            // 타일맵의 크기만큼 저장할 수 있는 노드들
            ASNode[,] nodes = new ASNode[ySize, xSize];
            // 탐색 여부를 위함. 방문한 곳은 더 이상 방문하지 않음
            bool[,] visited = new bool[ySize, xSize];
            // f가 가장 작은 정점을 탐색해야 함
            // => 우선순위큐(ASNode, f) -> f가 작은 순서대로 꺼내줌
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            // 0. 시작 정점을 생성하여 추가
            // 시작 지점. 부모는 없음. g는 0. h는? -> 휴리스틱을 통해 구함
            ASNode startNode = new ASNode(start, new Point(), 0, Heruistic(start, end));

            // 노드에 해당 위치를 넣는 것도 필요함 ->
            // 우선순위큐에서 빠져버리면 해당 정보가 다 사라지니
            // 나중에 path에 표기하기 위해 노드들을 담아둘 예정
            nodes[startNode.pos.y, startNode.pos.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f); // -> 시작 정점과 시작 정점의 f값

            // 탐색 시작 -> 우선순위큐가 빌 때 까지
            while(nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기 : f가 가장 낮은 정점
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 탐색한 정점은 방문표시
                visited[nextNode.pos.y, nextNode.pos.x] = true;

                // 3. 탐색할 정점이 도착지인 경우
                // 종료! -> 더 이상 점수를 계산할 필요가 없음 / 도착했다고 판단해서 경로를 반환함 
                // 경로를 찾기 위해서 도착 지점부터 역순으로 전부 넣어줄 예정(nodes 리스트와 parent가 있으므로)
                if(nextNode.pos.x == end.x && nextNode.pos.y == end.y) // 도착했다? 좌표가 동일하다
                {
                    // 경로
                    path = new List<Point>();
                    // 도착 지점부터 시작하여
                    Point point = end;

                    // 시작 지점이 될 때 까지 반복(역순으로 넣을 예정)
                    while((point.x == start.x && point.y == start.y) == false)
                    {
                        // 노드들에 담겨있던 애들을 계속해서 반복
                        path.Add(point);
                        // 부모 위치로 가서 계속해서 집어넣기 -> 역순으로 경로를 집어넣음 
                        point = nodes[point.y, point.x].parent;
                    }
                    // 시작 지점일 때 끝나니 시작 지점만 추가
                    path.Add(start);
                    // 역순이면 시작부터 끝까지 다시 정리됨
                    path.Reverse();
                    return true;
                }

                // 4. 탐색한 정점 주변의 정점의 점수 계산(대각선여부에 따라서 4, 8)

                // 위, 아래, ..., 대각선 -> 너무 많으니 배열로 관리

                for(int i = 0; i < Direciton.Length; i++)
                {
                    int x = nextNode.pos.x + Direciton[i].x;
                    int y = nextNode.pos.y + Direciton[i].y;

                    // 4-1. 점수계산을 하면 안되는 경우 제외
                    // 맵을 벗어나는 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점인 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    // 이미 탐색한 정점인 경우
                    else if (visited[y, x])
                        continue;
                    // 대각선으로 이동이 불가능 지역인 경우
                    // 양방향이 막혀 있는 경우
                    // ■□ => 대각선 이동 불가능
                    // □■ => 하나라도 막혀 있으면 안하게 하면? && => ||로 수정
                    else if (i >= 4 && (tileMap[y, nextNode.pos.x] == false && tileMap[nextNode.pos.y, x] == false))
                        continue;


                    // 4-2. 점수를 계산한 정점 만들기
                    // 이전 탐색한 g(지금까지 이동한 거리)값에 이동하나 더하기
                    // 0 ~ 3 : 직선 4 ~ 7 : 대각선이니 4보다 작으면 직선값, 아니면 곡선값
                    int g = nextNode.g + i < 4 ? CostStraight : CostDiagonal;
                    // 지금 있는 위치에서 도착 지점까지 휴리스틱 계산
                    int h = Heruistic(new Point(x, y), end);
                    // 새로운 노드 만들기 -> 지금 있는 위치 + 부모는 탐색한 노드 + 계산한 g, h 값
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.pos, g, h);


                    // 4-3. 정점이 갱신이 필요한 경우 새로운 정점으로 할당
                    // 정점이 없었거나 기존 f값보다 작을 때 갱신
                    if (nodes[y, x] == null ||      // 점수계산을 하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 새로운 정점의 f 가중치가 더 낮은 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            // 우선순위 큐를 전부 확인하였는데(모든 정점을 보았는데) 없다?
            // -> 목적지에 갈 수 없다 
            return false;
        }

        // 휴리스틱 함수(start부터 end까지의 거리를 계산해주는 함수)
        public static int Heruistic(Point start, Point end)
        {
            // 얼마나 떨어져 있는지 계산하여야 함
            // xSize : 가로로 가야하는 횟수, ySize : 세로로 가야하는 횟수
            int xSize = start.x > end.x? start.x - end.x : end.x - start.x; // 음수는 없도록
            int ySize = Math.Abs(start.y - end.y);                          // 절댓값 함수도 가능함(위의 방법이 더 빠름)

            // 맨허튼 거리 : 직선을 통해 이동하는 거리
            // 정확하지는 않지만 빠름
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            // 피타고라스 길이? -> 정확하지만 느림
            // return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);

            // 타일맵 유클리드 거리 : 직선과 대각선을 통해 이동하는 거리
            // 대각선으로 가기 위한 횟수? : x이동, y이동을 통해서 구할 때
            // 작은 축의 갯수만큼 갈 수 있다 -> 가로, 세로를 하나씩 사용해서 대각선을 만든다고 생각
            // 직선은 대각선으로 소모한 가로, 세로를 제외하고 나머지
            int straightCount = Math.Abs(xSize - ySize);
            int diagonalCount = Math.Max(xSize, ySize) - straightCount;
            return CostStraight * straightCount + CostDiagonal * diagonalCount;

            // return 0 -> 다익스트라(예상치 없음)
        }

        // f, g, h값을 계산하고 저장할 노드
        public class ASNode
        {
            public Point pos;       // 정점의 위치
            public Point parent;    // 이 정점을 탐색한 정점의 위치

            public int f;   // 총예상거리 : f = g + h
            public int g;   // 지금까지 이동한 거리, 즉 지금까지 경로상의 누적가중치
            public int h;   // 휴리스틱, 앞으로 예상되는 가중치, 목표까지 추정 경로 가중치(장애물 고려X)
            
            // 생성자
            public ASNode(Point pos, Point parent, int g, int h)
            {
                this.pos = pos;
                this.parent = parent;
                this.f = g + h;
                this.g = g;
                this.h = h;
            }
        }

    }

    // 위치
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // 연산자 재졍의 ==, !=을 구조체에 맞게끔
        public static bool operator == (Point left, Point right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Point left, Point right)
        {
            return left.x != right.x || left.y != right.y;
        }
    }
}
