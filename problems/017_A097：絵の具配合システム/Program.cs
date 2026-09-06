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

        // bit全探索
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
