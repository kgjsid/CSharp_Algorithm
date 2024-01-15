using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 리스트의 Add, RemoveAt으로 스택의 기능을 구현할 수 있도록만 해둔 것
// ex) 리스트의 Add -> 스택의 push로, 리스트의 RemoveAt -> 스택의 Pop
// 의도대로 사용할 수 있도록 사용 방법만 변환해 주는 것 => 어댑터 패턴

// 어댑터 패턴(Adapter)

// 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
// -> 스택의 구현에는 List의 기능을 제한하여 구현할 수 있음

namespace DataStructure
{
    public class _Stack<T>
    {
        // 스택으로 사용할 리스트
        private List<T> container;

        public _Stack()
        {
            container = new List<T>();
        }

        // 스택에 있는 데이터의 수
        public int Count { get { return container.Count; } }

        // 스택에 데이터 추가하기
        public void Push(T item)
        {
            container.Add(item);
        }

        // 스택에서 데이터 꺼내기
        // 가장 뒤에 있는 데이터를 꺼내면 됨
        public T Pop()
        {
            T item = container[container.Count - 1];
            container.RemoveAt(container.Count - 1);

            return item;
        }
    }
}
