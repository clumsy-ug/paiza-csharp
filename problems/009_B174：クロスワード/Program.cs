using System;

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] arr = line.Split(" ");
        int H = int.Parse(arr[0]);
        int W = int.Parse(arr[1]);

        int N = int.Parse(Console.ReadLine());

        char[,] matrix = new char[H, W];

        for (int i = 0; i < N; i++)
        {
            string wordLine = Console.ReadLine();
            string[] wordArr = wordLine.Split(" ");
            int wordStartRowNumber = int.Parse(wordArr[0]);
            int wordStartColumnNumber = int.Parse(wordArr[1]);
            int direction = int.Parse(wordArr[2]);
            string word = wordArr[3];

            int nowRowIndex = wordStartRowNumber - 1;
            int nowColumnIndex = wordStartColumnNumber - 1;

            foreach (char c in word)
            {
                matrix[nowRowIndex, nowColumnIndex] = c;
                if (direction == 0)
                {
                    nowRowIndex++;
                }
                else
                {
                    nowColumnIndex++;
                }
            }
        }

        for (int r = 0; r < H; r++)
        {
            for (int c = 0; c < W; c++)
            {
                // char型はデフォルト値が '\0' つまり全ビット0
                if (matrix[r, c] == '\0')
                {
                    matrix[r, c] = '.';
                }

                Console.Write(matrix[r, c]);

                // 最終列の場合、改行して次行のmatrixへ
                if (c == W - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
