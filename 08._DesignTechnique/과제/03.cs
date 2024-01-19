using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique.과제
{
    class _03
    {
        static void Main3(string[] args)
        {
            int N;

            N = int.Parse(Console.ReadLine());
            
            List<int> P = new List<int>();
            string[] temp = Console.ReadLine().Split(' ');

            for (int i = 0; i < N; i++)
            {
                P.Add(int.Parse(temp[i]));
            }

            int sum = 0;
            int total = 0;
            P.Sort();

            for(int i = 0; i < N; i++)
            {

                for(int j = 0; j <= i; j++)
                {
                    sum += P[j];
                }

                total += sum;
                sum = 0;
            }

            Console.WriteLine(total);
        }
    }
}
