using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(" ");
        int H = int.Parse(arr[0]);
        int W = int.Parse(arr[1]);

        // matrix作成
        char[,] matrix = new char[H, W];
        for (int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                matrix[i, j] = line[j];
            }
        }

        int answer = 0;
        // 先に点を探して、見つかってからその周囲が全部#かどうか確認する方が効率良さそう
        // 1行目と末行、1列目と末列は . があっても必ずドーナツ作れないので無視して良さそう
        for (int i = 1; i < H - 1; i++)
        {
            for (int j = 1; j < W - 1; j++)
            {
                if (matrix[i, j] == '#') continue;

                List<int[]> cellIndexes = CreateCellIndexes(i, j);

                bool isDonuts = IsDonuts(matrix, cellIndexes);
                if (isDonuts) answer++;
            }
        }

        Console.WriteLine(answer);
    }


    /// <summary>key: ループ回数 , value: [行, 列] の dictionary を返す</summary>
    static List<int[]> CreateCellIndexes(int i, int j)
    {
        return new List<int[]>
        {
            new int[] { i - 1, j - 1},
            new int[] { i - 1, j },
            new int[] { i - 1, j + 1 },
            new int[] { i, j - 1 },
            new int[] { i, j + 1 },
            new int[] { i + 1, j - 1 },
            new int[] { i + 1, j },
            new int[] { i + 1, j + 1 }
        };
    }


    /// <summary>matrixの中から、loopCountAndCellIndex</summary>
    /// <returns>8つ全部 # だったらtrue
    static bool IsDonuts(char[,] matrix, List<int[]> cellIndexes)
    {
        for (int i = 0; i < 8; i++)
        {
            int[] cellIndex = cellIndexes[i];
            int row = cellIndex[0];
            int col = cellIndex[1];

            if (matrix[row, col] == '.') return false;
            continue;
        }
        return true;
    }
}
