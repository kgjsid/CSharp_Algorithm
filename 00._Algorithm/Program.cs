﻿namespace _00._Algorithm
{

    // 프로그래밍
    // 문법 -> 인간 언어를 컴퓨터가 알아들을 수 있는 언어로 해석
    // 알고리즘과 자료구조 -> 조금 더 좋은 대화를 위하여? 잘 통할 수 있도록(빠른 절차, 효율적인 관리, 원하는 문제를 해결)


    // 알고리즘 (Algorithm)

    // 문제를 해결하기 위해 정해진 진행절차나 방법
    // 컴퓨터에서 알고리즘은 어떠한 행동(결과)을 하기 위해서 만들어진 프로그램 명령어의 집합
    // 문제 풀기 위한 보편적인 순서, 해결방법

    // 컴퓨터는 기본적으로 순차적으로 작업할 수 밖에 없음 -> 어떠한 명령을 순서대로 차곡차곡 하느냐 -> 좀 더 효율적일 순 없는가
    // 최단거리 찾기...

    // 알고리즘 조건이 있음(찾아보면 나옴)


    // 알고리즘의 한 분야 -> 자료구조

    // 자료구조(DataStructure)
    // 프로그래밍에서 데이터를 효율적인 접근 및 수정을 가능케 하는 자료의 조작, 관리, 저장을 의미
    // 데이터 값의 모임, 또 데이터 간의 관계, 그리고 데이터에 적용할 수 있는 함수나 명령을 의미

    // 자료를 어떻게 효율적으로 관리하고 조직하느냐(메모장과 엑셀 비교)
    // 저장을 할 때 어떤 방식으로?(선입선출, 선입후출..) => 효율성 높아짐


    // <자료구조 형태>
    // 선형 구조 : 자료 간 관계가 1 대 1인 구조
    // 배열, 연결리스트, 스택, 큐, 덱

    // 비선형 구조 : 자료 간 관계가 1 대 다 혹은 다 대 다인 구조
    // 트리, 그래프


    // 왜 필요하느냐? -> 프로그램을 빠르고 효율적으로 적은 용량으로 돌리고 싶어서
    // 원하는 상황에서 속도 가장 빠른 확보가 기준(특정 알고리즘은 1초, 어떤 건 0.5초..) -> 성능 평가가 필요

    // 알고리즘 성능

    // 효율적인 문제해결을 위해선 알고리즘의 성능을 판단할 수 있는 기준이 필요
    // 상황에 따라 적합한 알고리즘을 선택할 수 있도록 하는 기준

    // 기준을 시간으로 하면?? 
    // A 알고리즘은 100초     (고철 컴퓨터로)
    // B 알고리즘은 1초 걸림  (슈퍼 컴퓨터로) -> 시간만으로 기준 잡기에는 모호함

    // <알고리즘 평가 기준>
    // 컴퓨터에서 알고리즘과 자료구조의 평가는 시간과 공간(메모리) 두 자원을 얼마나 소모하는지가 효율성의 중점
    // 일반적으로 시간을 위해 공간이 희생되는 경우가 많음 (대부분은 보통 반비례)
    // 시간 복잡도 : 알고리즘의 시간적 자원 소모량
    // 공간 복잡도 : 알고리즘의 공간적 자원 소모량
    // => 빨리 해결하며, 메모리를 얼마나 적게 쓰는지 이 부분이 가장 중요함 

    // <Big-O 표기법>

    // 알고리즘의 복잡도를 나타내는 점근표기법( 점근표기법? -> 대략적인 판단 기준 / 연산 회수로 체크하여도 됨 )
    // 데이터 증가량에 따른 시간 증가량을 계산
    // 가장 높은 차수의 계수와 나머지 모든 항을 제거하고 표기
    // 알고리즘의 대략적인 효율을 파악할 수 있는 수단

    class Program
    {
        // n을 n번 더한 결과를 리턴하는 3개의 함수(Case1, Case2, Case3)
        int Case1(int n)
        {
            int sum = 0;
            sum = n * n;
            return sum;
        }
        int Case2(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += n;
            }
            return sum;
        }
        int Case3(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum++;
                }
            }
            return sum;
        }

        // 각 케이스의 연산 횟수를 비교해보면?

        // 입력값       Case1	    Case2   	   Case3
        // n = 1            1           1              1
        // n = 10           1          10            100
        // n = 100          1         100         10,000
        // n = 1000         1        1000      1,000,000
        // Big-O		 O(1)	     O(n)   	   O(n²)
        
        // 동일한 결과이나 자료양에 따라 횟수가 달라지는 것을 확인할 수 있음
        // Case1 이 가장 빠르고 Case3 이 가장 느린 케이스
        // Big-O의 표기법? O(자료에 따른 연산 횟수)
        // O(1) 자료량에 상관없이 연산 1번
        // O(n) n개의 자료량을 넣으면 n번 연산 실행

        // O(2n + 3)?? => O(n)으로 표기 (100만개 넣었을 때 100만 + 3이나 100만이나 동일하며 증가 비율이 필요하므로)
        // O(n² + 2n + 1)?? => O(n²)으로 표기 -> 가장 높은 녀석이 시간 복잡도에 큰 영향을 미치니 가장 큰 차수만 신경

        // O(1), O(log n), O(n), O(n * log n),   O(n²),    O(2^n), O(n!)
        //  효율 매우 높음      좋은 효율        어쩔수없이     절대안됨

        // <수행 시간 분석>
        // 알고리즘의 성능은 상황에 따라 수행 시간이 달라짐
        // 수행 시간을 분석하는 경우 평균의 상황과 최악의 상황을 기준으로 평가함
        // 최선의 상황의 경우 알고리즘의 성능을 분석하는 수단으로 적합하지 않음

        // 수행 시간 : 평균, 최악 두개의 기준으로 판단함
        // ex) 이진트리 : 평균에서는 O(nlogn), 최악에서는 O(n)
        // 최선은? -> 운좋으면 원큐(O(1)) -> 별로 좋지 않은 기준

        // 밑의 코드가 예제
        // 최선은 바로 0번 인덱스에 값이 있는 경우(O(1))
        // 평균은 중간위치. 최악은 가장 끝.(O(n))
        int FindIndex(int[] array, int value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    return i;
            }

            return -1;
        }

        // 항상 어떠한 자료구조나 알고리즘을 선택하였을 때 기준이 있어야 함
        //ex) 만든 코드에서 접근이 중요하고, 리스트가 시간이 평균, 최악에서 빅오 표기법으로 O(1)이니 가장 좋아 선택하였다

        static void Main(string[] args)
        {
            
        }
    }
}
