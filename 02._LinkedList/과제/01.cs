using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList.과제
{
    class _01
    {
        static void Main2(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            int number = -1;

            while (number != 0)
            {
                Console.Write("\n숫자를 입력하세요(0이면 종료) : ");
                int.TryParse(Console.ReadLine(), out number);

                if(number > 0)
                {
                    list.AddFirst(number);
                }
                else if(number < 0)
                {
                    list.AddLast(number);
                }
                else
                {
                    break;
                }

                Console.WriteLine("현재 리스트의 상황");
                foreach(int i in list)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
