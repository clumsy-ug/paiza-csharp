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
            ReturnValue returnValue = CheckAllRideGondolaAndChangeGondola(gondolaCapacities, ref gondolaIndex, gondolaRidings, N, groups[groupIndex]);
            while (returnValue.Remaining != -1)
            {
                returnValue = CheckAllRideGondolaAndChangeGondola(gondolaCapacities, ref gondolaIndex, gondolaRidings, N, returnValue.Remaining);
            }
            gondolaRidings = returnValue.GondolaRidings;
        }

        // 回答
        foreach (int gondolaRiding in gondolaRidings) Console.WriteLine(gondolaRiding);
    }


    /// <summary>余った人が次のゴンドラでも乗り切れるかわからないため、再帰処理用に関数切り出し</summary>
    /// <returns>ReturnValue.Remainingが-1なら全員乗車可能、1以上ならそれがremainingの値そのもの</returns>
    static ReturnValue CheckAllRideGondolaAndChangeGondola(
        int[] gondolaCapacities,
        ref int gondolaIndex,
        int[] gondolaRidings,
        int N,
        int remaining
    )
    {
        ReturnValue returnValue = new ReturnValue();
        
        // グループ全員がこのゴンドラに乗れる
        if (gondolaCapacities[gondolaIndex] >= remaining)
        {
            gondolaRidings[gondolaIndex] += remaining;

            returnValue = new ReturnValue
            {
                Remaining = -1,
                GondolaRidings = gondolaRidings
            };
        }
        // グループで全員は乗れずに人が余る = 余った数人は次のゴンドラを占有（そのゴンドラでも乗り切れるかわからないので再帰チェック挟むべき）
        else
        {
            gondolaRidings[gondolaIndex] += gondolaCapacities[gondolaIndex];  // 許容範囲限界まで乗車
            returnValue = new ReturnValue
            {
                Remaining = remaining - gondolaCapacities[gondolaIndex],
                GondolaRidings = gondolaRidings
            };
        }

        if (gondolaIndex == N - 1) gondolaIndex = 0; else gondolaIndex++;  // 最後のゴンドラなら最初のゴンドラ0に戻る。最後出ないなら普通に次のゴンドラに行く。
        return returnValue;
    }
}


class ReturnValue
{
    public int Remaining;
    public int[] GondolaRidings;
}
