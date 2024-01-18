using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._Hashtable.과제
{
    class _03
    {
        static void perm<T>(List<T> arr, List<string> result, int depth, int n, int k, int count)
        {
            if (depth == k)
            {
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < count; i++)
                {
                    sb.Append(arr[i]);
                }
                result.Add(sb.ToString());
                return;
            }

            for (int i = depth; i < n; i++)
            {
                Swap(arr, i, depth);
                perm(arr, result, depth + 1, n, k, count);
                Swap(arr, i, depth);
            }
        }

        static void Swap<T>(List<T> arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


        static void Main(string[] args)
        {
            int n, k;

            string temp;
            int count = 0;

            temp = Console.ReadLine();
            
            n = int.Parse(temp);

            temp = Console.ReadLine();
            k = int.Parse(temp);
            
            // 카드들
            List<string> card = new List<string>();
            List<string> result = new List<string>();
            // 만들 수 있는 페어들
            Dictionary<string, int> pair = new Dictionary<string, int>();
            // 페어를 전부 만들고 딕셔너리에 넣으면 중복 무시되니 해결되는데

            for (int i = 0; i < n; i++)
            {
                temp = Console.ReadLine();
                card.Add(temp);
            }
            
            perm(card, result, 0, card.Count, card.Count, k);


            foreach(string s in result)
            {
                Console.WriteLine(s);
                pair.TryAdd(s, int.Parse(s));
            }
            Console.WriteLine($"{pair.Count}");
        }
    }
}
