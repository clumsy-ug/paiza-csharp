using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] arr = line.Split(" ");
        int N = int.Parse(arr[0]);  // スーパーの数
        int K = int.Parse(arr[1]);  // 買いたい野菜の種類の数

        int[,] priceMatrix = new int[N,K];
        for (int i = 0; i < N; i++)
        {
            string priceLine = Console.ReadLine();
            string[] priceArr = priceLine.Split(" ");
            for (int j = 0; j < K; j++)
            {

                priceMatrix[i,j] = int.Parse(priceArr[j]);
            }
        }

        HashSet<int> minPriceStoreRowIndex = new HashSet<int>();  // 各列ごとに、最小だったrowが入る
        for (int column = 0; column < K; column++)
        {
            int min = priceMatrix[0, column];  // 比較対象として、とりあえず最初の要素で初期化
            int minRowIndex = 0;
            for (int row = 1; row < N; row++)
            {
                if (min > priceMatrix[row, column])
                {
                    min = priceMatrix[row, column];
                    minRowIndex = row;
                }
            }
            
            minPriceStoreRowIndex.Add(minRowIndex);
        }

        Console.WriteLine(minPriceStoreRowIndex.Count);
    }
}
