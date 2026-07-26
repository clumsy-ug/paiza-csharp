// 二次元配列に逃げた解放

using System;

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] arr = line.Split(" ");

        int N = int.Parse(arr[0]);
        int H = int.Parse(arr[1]);
        int W = int.Parse(arr[2]);

        string line2 = Console.ReadLine();
        string[] arr2 = line2.Split(" ");

        int sy = int.Parse(arr2[0]);
        int sx = int.Parse(arr2[1]);

        string s = Console.ReadLine();

        string[,] matrix = new string[H, W];
        for (int i = 0; i < H; i++)
        {
            string loopLine = Console.ReadLine();
            string[] loopArr = loopLine.Split(" ");

            for (int j = 0; j < loopArr.Length; j++)
            {
                matrix[i, j] = loopArr[j];
            }
        }

        int nowRow = sy - 1;
        int nowColumn = sx - 1;
        foreach (char direction in s)
        {
            switch (direction)
            {
                case 'F':
                    nowRow--;
                    Console.WriteLine(matrix[nowRow, nowColumn]);
                    break;

                case 'B':
                    nowRow++;
                    Console.WriteLine(matrix[nowRow, nowColumn]);
                    break;

                case 'L':
                    nowColumn--;
                    Console.WriteLine(matrix[nowRow, nowColumn]);
                    break;

                case 'R':
                    nowColumn++;
                    Console.WriteLine(matrix[nowRow, nowColumn]);
                    break;
            }
        }
    }
}


/* 一次元配列のみで解き切る解法（こっちの方が難しい）

using System;

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] arr = line.Split(" ");

        int N = int.Parse(arr[0]);
        int H = int.Parse(arr[1]);
        int W = int.Parse(arr[2]);

        string line2 = Console.ReadLine();
        string[] arr2 = line2.Split(" ");

        int sy = int.Parse(arr2[0]);
        int sx = int.Parse(arr2[1]);

        string s = Console.ReadLine();

        string[] matrix = new string[H * W];
        for (int i = 0; i < H; i++)
        {
            string loopLine = Console.ReadLine();
            string[] loopArr = loopLine.Split(" ");

            for (int j = 0; j < loopArr.Length; j++)
            {
                matrix[i * W + j] = loopArr[j];
            }
        }

        int now = (sy - 1) * W + (sx - 1);
        foreach (char direction in s)
        {
            switch (direction)
            {
                case 'F':
                    now -= W;
                    Console.WriteLine(matrix[now]);
                    break;

                case 'B':
                    now += W;
                    Console.WriteLine(matrix[now]);
                    break;

                case 'L':
                    now--;
                    Console.WriteLine(matrix[now]);
                    break;

                case 'R':
                    now++;
                    Console.WriteLine(matrix[now]);
                    break;
            }
        }
    }
}

*/
