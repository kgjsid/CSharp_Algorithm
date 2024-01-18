using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // Tkey, Tvalue : 키, 값
    // 특히 키는 중복되면 안됨 -> IEquatable : 똑같은지 비교해주는 인터페이스
    public class Dictionary<Tkey, TValue> where Tkey : IEquatable<Tkey>
    {
        // 기본 테이블의 크기 -> 소수가 조금 더 좋음(분산이 잘됨)
        private const int DefaultCapacity = 1000;

        // key와 value 두개 다 담아둬야 함
        private struct Entry
        {
            // 상황? -> 충돌 대비
            // 1. 한번도 쓴 적이 없는 곳인지
            // 2. 사용 중인지
            // 3. 지워진 곳인지
            public enum State { None, Using, Deleted }

            public State state;
            public Tkey key;
            public TValue value;
        }
        // key와 value를 보관할 테이블
        private Entry[] table;
        // 테이블에 있는 데이터의 수
        private int usedCount;
        
        // 기본적인 table의 크기 지정
        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
            usedCount = 0;
        }

        // 인덱서 구현 -> 키 값을 인덱스처럼 사용
        public TValue this[Tkey key]
        {
            get
            {
                if(Find(key, out int index))
                {
                    // 해당 키로 해싱한 인덱스 찾고 값 넘겨주기
                    return table[index].value;
                }
                else
                {
                    // 키 없음 -> 오류
                    throw new KeyNotFoundException();
                }
            }
            set
            {
                if(Find(key, out int index))
                {
                    // 해당 키로 해싱한 인덱스 찾고 값 변경하기
                    table[index].value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public void Add(Tkey key, TValue value)
        {
            // key값 해싱하기 -> 테이블 내 인덱스로 변환

            // 있는지 확인
            if(Find(key, out int index))
            {
                // 있다면 중복을 허용하지 않으니 오류처리
                throw new InvalidOperationException("Already exist key");
            }
            else
            {
                // 만약 테이블 사용량이 70%를 넘어갔다면
                if(usedCount > table.Length * 0.7f)
                {
                    // 리해싱
                    ReHasing();
                }

                // 해당 인덱스에 키, 값, 상태 저장
                table[index].key = key;
                table[index].value = value;
                table[index].state = Entry.State.Using;
                usedCount++;
            }
        }

        // 키를 통해 데이터 삭제
        public bool Remove(Tkey key)
        {
            // 만약 키를 찾았다면
            if(Find(key, out int index))
            {
                // 삭제된 상태로 변환
                table[index].state = Entry.State.Deleted;
                return true;
            }
            else // 없었다면
            {
                return false;
            }
        }

        public bool ContainsKey(Tkey key)
        {
            // 해당 키로 찾아보기
            if(Find(key, out int index))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 키를 통해서 인덱스 찾기
        private bool Find(Tkey key, out int index)
        {
            // Hash 함수를 통해 변환한 값이 해싱된 값
            index = Hash(key); // 해싱

            // 테이블 크기만큼 다 돌아가며 확인
            for (int i = 0; i < table.Length; i++)
            {
                if (table[index].state == Entry.State.None)
                {   // 찾아봤는데 아무 데이터가 없는 경우
                    // 데이터 없음
                    return false;
                }
                else if (table[index].state == Entry.State.Using)
                {   // 무언가 데이터가 있어 사용 중이면

                    if (key.Equals(table[index].key))
                    {   // 해당 데이터가 자기자신 인 경우
                        return true;
                    }
                    else
                    {   // 다음칸으로 이동
                        // -> 충돌이 있었어서 다른 공간으로 간 데이터를 찾아야 함
                        index = Hash2(index);
                    }
                }
                else // table[index].state == Entry.State.Deleted 
                {    // 지워진 상황 -> 다음칸으로 이동
                    index = Hash2(index);
                }
            }
            index = -1;
            throw new InvalidOperationException();
        }
        
        // 해시 함수
        private int Hash(Tkey key) // 해시함수
        {
            // GetHashCode? -> 해시 코드 가져오는 C#의 함수(음수도 존재)
            // Math.Abs? -> 절댓값, 해시 코드가 음수인 경우가 있음
            // 나눗셈법 1881 % 1000 => 881
            return Math.Abs(key.GetHashCode() % table.Length);
        }

        // 다음 칸 이동을 위한 함수
        private int Hash2(int index)
        {
            // 선형탐사(다음칸 이동)
            return (index + 1) % table.Length;

            // 제곱 탐사(인덱스 1인경우 방지)
            // return (index + 1) * (index + 1) % table.Length;

            // 이중 해싱(한번 더 해싱 => C#의 경우)
            // return Math.Abs((index + 1).GetHashCode() % table.Length);
        }

        // 테이블에 데이터가 많다면 성능저하가 일어나니
        // 더 큰 테이블로 이동
        private void ReHasing()
        {
            // 기존의 테이블
            Entry[] oldTable = table;

            // 기존보다 2배가 더 큰 테이블
            table = new Entry[table.Length * 2];
            usedCount = 0;

            // 기존 테이블을 순회하며
            for(int i = 0; i < oldTable.Length; i++)
            {
                // 하나씩 확인하였을 때
                Entry entry = oldTable[i];
                // 사용중인 테이블이었다면
                if(entry.state == Entry.State.Using)
                {
                    // 새로운 테이블에 복사
                    Add(entry.key, entry.value);
                }
            }
        }
    }
}
