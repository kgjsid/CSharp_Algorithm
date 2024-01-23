using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Search.실습
{
    class _01
    {
        // 1. 양방향 연결그래프
        bool[,] matrixGraph1 = new bool[8, 8]
        {
           // [y,0]  [y,1]  [y,2]  [y,3]  [y,4]  [y,5]  [y,6]  [y,7]
 /*[0,x]*/  { false, false,  true, false,  true, false, false, false},
 /*[1,x]*/  { false, false,  true, false, false,  true, false, false},
 /*[2,x]*/  {  true,  true, false, false, false,  true,  true, false},
 /*[3,x]*/  { false, false, false, false, false, false, false,  true},
 /*[4,x]*/  {  true, false, false, false, false, false, false,  true},
 /*[5,x]*/  { false,  true,  true, false, false, false, false, false},
 /*[6,x]*/  { false, false,  true, false, false, false, false, false},
 /*[7,x]*/  { false, false, false,  true,  true, false, false, false}
        };

        // 2. 단방향 연결그래프
        bool[,] matrixGraph2 = new bool[8, 8]
        {
            { false, false, false, false, false, false, false, false},
            { false, false, false, false, false, false, false, false},
            { false, false, false, false,  true,  true, false, false},
            { false,  true, false, false, false,  true, false,  true},
            { false, false, false, false, false, false, false, false},
            { false,  true, false, false, false, false, false, false},
            { false, false,  true, false, false,  true, false, false},
            { false, false, false, false, false, false,  true, false}
        };

        // 3. 양방향 가중치 그래프
        const int INF = int.MaxValue;
        int[,] matrixGraph3 = new int[8, 8]
        {
            {   0,   4, INF, INF,   6, INF, INF, INF },
            {   4,   0,   5,   4, INF,   8,   2, INF },
            { INF,   5,   0, INF,   9, INF, INF, INF },
            { INF,   4, INF,   0, INF, INF, INF, INF },
            {   6, INF,   9, INF,   0, INF,   5, INF },
            { INF,   8, INF, INF, INF,   0, INF,   1 },
            { INF,   2, INF, INF,   5, INF,   0, INF },
            { INF, INF, INF, INF, INF,   1, INF,   0 }
        };
    }
}
