using System;
using System.Collections.Generic;

// 【A】= 提出したコード（生きている行）／【B】= 改良版（直下のコメント行）
// 解説は 解説.md を参照。

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] arr = line.Split(" ");
        int N = int.Parse(arr[0]);  // スーパーの数
        int K = int.Parse(arr[1]);  // 買いたい野菜の種類の数

        // 【差1】価格の持ち方
        int[,] priceMatrix = new int[N,K];      // 【A】全価格を貯める → メモリ O(NK)
        // int[] minPrices     = new int[K];    // 【B】野菜ごとの最安値だけ → メモリ O(K)
        // int[] minRowIndices = new int[K];    // 【B】その最安値をつけた店（argmin）
        // for (int j = 0; j < K; j++) minPrices[j] = int.MaxValue;

        for (int i = 0; i < N; i++)
        {
            string priceLine = Console.ReadLine();
            string[] priceArr = priceLine.Split(" ");
            for (int j = 0; j < K; j++)
            {
                // 【差2】A は貯めるだけ（最小値は下のパス2で）。B はその場で更新して捨てる（1パス化）。
                priceMatrix[i,j] = int.Parse(priceArr[j]);                                // 【A】
                // int v = int.Parse(priceArr[j]);                                        // 【B】
                // if (v < minPrices[j]) { minPrices[j] = v; minRowIndices[j] = i; }      // 【B】
            }
        }

        // 【差2つづき】このパス2は【A】だけ。【B】は上に融合済みで不要。
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

        // 【差3】A は HashSet で重複除去。B は bool 配列で同じことをやる。
        // bool[] counted = new bool[N];
        // int count = 0;
        // for (int j = 0; j < K; j++)
        // {
        //     int minRowIndex = minRowIndices[j];
        //     if (!counted[minRowIndex]) { counted[minRowIndex] = true; count++; }
        // }

        Console.WriteLine(minPriceStoreRowIndex.Count);  // 【A】
        // Console.WriteLine(count);                     // 【B】
    }
}

// 【B】改良版 単体
class Program2
{
    static void Main2()
    {
        string[] nk = Console.ReadLine().Split(" ");
        int N = int.Parse(nk[0]);
        int K = int.Parse(nk[1]);

        int[] minPrices     = new int[K];  // [j] = 野菜 j の最安値
        int[] minRowIndices = new int[K];  // [j] = その最安値をつけた店（argmin）
        for (int j = 0; j < K; j++) minPrices[j] = int.MaxValue;

        for (int i = 0; i < N; i++)
        {
            string[] priceArr = Console.ReadLine().Split(" ");
            for (int j = 0; j < K; j++)
            {
                int v = int.Parse(priceArr[j]);
                if (v < minPrices[j])
                {
                    minPrices[j] = v;
                    minRowIndices[j] = i;
                }
            }
        }

        bool[] counted = new bool[N];  // 店 i が、何かしらの商品の最安値を提供しているとしてすでに数えられたか
        int count = 0;
        for (int j = 0; j < K; j++)
        {
            int minRowIndex = minRowIndices[j];
            if (!counted[minRowIndex])
            {
                counted[minRowIndex] = true;
                count++;
            }
        }

        Console.WriteLine(count);
    }
}
