using System.Reflection.Metadata.Ecma335;

namespace _08._DesignTechnique
{
    // 문제를 푼다? -> 어떻게 접근할까? -> 보통의 경우 비슷한 유추를 이용해서 해결할 수 있음
    // 알고리즘 설계기법? -> 전략이라고 생각

    // 이 문제는 이 전략을, 저 문제는 다른 전략을...
    class Program
    {
        // 알고리즘 설계기법(Algorithm Design Technique)

        // 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
        // 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 효율성이 막대하게 차이
        // 문제의 성질과 조건에 따라 알맞은 알고리즘 설계기법을 선택하여 사용

        // <재귀함수 조건>
        // 1. 함수내용 중 자기자신함수를 다시 호출해야함
        // 2. 종료조건이 있어야 함 -> 반드시 필요

        // 재귀(Recursion)

        // 어떠한 것을 정의할 때 자기 자신을 참조하는 것
        // 함수를 정의할 때 자기자신을 이용하여 표현하는 방법

        // 내가 나를 부른다? -> 함수를 만들 때 자신의 함수를 이용하는 것

        // <재귀함수 사용>
        // Factorial : 정수를 1이 될 때까지 차감하며 곱한 값
        // x! = x * (x-1)!;
        // 1! = 1;
        // ex) 5! = 5 * 4!
        //        = 5 * 4 * 3!
        //        = 5 * 4 * 3 * 2!
        //        = 5 * 4 * 3 * 2 * 1!
        //        = 5 * 4 * 3 * 2 * 1

        // 팩토리얼의 재귀 함수 
        static int Factorial(int x)
        {
            if (x == 1) // 종료 조건.
                return 1; // 종료 되면 역순으로 쭉 함수 호출이 풀림
            else  
                return x * Factorial(x - 1); // 자기 자신을 호출
        }

        // 종료 조건이 없는 재귀함수 
        static int Factorial2(int x)
        {
            // 끝나지 않음 (F(3) -> F(2) -> F(1) -> F(0) -> F(-1)....)
            // 더 이상 함수를 호출할 수 없는 스택 오버플로우 발생
            return x * Factorial2(x - 1); // 자기 자신을 호출
        }


        // 예시 - 폴더 삭제
        // 폴더를 지우려면? -> 폴더 안의 모든 폴더를 지워야 하고
        // 또 지울 폴더 안에 모든 폴더를 지워야 함
        // 반복이 너무 복잡하고 어려움

        void RemoveDir(Directory dircetory)
        {
            // 반복만으로 정의하기 어려움

            // 재귀를 쓴다면??
            foreach(Directory dir in dircetory.childDir)
            {
                RemoveDir(dir);
            }

            Console.WriteLine("폴더 내 파일 모두 삭제");
        }

        struct Directory
        {
            public List<Directory> childDir;
        }

        static void Main1(string[] args)
        {
            Factorial(5);
        }

        // F(5) -> 5 * F(4) => 5 * 4 * 3 * 2 * 1
        // F(4) -> 4 * F(3) => 4 * 3 * 2 * 1
        // F(3) -> 3 * F(2) => 3 * 2 * 1
        // F(2) -> 2 * F(1) => 2 * 1
        // F(1) => 1
    }
}
