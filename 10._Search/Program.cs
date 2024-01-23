namespace _10._Search
{
    class Program
    {
        static void Main(string[] args)
        {
            // 순차 탐색
            int[] array = new int[] { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };

            // IndexOf(array, value)
            // array에서 value 찾기
            int indexOf = Array.IndexOf(array, 5);
            int result = Searching.SequentialSearch(array, 5);
            Console.WriteLine($"순차탐색 결과 위치 : {indexOf}");
            Console.WriteLine($"구현한 결과 위치 : {result}");

            // 이진 탐색
            // 정렬된 데이터에서 사용 가능 -> 중간을 기준 왼쪽, 오른쪽으로 데이터를 절반으로 나눔
            // 실제 배열의 이진탐색은 조금 더 효율적으로 구현되어 있음
            // 원하는 값의 근처에 배치되도록 가중치를 넣은 mid를 설정 -> 보간탐색

            Console.WriteLine("정렬 전");
            int binarySearch;
            int result2;
            binarySearch = Array.BinarySearch(array, 2);
            result2 = Searching.BinarySearch(array, 2);
            // 정렬이 되어있지 않아 결과가 이상하게 나옴  
            Console.WriteLine($"정렬 전 이진탐색 결과 : {binarySearch}");
            Console.WriteLine($"정렬 전 구현한 이진탐색 결과 : {result2}");

            // 배열 정렬
            Array.Sort(array);

            Console.WriteLine("정렬 후");
            binarySearch = Array.BinarySearch(array, 2);
            result2 = Searching.BinarySearch(array, 2);
            // 정상적인 결과
            Console.WriteLine($"정렬 후 이진탐색 결과 : {binarySearch}");
            Console.WriteLine($"정렬 후 구현한 이진탐색 결과 : {result2}");

            // 순차나 이진 탐색은 선형 자료구조(리스트, 배열..)에서만 사용 가능
            // 트리에서의 탐색은? -> 순회(전위, 중위, 후위) 순서의 탐색? -> 어떤 순서로 탐색할지
            // 그래프는?

            bool[,] graph = new bool[8, 8]
            {
                { false,  true, false, false, false, false, false, false },
                {  true, false,  true, false, false,  true, false, false },
                { false,  true, false, false,  true,  true, false, false },
                { false, false, false, false, false,  true, false, false },
                { false, false,  true, false, false, false,  true,  true },
                { false,  true,  true,  true, false, false, false, false },
                { false, false, false, false,  true, false, false, false },
                { false, false, false, false,  true, false, false, false },
            };



        }
    }
}
