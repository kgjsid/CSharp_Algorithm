using System.Globalization;

namespace Practice
{
    class Program
    {
        public struct Meeting
        {
            // 시작 시간
            public int start;
            // 끝 시간
            public int end;

            public Meeting(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }

        static void Main(String[] args)
        {
            int N;
            int.TryParse(Console.ReadLine(), out N);
            // 미팅들 담을 리스트
            List<Meeting> meetings = new List<Meeting>();
            // 미팅은 이름, 시작, 끝으로 구성
            string s;

            for (int i = 0; i < N; i++)
            {
                s = Console.ReadLine();
                meetings.Add(new Meeting(int.Parse(s.Split(' ')[0]), int.Parse(s.Split(' ')[1])));
            }

            // 1. 우선순위 큐(회의, 정수형)
            PriorityQueue<Meeting, int> remainMeeting = new PriorityQueue<Meeting, int>();

            // 우선순위는 오픈 시간순
            foreach (Meeting meeting in meetings)
            {
                remainMeeting.Enqueue(meeting, meeting.start);
            }

            // 진행중인 회의의 우선순위 큐
            // => 위의 우선순위큐와 다르게 끝나는 시간이 빠를수록 우선순위가 높아짐
            PriorityQueue<Meeting, int> doMeeting = new PriorityQueue<Meeting, int>();

            // 
            while (remainMeeting.Count > 0)
            {
                // 먼저 남아있는 회의를 꺼내고
                Meeting nextStartMeeting = remainMeeting.Dequeue();

                // 진행중인 회의가 없다? -> 회의실을 빌려야 한다
                if (doMeeting.Count == 0)
                {
                    // 진행중인 회의에 남아있는 회의를 하나 넣고, 이번엔 끝나는 순서대로 우선순위
                    doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
                }
                else // 회의가 있을 때 확인해야 하는 건 2가지
                {
                    // 1. 회의가 끝나는 시간이 이번에 진행될 회의의 시작시간보다 빨리 끝나는가??
                    // ex) 0 - 10 / 10 - 15 -> 회의실을 빌리지 않고 이어서 진행 가능
                    Meeting nextEndMeeting = doMeeting.Peek();
                    if (nextEndMeeting.end <= nextStartMeeting.start)
                    {
                        doMeeting.Dequeue();
                        doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
                    }
                    else // 2. 아니라면. 0 - 10 / 5 - 15 -> 회의실을 빌려야 함
                    {
                        doMeeting.Enqueue(nextStartMeeting, nextStartMeeting.end);
                    }
                }
            }

            Console.WriteLine($"{doMeeting.Count}");
        }
    }
}