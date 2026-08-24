using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(" ");
        int n = int.Parse(arr[0]);  // n期
        int m = int.Parse(arr[1]);  // m種類の作物

        string[] arr2 = Console.ReadLine().Split(" ");
        int h = int.Parse(arr2[0]);  // h行
        int w = int.Parse(arr2[1]);  // w列

        // 収穫回数初期化
        Dictionary<int, int> cropsCounts = new Dictionary<int, int>();  // key: crops種類  value: そのcropsの収穫済個数
        for (int i = 1; i <= m; i++)
        {
            cropsCounts[i] = 0;
        }
        // 畑の状態
        int[,] matrix = new int[h, w];
        for (int i = 0; i < n; i++)
        {
            string[] arr3 =  Console.ReadLine().Split(" ");
            int startRow = int.Parse(arr3[0]) - 1;
            int endRow = int.Parse(arr3[1]);
            int startCol = int.Parse(arr3[2]) - 1;
            int endCol = int.Parse(arr3[3]);
            int crops = int.Parse(arr3[4]);

            for (int r = startRow; r < endRow; r++)
            {
                for (int c = startCol; c < endCol; c++)
                {
                    if (matrix[r, c] != 0)
                    {
                        int nowCrops = matrix[r, c];
                        cropsCounts.TryGetValue(nowCrops, out int count);  // countには、keyであるnowCropsが存在したらその値が、存在しなかったらデフォルト値（intなら0）が入る
                        cropsCounts[nowCrops] = count + 1;  // C#のDictionaryは、右辺（読み込み）ではなく左辺（書き込み）で使うなら、存在しないインデックスでもエラーにならない
                    }

                    matrix[r, c] = crops;
                }
            }
        }

        // keyの昇順ソート
        foreach (KeyValuePair<int, int> kv in cropsCounts.OrderBy(kv => kv.Key))
        {
            Console.WriteLine(kv.Value);
        }

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (matrix[i, j] == 0)
                {
                    Console.Write('.');
                }
                else
                {
                    Console.Write(matrix[i, j]);
                }

                if (j == w - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
