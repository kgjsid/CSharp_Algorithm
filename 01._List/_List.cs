using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// 리스트의 사용법만 알아도 괜찮으나 효율적으로 잘 사용하기 위해선 구조에 대하여 알 필요가 있음
// 직접 구현을 요구하진 않음. 다만 이해를 위해 구현해 보는 것도 좋음
namespace Datastructure
{
    public class _List<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items; // 리스트처럼 이용될 배열 + 용량(items.Length)도 담고 있음
        private int count; // 리스트 요소의 개수

        public _List() // 기본 생성자 -> 배열의 크기는 4, count는 0
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        public _List(int capacity) // 용량을 인자로 받는 생성자 -> 배열의 크기는 capacity만큼
        {
            items = new T[capacity];
            count = 0;
        }

        public int Capacity { get { return items.Length; } } // 용량 접근을 위한 프로퍼티
        public int Count { get { return count; } }           // 리스트 요소 개수를 위한 프로퍼티
        public bool IsFull { get { return count == items.Length; } } // 꽉 차 있는지 확인하는 프로퍼티
        public T this[int index] // 접근을 위한 인덱서 -> 실 사용으로 list[0] -> 0번 인덱스가 set과 get으로 갈 예정
        {   // 접근 할 수 있는 인덱스는 실제 존재하는 값만 가능
            get
            {
                if(index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                items[index] = value;
            }
        }

        public void Add(T item)
        {
            // Add? -> 맨 뒷자리에 하나 넣기
            // 예외처리(배열이 꽉 차 있다면??)
            if (IsFull)
            {
                Grow();
            }

            //5. 빈공간에 데이터 추가
            // 0 1 2 <- A 추가? => 3번 인덱스에 A를 넣어야 하며 count의 개수가 다음 위치가 됨
            items[count] = item;
            count++;    // 하나 추가되었으니 count 1개 늘리기

            //items[count++] = item; 으로 줄여 쓸 수 있음
        }

        
        private void Grow()
        {
            //2. 새로운 더 큰 배열 생성
            T[] newItems = new T[items.Length * 2];

            //3. 새로운 배열에 기존의 데이터 복사
            Array.Copy(items, newItems, items.Length); // items에 있던 요소들을 newItems으로 item.Length만큼 복사하겠다

            //4. 기본 배열 대신 새로운 배열을 사용
            items = newItems; 
            // items 배열이 기존에 가리키던 객체가 아닌
            // newItems으로 새로 만들어진 객체를 가리킬 수 있도록 함(얕은 복사)

            // 기존의 작은 객체는 가비지 컬렉터가 수거해 가며 newItems(지역변수)은 Grow함수 종료 시 자동으로 사라짐
        }

        public void Insert(int index, T item) // index : 어디 위치에, item : 무슨 요소를 넣을지
        {
            // Insert의 실행 과정
            // 1. 넣고 싶은 위치를 비우기 위해 해당 인덱스부터 끝까지의 요소를 오른쪽으로 한칸 이동
            // 2. 해당 위치에 데이터를 집어 넣음
            // 예외처리) 만약 배열의 빈공간에 넣으려면?? (count : 2인데 index를 10에 넣겠다??)

            // 예외처리 : 크기를 벗어나게 중간에 끼워넣는것을 불가능
            // count가 5인데 5번 인덱스에 Insert는 가능
            if(index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException("index"); // argument : 매개변수 오류
            }

            if (IsFull)
            {
                Grow();
            }

            // 1. 넣고 싶은 위치를 비우기 위해 해당 인덱스부터 끝까지의 요소를 오른쪽으로 한칸 이동
            Array.Copy(items, index, items, index + 1, count - index) ; // items 배열의 index부터 복사 시작
                                                                        // 목적지는 items배열의 index + 1 부터 count-index 만큼 -> 한칸 밀어서 복사함
            // 인덱스부터 끝까지??
            // count - index
            // ex) 4개 들어있는데 1번 위치에 넣겠다
            // 0 1 2 3 => count : 4, index : 1 => 이동은 3개(1,2,3)(count - index) 
            // 0 5 1 2 3

            // 2. 해당 위치에 데이터를 집어 넣음
            items[index] = item;
            count++;
        }

        public bool Remove(T item)     // item 찾아서 지우기
        {
            int index = IndexOf(item); // item 인덱스 찾고

            if (index >= 0)            // index가 있었다면(리스트에 해당 요소가 있었다면) 
            {
                RemoveAt(index);       // 해당 인덱스 지우기
                return true;
            }
            else
            {
                return false;          // 없는 요소라면 false
            }
        }

        public void RemoveAt(int index)
        {
            // 예외처리 : 크기를 벗어나게 중간에 빼는 것 불가능
            // + count와 index가 같은 경우도 에러(배열의 인덱스는 크기 - 1)
            // ex) 5개의 요소(0~4 인덱스)인데 5번 인덱스 빼기??
            if(index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            // 특정 위치를 지우겠다 => 뒤에 있는 애들을 앞으로 당겨 복사
            // insert의 반대 과정

            // ex) 1 2 3 4 5 에서 2번 인덱스(3) 지우기
            //     1 2 4 5   => 뒤에 있는 4, 5를 앞으로 당겨서 복사하기
            count--;
            Array.Copy(items, index + 1, items, index, count - index);
        }

        public int IndexOf(T item) // item 위치 찾기
        {
            // 앞에서 모든 요소 탐색하며 찾기

            for(int i = 0; i < count; i++)
            {
                if (item.Equals(items[i]))  // 일반화로 인해 == 연산자 불가능(객체비교??).
                {                           // 동일한 객체인지 확인하는 Equals 사용
                    return i;               // Equals는 주소값이 동일한지 확인
                }
            }

            return -1;
        }
    }

}