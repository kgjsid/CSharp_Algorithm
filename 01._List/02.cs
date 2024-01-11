using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._List
{
    class _02
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            int number = 0;
            while(true)
            {
                Console.Write("사용자 입력(0이면 종료) : ");
                int.TryParse(Console.ReadLine(), out number);

                if (number == 0)
                {
                    PrintList(list);
                    break;
                }

                if(list.Contains(number))
                {
                    list.Remove(number);
                }
                else
                {
                    list.Add(number);
                }

                PrintList(list);

            }

        }

        static public void PrintList(List<int> list)
        {
            Console.WriteLine("현재 리스트의 요소를 출력합니다.");
            foreach (int i in list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n");
        }
    }
}
