using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList.과제
{
    class _02
    {
        static void Main3(string[] args)
        {
            int N = 7;
            int k = 3;
            LinkedList<int> list = new LinkedList<int>();
            int value = 0;
            int count = 0;

            for(int i = 1; i <= N; i++)
            {
                list.AddLast(i);
            }

            foreach(int i in list)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            while(list.Count != 0)
            {
                // 1 2 3 4 5 6 7
                // 2 3 4 5 6 7 1
                // 3 4 5 6 7 1 2 => 3 제거
                
                if(count == (k-1))
                {
                    // k번째면 앞에 꺼내기
                    Console.Write($"{list.First.Value} ");
                    list.RemoveFirst();
                    count = 0;
                }
                else
                {
                    // 찾는 위치가 아니라면
                    // 해당 노드 맨 뒤로 옮기기
                    LinkedListNode<int> headNode = list.First;

                    value = headNode.Value;
                    list.Remove(headNode);
                    list.AddLast(value);
                    count++;
                }
            }

        }
    }
}
