using System;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(" ");
        int N = int.Parse(arr[0]);
        int M = int.Parse(arr[1]);

        // 各ゴンドラの許容人数
        int[] gondolaCapacities = new int[N];
        for (int i = 0; i < N; i++)
        {
            int gondolaCapacity = int.Parse(Console.ReadLine());
            gondolaCapacities[i] = gondolaCapacity;
        }

        // 各グループの人数
        int[] groups = new int[M];
        for (int groupIndex = 0; groupIndex < M; groupIndex++)
        {
            int group = int.Parse(Console.ReadLine());
            groups[groupIndex] = group;
        }

        // 各ゴンドラに乗車
        int gondolaIndex = 0;
        int[] gondolaRidings = new int[N];
        for (int groupIndex = 0; groupIndex < M; groupIndex++)
        {
            int remaining = groups[groupIndex];
            while (remaining > 0)
            {
                remaining = RideAndMoveToNextGondola(gondolaCapacities, ref gondolaIndex, gondolaRidings, remaining);
            }
        }

        // 回答
        foreach (int gondolaRiding in gondolaRidings) Console.WriteLine(gondolaRiding);
    }


    /// <summary>乗り場のゴンドラに乗れるだけ載せて、次のゴンドラに進める</summary>
    /// <returns>乗れなかった余り人数。0なら全員乗れた</returns>
    static int RideAndMoveToNextGondola(
        int[] gondolaCapacities,
        ref int gondolaIndex,
        int[] gondolaRidings,
        int remaining
    )
    {
        int riding = Math.Min(remaining, gondolaCapacities[gondolaIndex]);  // 残り全員かゴンドラ定員か、少ない方だけ乗れる
        gondolaRidings[gondolaIndex] += riding;
        int nextRemaining = remaining - riding;

        gondolaIndex = (gondolaIndex + 1) % gondolaCapacities.Length;  // 最後のゴンドラなら最初のゴンドラ0に戻る。最後でないなら普通に次のゴンドラに行く。

        return nextRemaining;
    }
}
