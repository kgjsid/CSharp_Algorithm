using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class _Queue<T>
    {
        // 큐의 기본 크기
        private const int DefaultCapacity = 4;

        // 큐가 될 배열과 head, tail 위치
        private T[] array;
        private int head;
        private int tail;
        private int count;

        public _Queue()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        public void Enqueue(T item)
        {
            // 예외처리2
            // 배열이 꽉 차 있을 땐 크기 늘리기
            if(IsFull())
            {
                Grow();
            }

            // tail 위치에 아이템을 넣고 tail을 한 칸 옮기기
            array[tail] = item;

            // 예외처리1
            // 마지막 위치에 있었다면 순환을 위해 처음 위치로 옮겨야 함
            tail = (tail + 1) % array.Length;
            /* 위의 구문과 동일함
            tail++;
            if (tail == array.Length)
            {
                tail = 0;
            }
            */

            count++;
        }

        public T Dequeue()
        {
            // 맨 처음의 데이터를 꺼내주면 됨
            // 예외처리1
            // 꺼낼 데이터가 없었다면??
            if(count == 0)
            {
                throw new InvalidOperationException();
            }

            // head위치에서 하나 꺼내고 head를 한 칸 옮기기
            T value = array[head];
            head++;
            // 예외처리2
            // head가 배열의 범위를 벗어난 경우 처음 위치로 옮기기
            if(head == array.Length)
            {
                head = 0;
            }

            count--;
            return value;
        }

        // 배열이 꽉 차있을 때
        // 한 칸 전에, head가 0, tail이 맨 마지막에 있을 때
        // h     t |      
        // 0 1 2   | 
        public bool IsFull()
        {
            if (head > tail)
            {
                // 한칸의 손해는 있으나 아무것도 없는 처음 시작 상태와 구분할 수 있으며
                // 코드를 작성하기에 용이하므로 head == tail이 아닌 한칸 뒤에 있는지 확인
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }
        }

        // 배열의 크기 늘리기
        private void Grow()
        {
            // 기존의 배열보다 크기가 2배 더 큰 배열
            T[] newArray = new T[array.Length * 2];
            
            // 기존의 배열을 head부터 tail까지 복사하여야 함
            if(head < tail)
            {
                // head가 0, tail이 끝이므로 그대로 복사
                Array.Copy(array, 0, newArray, 0, count);
                //Array.Copy(array, head, newArray, 0, tail);
            }
            else
            {
                // head부터 끝까지는 앞에, 맨앞부터 tail까지는 그 뒤로 이어 붙이기
                //     t h 
                //   3 4 1 2
                //   h       t
                //=> 1 2 3 4
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
            }
            // 새로운 큰 배열이 큐가 됨
            array = newArray;
            // head는 처음, tail은 끝
            head = 0;
            tail = count;
        }
    }
}
