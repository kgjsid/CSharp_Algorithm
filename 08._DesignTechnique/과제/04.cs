using System;
using System.Linq;
using System.Text;

namespace _08._DesignTechnique.과제
{
    public class _04
    {
        static int blue;
        static int white;
        static void Main(string[] args)
        {
            int N;

            N = int.Parse(Console.ReadLine());

            int[,] check = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    check[i, j] = int.Parse(temp[j]);
                }
            }

            // 체크 시작
            checkPaper(check, 0, 0, N, N);

            Console.WriteLine(white);
            Console.WriteLine(blue);
        }

        static public void checkPaper(int[,] check, int startX, int startY, int sizeX, int sizeY)
        {
            // 먼저 종이의 크기 안에 모두 동일한 수인지 체크
            bool isOk = Check(check, startX, startY, sizeX, sizeY);

            if (isOk == true)
            {
                if (check[startX, startY] == 1)
                {
                    blue++;
                    return;
                }
                else if (check[startX, startY] == 0)
                {
                    white++;
                    return;
                }
            }

            // 4분할하여 체크
            // 0 ~ 8 / 0 ~ 8
            // 0 ~ 4 / 0 ~ 4(좌상단) 0 ~ 4 / 4 ~ 8 (좌하단)
            // 4 ~ 8 / 0 ~ 4(우상단) 4 ~ 8 / 4 ~ 8 (우하단)
            // 사이즈는 전부 절반으로 줄이면 가능
            checkPaper(check, startX, startY, sizeX / 2, sizeY / 2);
            checkPaper(check, startX, startY + sizeY / 2, sizeX / 2, sizeY / 2);
            checkPaper(check, startX + sizeX / 2, startY, sizeX / 2, sizeY / 2);
            checkPaper(check, startX + sizeX / 2, startY + sizeY / 2, sizeX / 2, sizeY / 2);

        }

        static public bool Check(int[,] check, int startX, int startY, int sizeX, int sizeY)
        {
            // 제일 시작부터
            int first = check[startX, startY];

            // 맨 마지막까지 확인하였을 때
            for (int i = startX; i < startX + sizeX; i++)
            {
                for (int j = startY; j < startY + sizeY; j++)
                {
                    // 하나라도 동일하지 않다면
                    if (first != check[i, j])
                    {
                        return false;
                    }
                }
            }
            // 문제가 없다면
            return true;
        }
    }

}