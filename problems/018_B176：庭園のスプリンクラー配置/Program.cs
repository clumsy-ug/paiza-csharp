using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // メモ
        // 境界値チェック忘れずに：indexoutofrangeexceptionを防ぐ
        // スプリンクラー自身のセルも水を撒く

        string[] arr = Console.ReadLine().Split(" ");
        int N = int.Parse(arr[0]);
        int M = int.Parse(arr[1]);
        int K = int.Parse(Console.ReadLine());

        bool[,] garden = new bool[N, M];
        for (int i = 0; i < K; i++)
        {
            string[] rc = Console.ReadLine().Split(" ");
            int sprinklerR = int.Parse(rc[0]) - 1;
            int sprinklerC = int.Parse(rc[1]) - 1;

            for (int gardenR = sprinklerR - 1; gardenR <= sprinklerR + 1; gardenR++)
            {
                if (gardenR < 0 || gardenR >= N) continue;  // 行の境界値チェック

                for (int gardenC = sprinklerC - 1; gardenC <= sprinklerC + 1; gardenC++)
                {
                    if (gardenC < 0 || gardenC >= M) continue;  // 列の境界値チェック

                    garden[gardenC, gardenR] = true;
                }
            }
        }

        // LINQを使わずカウントする場合
        // int answer = 0;
        // foreach (bool b in garden) if (b) answer++;
        
        // 二次元配列をシーケンスに平坦化してからLINQでカウント
        int answer = garden.Cast<bool>().Count(el => el);
        Console.WriteLine(answer);
    }
}
