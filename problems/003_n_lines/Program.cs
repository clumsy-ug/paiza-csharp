using System;

// 1行目に個数 N、続く N 行に整数 -> 合計を出力
//   入力例: 3        出力例: 60
//           10
//           20
//           30
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += long.Parse(Console.ReadLine());
        }

        Console.WriteLine(sum);
    }
}
