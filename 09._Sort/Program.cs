namespace _09._Sort
{
    class Program
    {
        // 프로그램 작성 시 순서대로 작성하기가 많이 필요함
        // ex) 경매장 시스템

        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 10;

            List<int> selectionList = new List<int>();
            List<int> insertionList = new List<int>();
            List<int> bubbleList = new List<int>();
            List<int> mergeList = new List<int>();
            List<int> quickList = new List<int>();
            List<int> introList = new List<int>();

            Console.WriteLine("랜덤 데이터 : ");
            for(int i = 0; i < count; i++)
            {
                int rand = random.Next(0, 100);

                Console.Write($"{rand,3}");
                selectionList.Add(rand);
                insertionList.Add(rand);
                bubbleList.Add(rand);
                mergeList.Add(rand);
                quickList.Add(rand);
                introList.Add(rand);
            }
            Console.WriteLine();

            Console.WriteLine("선택정렬 결과 : ");
            Sorting.SelectionSort(selectionList, 0, selectionList.Count - 1);

            foreach(int value in selectionList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("삽입정렬 결과 : ");
            Sorting.InsertionSort(insertionList, 0, insertionList.Count - 1);

            foreach (int value in insertionList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("버블정렬 결과 : ");
            Sorting.BubbleSort(bubbleList, 0, bubbleList.Count - 1);

            foreach (int value in bubbleList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("병합정렬 결과 : ");
            Sorting.MergeSort(mergeList, 0, mergeList.Count - 1);

            foreach (int value in mergeList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("퀵정렬 결과 : ");
            Sorting.QuickSort(quickList, 0, quickList.Count - 1);

            foreach (int value in quickList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("인트로정렬 결과 : ");
            introList.Sort();
            foreach(int value in introList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }
    }
}
