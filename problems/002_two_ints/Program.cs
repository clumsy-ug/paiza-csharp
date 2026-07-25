using System;

// 1行に空白区切りで2つの整数 -> 合計を出力
//   入力例: 3 5
//   出力例: 8
class Program
{
    static void Main()
    {
        string[] parts = Console.ReadLine().Split(' ');
        int a = int.Parse(parts[0]);
        int b = int.Parse(parts[1]);

        Console.WriteLine(a + b);
    }
}
