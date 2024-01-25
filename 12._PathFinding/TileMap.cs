using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._PathFinding
{
    public class TileMap
    {
        // 그래프? 2차원 배열로 시작과 도착 graph[0, 1]
        // 타일맵? 동일하게 2차원 배열 -> tileMap[1, 1]

        // 타일맵 (TileMap)

        // 2차원 평면의 그래프를 정점이 아닌 위치를 통해 표현하는 그래프
        // 위치의 이동가능 유무만을 표현하는 bool 이차원 타일맵
        // 타일의 종류를 표현한 이차원 타일맵이 있음
        // 인접한 이동가능한 위치간 간선이 있으며 가중치는 동일함

        // O - O - O
        // |   |   |
        // O - O - O  -> 이런 느낌? -> 왼쪽 위를 [0, 0]으로 보고 [0, 1] [0, 2]...등등 각각의 칸을 표현
        // |   |   |  -> 간선은? -> 인접하면 있다? -> 간선이 없어도 인접해있다면 있다로 판단
        // O - O - O   

        // 해당 지역을 bool타입으로 이동할 수 있다면 true(평지...), 아니라면 false(언덕 / 물...)

        // <타일맵 그래프>
        // 예시 - 위치의 이동가능 표현한 이차원 타일맵
        // 갈 수 있는 정점은 true / 없다면 false -> 순간이동 불가능
        bool[,] tileMap1 = new bool[7, 7]
        {
            { false, false, false, false, false, false, false },
            { false,  true, false,  true, false, false, false },
            { false,  true, false,  true, false,  true, false },
            { false,  true, false,  true,  true,  true, false },
            { false,  true, false,  true, false, false, false },
            { false,  true,  true,  true,  true,  true, false },
            { false, false, false, false, false, false, false },
        };

        // ex) x = 1, y = 1에서 아래로만 갈 수 있다
        // ex) x = 1, y = 2에서는 위, 아래로만 갈 수 있다
        // 쉽게 false는 벽이 세워져 있고, true는 땅이라고 생각

        // 예시 - 타일의 종류를 표현한 이차원 타일맵
        // -> 해당 지역의 유형을 설명할 수 있음
        enum TileType
        {
            None = ' ',
            Wall = '#',
            Door = '*',
            Shop = 'S',
            Gate = 'G',
        }

        char[,] tileMap2 = new char[9, 9]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', '#', '#', ' ', ' ', '#', '#', '#' },
            { '#', ' ', '#', '#', ' ', '#', '#', ' ', '#' },
            { '#', ' ', '#', '#', '*', '#', '#', '*', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', 'S', ' ', ' ', ' ', 'G', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#' },
        };
    }
}
