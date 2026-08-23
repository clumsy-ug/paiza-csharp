using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(" ");
        int N = int.Parse(arr[0]);
        int M = int.Parse(arr[1]);

        // 各列車初期化（1人につき1人しかいない列車が全員分）
        Dictionary<int, int[]> trains = new Dictionary<int, int[]>();
        for (int i = 1; i <= N; i++)
        {
            trains.Add(i, new int[] { i });
        }

        // バトル結果で列車更新
        for (int i = 0; i < M; i++)
        {
            string[] arr2 =  Console.ReadLine().Split(" ");
            int winner = int.Parse(arr2[0]);
            int loser = int.Parse(arr2[1]);

            // trains[winner]の配列に、trains[loser]の配列を、次元数同じまま追加
            trains[winner] = trains[winner].Concat(trains[loser]).ToArray();
            // 敗者の列車は無くなった扱い（勝者の列車末尾に移転したため）
            trains.Remove(loser);
        }

        // 同点の優勝者もあり得るので、ひとまず最大列車人数は何点なのか取得
        int maxValueLength = trains.Max(kv => kv.Value.Length);

        // 最大列車人数を持っている優勝者をすべて取得
        int[] champions = trains.Where(kv => kv.Value.Length == maxValueLength)
                                .Select(kv => kv.Key)
                                .ToArray();
        
        foreach (int champion in champions)
        {
            Console.WriteLine(champion);
        }
    }
}
