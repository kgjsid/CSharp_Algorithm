using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
    class Backtracking
    {
        // 백트래킹 (Backtracking) / 완전탐색

        // 모든 경우의 수를 전부 고려하는 알고리즘
        // 후보해를 검증 도중 해가 아닌경우 되돌아가서 다시 해를 찾아가는 기법

        // 백트래킹은 탐욕과 반대 -> 모두 고려하기(전부 해보기)
        // 하다가 안될꺼 같으면 다시 돌아가는 방식
        // 100% 최적의 해는 찾을 수 있으나 느릴 수 있음

        // ex) 미로찾기?
        // 미로에서 가다가 갈래길을 만나는 경우에 아무 곳이나 일단 가보기
        // 막힌 길이면 다시 돌아와서 다른 갈래길로 가고를 반복
        // -> 먼저 진행하다 막히는 경우 돌아오는 상황

        // ex) 1 2 3 4 5 6 7 8 -> 안 겹치게 3개 뽑아줘
        // 일단 1 먼저 고르고, 두번째 고를 수 있는거 전부 보기
        // 모든 경우의 수를 전부 탐색하는 방식

        // ex) N개의 퀸
        // 체스판 각각의 칸을 전부 검사하며
        // 하나의 수에 대하여 모든 상황이 안된다고 나온다면 다시 돌아가서 문제를 생각해야 함

        // 예시 - 폴더삭제
        void RemoveDir(Directory directory)
        {
            foreach (Directory dir in directory.childDir)
            {
                RemoveDir(dir);
            }

            Console.WriteLine("폴더 내 파일 모두 삭제");
        }

        struct Directory
        {
            public List<Directory> childDir;
        }
    }
}
