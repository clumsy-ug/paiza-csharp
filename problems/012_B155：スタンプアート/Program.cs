using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 全スタンプ情報
        string[] HWN = Console.ReadLine().Split(" ");
        int H = int.Parse(HWN[0]);
        int W = int.Parse(HWN[1]);
        int N = int.Parse(HWN[2]);
        Dictionary<int, char[,]> stamps = new Dictionary<int, char[,]>();

        for (int i = 0; i < N; i++)
        {
            char[,] stamp = new char[H, W];
            for (int j = 0; j < H; j++)
            {
                string line = Console.ReadLine();
                for (int k = 0; k < W; k++)
                {
                    char c = line[k];
                    stamp[j, k] = c;
                }
            }
            stamps.Add(i, stamp);
        }

        // 各スタンプの貼り方
        string[] RC = Console.ReadLine().Split(" ");
        int R = int.Parse(RC[0]);
        int C = int.Parse(RC[1]);

        int[,] stampPlan = new int[R, C];
        for (int i = 0; i < R; i++)
        {
            string[] RArr = Console.ReadLine().Split(" ");
            for (int j = 0; j < C; j++)
            {
                stampPlan[i, j] = int.Parse(RArr[j]);
            }
        }

        // スタンプアート出力
        for (int i = 0; i < R; i++)
        {
            int stampRow = 0;
            backToTargetLoop: ;
            for (int j = 0; j < C; j++)
            {
                int targetStampIndex = stampPlan[i, j] - 1;
                char[,] targetStamp = stamps[targetStampIndex];

                for (int k = 0; k < W; k++)
                {
                    Console.Write(targetStamp[stampRow, k]);
                }

                if (j == C - 1)
                {
                    Console.WriteLine();
                    stampRow++;
                    if (stampRow > (H - 1))
                    {
                        stampRow = 0;
                        break;
                    }
                    else
                    {
                        goto backToTargetLoop;
                    }
                }
            }
        }
    }
}
