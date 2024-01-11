using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._List
{
    class _01
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int number = 0;

            Console.Write("숫자를 입력하세요 : ");
            int.TryParse(Console.ReadLine(), out number);

            for(int i = 0; i < number + 1; i++)
            {
                list.Add(i);
                Console.Write($"list에 {i} 추가 ");
            }
            list.Remove(0);
            Console.WriteLine("\n리스트에서 0 제거");

            foreach(int i in list)
            {
                Console.WriteLine($"리스트의 요소를 출력합니다. {i}");
            }
        }

    }
}
