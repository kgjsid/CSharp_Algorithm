using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList
{
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
        }
    }
}
