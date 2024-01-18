using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._Hashtable.과제
{
    class _02
    {
        static void Main2(string[] args)
        {
            Dictionary<string, string> pw = new Dictionary<string, string>();

            int N, M;
            string temp;

            temp = Console.ReadLine();
            N = int.Parse(temp.Split(' ')[0]);
            M = int.Parse(temp.Split(' ')[1]);
            
            for (int i = 0; i < N; i++)
            {
                temp = Console.ReadLine();
                pw.Add(temp.Split(' ')[0], temp.Split(' ')[1]);
            }

            for(int i = 0; i < M; i++)
            {
                temp = Console.ReadLine();

                pw.TryGetValue(temp, out string value);

                Console.WriteLine(value);
            }
        }
    }
}
