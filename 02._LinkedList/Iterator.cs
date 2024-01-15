using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList
{

    /*******************************************************************
        * 반복기 (Iterator)
        * 
        * 자료구조에 저장되어 있는 요소들을 순차적으로 접근하기 위한 객체
        * C# 대부분의 자료구조는 반복기를 포함
        * 이를 통해 자료구조종류와 내부구조에 무관하게 순회가능
        *******************************************************************/

    public class Iterator
    {
        void Main1()
        {
            // 리스트와 연결 리스트
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            SortedSet<int> set = new SortedSet<int>();

            // 두개의 리스트에 10개 추가
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
                set.Add(i);
            }

            // 넣은 요소들 전부 출력
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            // 연결리스트는 어떻게 출력???
            // Console.Write(linkedList[i]); -> 불가능

            // 인덱스가 없으므로 다음과 같이
            // 처음 노드부터 다음 노드로 넘어가면서 노드가 null이 아닐 때 까지 반복한다
            for(LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
            {
                Console.Write($"{node.Value}");
            }

            // 각각의 자료형에 따라 반복법이 다름. 특히 모르는 자료구조이면 반복이 불가능함
            // => foreach를 활용
            // foreach? 처음부터 하나하나 반복하자 -> 즉 무슨 구조이던 처음부터 끝까지 하나하나 반복
            // 배열, 리스트, 그 외의 자료구조에 대하여 각 요소에 접근할 수 있는 반복문
            foreach(int value in list)
            {
                Console.Write($"{value}");
            }
            foreach (int value in linkedList)
            {
                Console.Write($"{value}");
            }
            foreach(int value in set)
            {
                Console.Write($"{value}");
            }

            // foreach는 처음부터 끝까지 일렬로 반복이 가능한 객체만 사용 가능 
            // -> IEnumerable 이라는 인터페이스를 포함하면 사용할 수 있음

            foreach(int value in Func())
            {

            }
            // yield를 이용하는 경우
            // list.Average();
        }
        // IEnumerable 타입의 함수 -> 반복할 수 있는 함수이다
        // yield return 또한 해당 의미
        public static IEnumerable<int> Func()
        {
            yield return 10;

            yield return 20;

            yield return 30;
        }
        // yield가 없는 함수는 보통 시작부터 끝까지 멈추지 않고 진행함
        // yield 키워드는? 중간 중간 멈춘다
        // 함수 시작 중 yield return을 만나면 일시정지, 다음 호출 시 yield return 이후부터 진행

    }
}
