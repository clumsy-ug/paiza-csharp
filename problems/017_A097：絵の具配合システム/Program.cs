using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(" ");
        int T_R = int.Parse(arr[0]);
        int T_G = int.Parse(arr[1]);
        int T_B = int.Parse(arr[2]);

        int N = int.Parse(Console.ReadLine());

        List<int> reds = new List<int>();
        List<int> greens = new List<int>();
        List<int> blues = new List<int>();
        for (int i = 0; i < N; i++) {
           string[] line = Console.ReadLine().Split(" ");
           reds.Add(int.Parse(line[0]));
           greens.Add(int.Parse(line[1]));
           blues.Add(int.Parse(line[2]));
        }

        // ---- 元のコード (先頭 k 個しか試していないので誤り) ----
        // int redsSum = reds[0];
        // int greensSum = greens[0];
        // int bluesSum = blues[0];
        // for (int i = 1; i < N; i++)
        // {
        //     int nowCount = i + 1;
        //
        //     // int同士の除算は自動で小数点切り捨てされるのでこれでOK
        //     redsSum += reds[i];
        //     int nowRedsAverage = redsSum / nowCount;
        //
        //     greensSum += greens[i];
        //     int nowGreensAverage = greensSum / nowCount;
        //
        //     bluesSum += blues[i];
        //     int nowBluesAverage = bluesSum / nowCount;
        //
        //     if (
        //         nowRedsAverage == T_R &&
        //         nowGreensAverage == T_G &&
        //         nowBluesAverage == T_B
        //     )
        //     {
        //         Console.WriteLine("Yes");
        //         return;
        //     }
        // }

        // ---- 修正後 (bit 全探索) ----
        for (int mask = 1; mask < (1 << N); mask++)
        {
            int count = 0;
            int redsSum = 0;
            int greensSum = 0;
            int bluesSum = 0;

            for (int i = 0; i < N; i++)
            {
                if (((mask >> i) & 1) == 1)
                {
                    count++;
                    redsSum += reds[i];
                    greensSum += greens[i];
                    bluesSum += blues[i];
                }
            }

            if (
                redsSum / count == T_R &&
                greensSum / count == T_G &&
                bluesSum / count == T_B
            )
            {
                Console.WriteLine("Yes");
                return;
            }
        }

        Console.WriteLine("No");
    }
}
