using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._List
{
    class _03
    {
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
                else if (number == 2)
                {
                    OutItem(inventory);
                }
                else
                {
                    break;
                }
            }
        }
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

        static public void InputItem(List<Item> inventory)
        {
            // 아이템 입력 받아(포션, 3) ,를 기준으로 분리
            // Item 클래스 name, count에 각각 객체 생성하여 저장
            string[] answer;

            Console.WriteLine("획득할 아이템과 개수를 ,를 기준으로 작성해 주세요");
            Console.Write("(포션, 3 / 허브, 2) : ");
            answer = Console.ReadLine().Split(',');
            int count = 0;
            count = int.Parse(answer[1]);

            // FindIndex 수정
            int index = inventory.FindIndex(x => x.Name.Equals(answer[0]));

            if (index == -1)
                inventory.Add(new Item(answer[0], count));
            else
                inventory[index].Count += count;

        }

        static public void ShowInventory(List<Item> inventory)
        {
            Console.WriteLine($"\n현재 아이템 목록");

            if (inventory.Count == 0)
                Console.WriteLine("인벤토리가 비어 있습니다.\n\n");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"이름 : {inventory[i].Name}, 개수 : {inventory[i].Count}");
            }

            Console.WriteLine("\n");
        }

        static public void OutItem(List<Item> inventory)
        {
            // 아이템 입력 받아(포션, 3) ,를 기준으로 분리
            // Item 클래스 name, count에 각각 객체 생성하여 저장
            string[] answer;

            Console.WriteLine("버릴 아이템과 개수를 ,를 기준으로 작성해 주세요");
            Console.Write("(포션, 3 / 허브, 2) : ");
            answer = Console.ReadLine().Split(',');
            int count = 0;
            count = int.Parse(answer[1]);

            // FindIndex 수정
            int index = inventory.FindIndex(x => x.Name.Equals(answer[0]));

            if (index == -1)
                Console.WriteLine("없는 아이템입니다.");
            else
            {
                // 생각해보니 가진 아이템 수 보다 버리는 아이템 수가 많으면 안되므로 수정
                int dropCount = inventory[index].Count > count ? count : inventory[index].Count;

                Console.WriteLine($"{inventory[index].Name}을 {dropCount}개 버립니다.");

                inventory[index].Count -= dropCount;

                if (inventory[index].Count == 0)
                {
                    inventory.RemoveAt(index);
                }
            }

        }
    }
}
