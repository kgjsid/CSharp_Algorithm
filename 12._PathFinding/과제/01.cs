using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._PathFinding.과제
{
    public class _01
    {
        static int Straight = 10;
        static int Diagonal = 14;

        static Point[] Dictionary =
        {
            new Point(0, +1),
            new Point(0, -1),
            new Point(+1, 0),
            new Point(-1, 0),
            new Point(+1,+1),
            new Point(+1,-1),
            new Point(-1,+1),
            new Point(-1,-1),
        };

        public struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class Node
        {
            public Point pos;
            public Point parent;

            public int g;
            public int h;
            public int f;

            public Node(Point pos, Point parent, int g, int h)
            {
                this.pos = pos;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }

        
        static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path)
        {
            // 사이즈는 자주 이용되니 먼저 만들어두자
            int xSize = tileMap.GetLength(1);
            int ySize = tileMap.GetLength(0);

            // 방문한 지역인지 확인하기
            bool[,] visited = new bool[ySize, xSize];
            // 노드 저장해두기
            Node[,] nodes = new Node[ySize, xSize];

            Node startNode = new Node(new Point(start.y, start.x), new Point(), 0, Heuristics(start, end));
            PriorityQueue<Node, int> pq = new PriorityQueue<Node, int>();

            pq.Enqueue(startNode, startNode.f);
            nodes[startNode.pos.y, startNode.pos.x] = startNode;

            while(pq.Count > 0)
            {
                // 계산할 정점 꺼내기
                Node nextNode = pq.Dequeue();

                visited[nextNode.pos.y, nextNode.pos.x] = true;

                if(nextNode.pos.x == end.x && nextNode.pos.y == end.y)
                {
                    path = new List<Point>();

                    path.Add(end);

                    while (!(nextNode.pos.x == start.x && nextNode.pos.y == start.y))
                    {
                        Point before = nextNode.parent;

                        path.Add(before);
                    }

                    path.Add(start);
                    path.Reverse();
                    return true;
                }

                for(int i = 0; i < Dictionary.Length; i++)
                {
                    int x = nextNode.pos.x + Dictionary[i].x;
                    int y = nextNode.pos.y + Dictionary[i].y;

                    if (x < 0 || y < 0 || x >= xSize || y >= ySize)
                    {
                        continue;
                    }
                    else if (visited[y, x])
                    {
                        continue;
                    }
                    else if (tileMap[y, x])
                    {
                        continue;
                    }
                    else if(i >= 4 && (tileMap[y, nextNode.pos.x] == false && tileMap[nextNode.pos.y, x] == false))
                    {
                        continue;
                    }

                    int g = nextNode.g + i < 4? Straight : Diagonal;
                    Node newNode = new Node(new Point(x, y), nextNode.pos, g, Heuristics(new Point(x, y), end));

                    if (nodes[y, x] == null &&
                        nodes[y, x].f > newNode.f)
                    {
                        nodes[y, x] = newNode;
                        pq.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            return false;
        }

        public static int Heuristics(Point start, Point end)
        {
            int xMove = Math.Abs(start.x - end.x);
            int yMove = Math.Abs(start.y - end.y);

            int diagonalCount = Math.Min(xMove, yMove);
            int straightCount = Math.Max(xMove, yMove) - diagonalCount;

            return straightCount * Straight + diagonalCount * Diagonal;
        }
    }
}
