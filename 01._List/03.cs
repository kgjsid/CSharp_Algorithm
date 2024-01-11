using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._List
{
    class _03
    {
        public class Item
        {
            // 아이템 이름과 개수
            string name;
            int count;

            public Item(string name, int count)
            {
                this.name = name;
                this.count = count;
            }

            public string Name
            {
                get { return name; }
            }

            public int Count
            {
                get { return count; }
                set { count = value; }
            }
            
        }

        static void Main(string[] args)
        {
            List<Item> inventory = new List<Item>();

            while (true)
            {
                int number;

                ShowInventory(inventory);

                Console.Write("1(아이템을 획득), 2(아이템 버리기), 0(종료) : ");
                int.TryParse(Console.ReadLine(), out number);

                if (number == 1)
                {
                    InputItem(inventory);
                }
                else if(number == 2)
                {

                }
                else
                {
                    break;
                }
            }
        }

        static public void InputItem(List<Item> inventory)
        {
            // 아이템 입력 받아(포션, 3) ,를 기준으로 분리
            // Item 클래스 name, count에 각각 객체 생성하여 저장
            string[] answer;
            bool isInInventory = false;

            Console.WriteLine("획득할 아이템과 개수를 ,를 기준으로 작성해 주세요");
            Console.Write("(포션, 3 / 허브, 2) : ");
            answer = Console.ReadLine().Split(',');
            int count = 0;
            count = int.Parse(answer[1]);

            // 만약 아이템 이름이 중복되면 개수 증가
            
            for(int i = 0; i < inventory.Count; i++)
            {
                // 조건에 맞는 요소
                // inventory.FindIndex()
    
                if (answer[0] == inventory[i].Name)
                {
                    isInInventory = true;
                    inventory[i].Count += count;
                }
            }

            /*
            int index = inventory.FindIndex(x => x.Name.Equals(answer[1]));

            if (index == -1)
                inventory.Add(new Item(answer[0], count));
            else
                inventory[index].Count += count;
            */
            // 아니라면 새로운 아이템 목록으로 추가

            if (isInInventory == false)
            {
                inventory.Add(new Item(answer[0], count));
            }

        }

        static public void ShowInventory(List<Item> inventory)
        {
            Console.WriteLine($"현재 아이템 목록");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"이름 : {inventory[i].Name}, 개수 : {inventory[i].Count}");
            }
        }
    }
}
